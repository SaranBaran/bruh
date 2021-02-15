using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLodaingManager : MonoBehaviour
{

    public void startGame()
    {
        SceneManager.LoadScene("bruh");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
