using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour

{
    public int maxHp;
    public int currentHp;

    public Image[] hearts;
    public Sprite heart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHp)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
