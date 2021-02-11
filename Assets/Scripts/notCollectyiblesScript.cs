using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notCollectyiblesScript : MonoBehaviour
{
    public CountdownScript countdownScript;

    private void OnTriggerEnter2D(Collider2D notCollect)
    {
        if (notCollect.tag == "notCollect")
        {
            countdownScript.animator.SetBool("isCollide", true);
            Destroy(notCollect.gameObject);
            countdownScript.animator.SetTrigger("NotCollect");
            countdownScript.currentTime = countdownScript.currentTime - 1;
        }
    }
}
