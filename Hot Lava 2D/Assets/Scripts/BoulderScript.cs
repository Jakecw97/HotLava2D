using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderScript : MonoBehaviour
{
    private GameObject key;
    private Animator boulderAnimation;

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.FindWithTag("Key");
        boulderAnimation = GetComponent<Animator>();

    }
    private void Update()
    {
        
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            boulderAnimation.SetTrigger("Destroy");
            yield return new WaitForSeconds(1);
            Destroy(key);
            Destroy(gameObject);
        }
    }
}
