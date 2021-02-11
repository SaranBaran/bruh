using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    public float currentTime = 0f;
    public float minusTime = 1f;
    public Animator animator;
    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = 10f;
    }

    public void Update()
    {
        currentTime -= minusTime * Time.deltaTime;
        countdownText.text = currentTime.ToString("0.0");
        slowTime();
    }


    public void slowTime()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            minusTime = 0.1f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            minusTime = 1f;
        }
    }
}
