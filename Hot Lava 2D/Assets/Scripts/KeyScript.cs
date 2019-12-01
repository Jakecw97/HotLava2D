using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private SpringJoint2D spring;

    // Start is called before the first frame update
    void Start()
    {
        //Initializes Spring and Keyholder
        spring = GetComponent<SpringJoint2D>();
        GameObject keyHolder = GameObject.FindWithTag("KeyHolder");
        //Disables it on scene start
        spring.enabled = false;
        //Binds key to Keyholder
        spring.connectedBody = keyHolder.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spring.enabled = true;
        }
    }
}
