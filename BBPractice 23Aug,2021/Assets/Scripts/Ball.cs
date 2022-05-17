using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    [SerializeField] bool hastStarted = false;
    [SerializeField] float launchSpeed = 10f;
    [SerializeField] AudioClip[] audioClips;
   // [SerializeField] GameObject vfx;


    private Vector2 offSet;
    private Rigidbody2D rigidbody2D;
    private AudioSource audioSource;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        paddle = FindObjectOfType<Paddle>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        offSet = transform.position - paddle.transform.position;
    }

    private void Update()
    {
        if(!hastStarted)
        {
            StickBallToPaddle();
            LaunchTheBall();
        }
        
    }


    private void LaunchTheBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hastStarted = true;
            rigidbody2D.velocity = new Vector2(0, launchSpeed);
        }
        
    }


    private void StickBallToPaddle()
    {
        Vector2 paddle1 = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = offSet + paddle1;
    }


    private void OnCollisionEnter2D(Collision2D otherCollider)
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        AudioClip audioClip = audioClips[Random.Range(0,audioClips.Length)];
        audioSource.PlayOneShot(audioClip);
    }
    


}//CLASS
