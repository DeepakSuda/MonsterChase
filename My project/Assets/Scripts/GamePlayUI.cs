using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    public GameObject gameoverpanel;

    void Start()
    {
        gameoverpanel.SetActive(false);
    }
   

    public void GameOver()
    {
        gameoverpanel.SetActive(true);
    }
}
