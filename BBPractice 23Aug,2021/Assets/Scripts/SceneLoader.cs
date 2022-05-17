using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{

   // private GameSession gameSession;

    private void Start()
    {
       // gameSession = FindObjectOfType<GameSession>();
    }

    public void StartGame()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }


}//CLASS
