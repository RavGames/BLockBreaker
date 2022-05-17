using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameSession : MonoBehaviour
{
    [SerializeField] [Range(1f, 5f)] float gameSpeed = 2f;
    private int currentScore = 0;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] bool isAutoPlayEnables = true;

    private void Awake()
    {
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }



    private void Start()
    {
        text = FindObjectOfType<TextMeshProUGUI>();
        DisplayUpdateScore();
    }


    private void Update()
    {
        Time.timeScale = gameSpeed;
    }


    public void DisplayUpdateScore()
    {
        text.text = currentScore.ToString();
    }

    public void AddPointsToScore(int pointsPerBlock)
    {
        currentScore += pointsPerBlock;
        DisplayUpdateScore();
    }


    public void ResetGame()
    {
       // gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnables;
    }


}//CLASS
