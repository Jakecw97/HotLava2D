using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonScript : MonoBehaviour
{
    private Transform levelEnd;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        levelEnd = GameObject.FindGameObjectWithTag("levelEnd").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed*Time.deltaTime);
    }
}
