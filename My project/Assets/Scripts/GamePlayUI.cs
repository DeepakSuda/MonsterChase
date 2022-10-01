using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GamePlayUI : MonoBehaviour
{
    public GameObject gameoverpanel;
    public GameObject Restart;
    public GameObject Home;

    void Start()
    {
        gameoverpanel.SetActive(false);
    }
    public void RestartGame()
    {
        gameoverpanel.SetActive(false);
        SceneManager.LoadScene("GamePlay");
    }
    public void HomeButton()
    {
        gameoverpanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        gameoverpanel.SetActive(true);
    }
}
