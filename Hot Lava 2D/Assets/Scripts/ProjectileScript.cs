using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileScript : MonoBehaviour
{
    private float speed = 5;
    private Rigidbody2D myRigidbody;
    private Vector2 direction;
    private Animator projectileAnimation;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        projectileAnimation = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = direction * speed;
    }

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    //When the object leaves the camera the projectile gets deleted
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        projectileAnimation.SetTrigger("Destroy");
        DestroyProjectile();
        
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
       
    }
}
