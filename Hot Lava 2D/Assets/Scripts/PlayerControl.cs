using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    //variables
    public float speed = 0f;
    public float jumpSpeed = 6f;
    private float movement = 0f;
   // private float direction = 1f; //instantiated to allow projectiles to work
    private Rigidbody2D rigidBody;
    private bool isDead;
    private bool facingRight;

    public Transform groundCheckPoint; //Bottom of player, checking if theyre on the ground
    public float groundCheckRadius; // Radius of Player ground check
    public LayerMask groundLayer; // jump off things added to this layer
    private bool isTouchingGround;

    private Animator playerAnimation;
    public Vector3 respawnPoint; //Store position of where player is going to respawn to
    public LevelManager gameLevelManager;



  //  private float waitTime = 3f;

  


    private void Start()
    {
        //Player assets
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();

        //When game loads, respawn point is set to position of player
      //  respawnPoint = transform.position;

        gameLevelManager = FindObjectOfType<LevelManager>();

    }

    private void Update()
    {
        // if player is touching ground = true, if not = false
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");

        if (!this.playerAnimation.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
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

        }
        playerAnimation.SetFloat("Movement", Mathf.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("OnTheGround", isTouchingGround);
    }
    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

}
