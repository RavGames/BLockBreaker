using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int noOfBlocks;

    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }


    public void TotalBlocks()
    {
        noOfBlocks++;
    }


    public void NextLevel()
    {
        noOfBlocks--;
        if(noOfBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }


}
