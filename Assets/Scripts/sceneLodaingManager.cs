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


    void Start()
    {
        mainCanvas.SetActive(true);
        credits.SetActive(false);
        titleMusic.Play();
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
    }
}
