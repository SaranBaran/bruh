using System.Collections;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject PreFab;
    public ParticleSystem pow;
    public GameObject displayText;

    void Start()
    {
        displayText.SetActive(false);
    }


    public void OnTriggerEnter2D(Collider2D Player)
    {
        PreFab.transform.position = spawnPoint.position;
        displayText.SetActive(true);
        pow.Play();
    }



}


