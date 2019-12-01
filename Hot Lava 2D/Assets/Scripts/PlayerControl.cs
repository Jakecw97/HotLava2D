using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    //variables
    public float speed = 0f;
    public float jumpSpeed = 6f;
    private float movement = 0f;
   // private float direction = 1f; //instantiated to allow projectiles to work
    private Rigidbody2D rigidBody;

    public int maxHp;
    public int currentHp;
    public Image[] hearts;
    private bool isDead;
    private bool facingRight;

    public Transform groundCheckPoint; //Bottom of player, checking if theyre on the ground
    public float groundCheckRadius; // Radius of Player ground check
    public LayerMask groundLayer; // jump off things added to this layer
    private bool isTouchingGround;
    public Transform ropeTransform; //Rope

    private Animator playerAnimation;
    public Vector3 respawnPoint; //Store position of where player is going to respawn to
    public LevelManager gameLevelManager;



  //  private float waitTime = 3f;

  


    private void Start()
    {
        //Player assets
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        gameLevelManager = FindObjectOfType<LevelManager>();

    }

    private void Update()
    {
        // if player is touching ground = true, if not = false
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");

       
            //will only move if keys left or right are pressed
            if (movement > 0f)
            {  //right
               // direction = 1f;
                rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);


            }
            else if (movement < 0f)
            { //left
               // direction = -1f;
                rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);


            }
            else
            { //dont move if none of keys are pressed
                rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            }
            if (movement < 0f && !facingRight)
            {
                facingRight = true;
                Flip();
            }
            else if (movement > 0f && facingRight)
            {
                facingRight = false;
                Flip();
            }


            //Jump, can check all inputs in Edit->Project Settings->Input
            if (Input.GetButtonDown("Jump") && isTouchingGround == true)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            }

        /*void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Rope")
            {
                col.collider.transform.SetParent(transform);
            }
        }
        void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject.tag == "Rope")
            {
                transform.parent = null;
            }
        }*/
        playerAnimation.SetFloat("Movement", Mathf.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("OnTheGround", isTouchingGround);


        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        if (currentHp <= 0)
        {
            isDead = true;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHp)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    


}

    private IEnumerator OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Lava")
        {
            float damage = 1 * Time.deltaTime;
            currentHp -= (int)System.Math.Floor(damage);
            yield return new WaitForSeconds(1);

        }
        if (other.tag == "Ground")
        {
        }
    }
        private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

}
