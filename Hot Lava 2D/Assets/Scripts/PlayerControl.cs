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
    private float jump = 0f;
    private float mobileMovement = 0f;
   
    // private float direction = 1f; //instantiated to allow projectiles to work
    private Rigidbody2D rigidBody;

    public int maxHp;
    public int currentHp;
    public Image[] hearts;
    private bool isDead;
    private bool facingRight;
    bool canTakeDamage = true;

    public Transform groundCheckPoint; //Bottom of player, checking if theyre on the ground
    public float groundCheckRadius; // Radius of Player ground check
    public LayerMask groundLayer; // jump off things added to this layer
    private bool isTouchingGround;
    public Joystick joystick;
    public Joystick joystick2;



    private Animator playerAnimation;
    public LevelManager gameLevelManager;
    

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
        mobileMovement = joystick.Horizontal;
        jump = joystick2.Vertical;
       
            //will only move if keys left or right are pressed
            if (movement > 0f )
            {  //right
                rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            }
            else if (movement < 0f)
            { //left
                rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            }
            else if (mobileMovement > 0f)
            { //left
                rigidBody.velocity = new Vector2(mobileMovement * speed, rigidBody.velocity.y);
            }
            else if (mobileMovement < 0f)
            { //left
                rigidBody.velocity = new Vector2(mobileMovement * speed, rigidBody.velocity.y);
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
            else if (mobileMovement < 0f && !facingRight)
            {
                facingRight = true;
                Flip();
            }
            else if (mobileMovement > 0f && facingRight)
            {
                facingRight = false;
                Flip();
            }


        //Jump, can check all inputs in Edit->Project Settings->Input
        if (jump >= .4f && isTouchingGround == true || Input.GetButtonDown("Jump") && isTouchingGround == true)
            {
                FindObjectOfType<SoundScript>().Play("jump");
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            }

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
        if (isDead == true)
        {
            SceneManager.LoadScene("GameOver");
        }


}//Update

    void OnParticleCollision(GameObject test)
    {
        if (canTakeDamage)
        {
            currentHp -= 1;
            FindObjectOfType<SoundScript>().Play("damage");
            StartCoroutine(WaitForSeconds());

        }
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fireball")
        {
            if (canTakeDamage)
            {
                currentHp -= 1;
                FindObjectOfType<SoundScript>().Play("damage");
                StartCoroutine(WaitForSeconds());

            }
        }    
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Lava")
        {
            if(canTakeDamage)
            {
                currentHp -= 1;
                FindObjectOfType<SoundScript>().Play("damage");
                StartCoroutine(WaitForSeconds());
               
            }
        }
    }
    
    private IEnumerator WaitForSeconds()
    {
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime(1);
        canTakeDamage = true;
    }
    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

}
