using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShootScript : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    //Disables  when off screen
    private void OnBecameInvisible()
    {
        GetComponent<ProjectileShootScript>().enabled = false;
    }
    //Re enables  once they are visible
    private void OnBecameVisible()
    {
        GetComponent<ProjectileShootScript>().enabled = true;
    }
}
