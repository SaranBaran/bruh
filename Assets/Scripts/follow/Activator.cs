using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Collectible)
    {
        GetComponent<Target>().enabled = true;
        enabled = false;
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<Animator>().SetTrigger("collect");
    }
}
