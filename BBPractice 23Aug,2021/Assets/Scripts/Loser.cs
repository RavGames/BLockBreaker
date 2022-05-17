using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loser : MonoBehaviour
{
    [SerializeField] float waitWait = 3f;


    private void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            Destroy(otherCollider.gameObject);
            StartCoroutine(Lose());
        }
        //StopAllCoroutines();
    }

    IEnumerator Lose()
    {
        yield return new WaitForSeconds(waitWait);
        SceneManager.LoadScene("GameOver");
    }

}//CLASS
