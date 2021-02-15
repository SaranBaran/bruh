using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLodaingManager : MonoBehaviour
{

    public AudioSource clickSound;
    public GameObject mainCanvas;
    public GameObject credits;


    void Start()
    {
        mainCanvas.SetActive(true);
        credits.SetActive(false);
    }

    public void startGame()
    {
        SceneManager.LoadScene("bruh");
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
