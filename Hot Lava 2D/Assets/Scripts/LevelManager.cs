using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay = 1;
    public PlayerControl gamePlayer; //referring to player_move script and object it is attached to
   

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerControl>();
     
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false); //disabling player object temp
        yield return new WaitForSeconds(respawnDelay);
        gameObject.gameObject.SetActive(true); //re-enabling player object
        gamePlayer.transform.position = gamePlayer.respawnPoint; //setting position point to respawn point in player_move script

    }

}
