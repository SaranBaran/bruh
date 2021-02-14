using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    private int ScoreNum;
    public CountdownScript countdownScript;
    public AudioSource collectSound;

    void Start()
    {
        ScoreNum = 0;
    }


    public void OnTriggerEnter2D(Collider2D Collect)
    {
        if (Collect.tag == "Collectible")
        {
            countdownScript.animator.SetTrigger("yesCollect");
            ScoreNum += 1;
            countdownScript.currentTime = 10f;
            collectSound.Play();
        }
    }
}
