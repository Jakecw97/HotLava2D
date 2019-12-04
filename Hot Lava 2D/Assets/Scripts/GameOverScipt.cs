using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScipt : MonoBehaviour
{
   public void SelectRetry()
    {

    }
    
    public void SelectQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
