using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject mainCanvas;

    void Start()
    {
        winScreen.SetActive(false);
        Time.timeScale = 1f;
    }


    public void OnTriggerEnter2D(Collider2D Player)
    {
        Dead();
    }

    public void Dead()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
        mainCanvas.SetActive(false);
    }
}
