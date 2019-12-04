using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public PlayerControl gamePlayer; //referring to player_move script and object it is attached to
    public int collectable;
    public Text scoreText;
    public GameObject DifficultyValue;


    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerControl>();
     //   DifficultyValue.transform.GetChild((int)DifficultyScript.Difficulty).GetComponent<Toggle>().isOn = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

 
    public void AddCollectable(int collectables)
    { //adds coin to the game depending on coin value
        collectable += collectables;
        scoreText.text = "Score: " + collectable;
    }

}
