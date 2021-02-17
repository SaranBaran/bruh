using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLodaingManager : MonoBehaviour
{

    public AudioSource clickSound;
    public GameObject mainCanvas;
    public GameObject credits;
    public AudioSource titleMusic;
    public GameObject tutorial;
    public int target = 30;


    void Start()
    {
        QualitySettings.vSyncCount = 0;

        mainCanvas.SetActive(true);
        credits.SetActive(false);
        titleMusic.Play();
        tutorial.SetActive(false);
    }

    void Update()
    {
        if (target != Application.targetFrameRate)
        {
            Application.targetFrameRate = target;
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene("bruh");
        titleMusic.Stop();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void clickSounds()
    {
        clickSound.Play();
    }

    public void goCredits()
    {
        credits.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void back()
    {
        credits.SetActive(false);
        mainCanvas.SetActive(true);
        tutorial.SetActive(false);
    }

    public void Tutorial()
    {
        mainCanvas.SetActive(false);
        tutorial.SetActive(true);
    }
}
