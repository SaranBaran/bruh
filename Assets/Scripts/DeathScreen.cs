using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    public CountdownScript countdownScript;
    public GameObject mainCanvas;

    void Start()
    {
        deathScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (countdownScript.currentTime < 0)
        {
                Dead();
        }
    }

    public void Dead()  
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
        mainCanvas.SetActive(false);
    }
}
