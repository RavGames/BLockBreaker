using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float distanceInWorldUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    private GameSession gameSession;
    private Ball ball;



    private void Update()
    {
        Move();
    }


    public void Move()
    {
        float mousePos = Input.mousePosition.x / Screen.width * distanceInWorldUnits;
       
        float newPos = Mathf.Clamp(GetPosX(), minX, maxX);
        Vector2 paddlePos = new Vector2(newPos, transform.position.y);

        transform.position = paddlePos;
        
       
    }

    public float GetPosX()
    {
        if(FindObjectOfType<GameSession>().IsAutoPlayEnabled())
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * distanceInWorldUnits;
        }
    }







}//CLASS
