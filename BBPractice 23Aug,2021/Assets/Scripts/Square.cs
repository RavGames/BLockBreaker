using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField] GameObject particles;
    [SerializeField] float destroyPeroid = .3f;
    [SerializeField] AudioClip audioClip;


    private int hitTimes;
    [SerializeField] Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    private Level level;
    private GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
        if(tag == "Breakable")
        {
            level.TotalBlocks();
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnCollisionEnter2D(Collision2D otherCollider)
    {
        PlayMusic();

        if (tag == "Breakable")
        {
            DestroyBox();
        }
    }
    
    public void DestroyBox()
    {
        BlockHit();
    }

    public void PlayMusic()
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
    }

    private void BlockHit()
    {
        int maxHit = sprites.Length + 1;
        hitTimes++;
        if(hitTimes >= maxHit)
        {
            Destroy(gameObject);
            ShowVfx();
            gameSession.AddPointsToScore(40);
            level.NextLevel();
        }
        else
        {
            RenderSprite();
        }

    }

    private void RenderSprite()
    {
       int spriteIndex = hitTimes - 1;

        if(sprites[spriteIndex] != null)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
        else
        {
            return;
        }
    }


    public void ShowVfx()
    {
        GameObject vfx = Instantiate(particles,
                                    transform.position,
                                    transform.rotation) as GameObject;
        Destroy(vfx, destroyPeroid);
    }

}//CLASS
