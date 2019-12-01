using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public float offset; //how far is the camera away from the player
    private Vector3 playerPosition;
    public float offsetTime; //time it takes for offset to gradually move into place


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //make camera follow player on x and y axis, keep it the same on z axis
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        //adds offset so player can see infront
        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }

        //smoothly move camera into position, deltaTime will remain smoothness no matter what computer is used
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetTime * Time.deltaTime);

    }
}
