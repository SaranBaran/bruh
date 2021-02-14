using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersSpawnerControl : MonoBehaviour
{
	public float spawnFast = 1.5f;
	public Transform[] spawnPoints;
	public GameObject[] monsters;
	int randomSpawnPoint, randomMonster;
	public static bool spawnAllowed;
	GameObject clone;
	int seconds;
	float timer = 0.0f;

	// Use this for initialization
	void Start()
	{
		seconds = 0;
		spawnAllowed = true;
		InvokeRepeating("SpawnAMonster", 0f, spawnFast); 
	}

	void Destroy_Timer()
	{
		timer += Time.time;
		seconds = (int)timer % 60;
		if (seconds >= 2)
		{
			Destroy(clone, (float) 3.0);
			seconds = 0;
		}
	}


	void SpawnAMonster()
	{
		if (spawnAllowed)
		{
			randomSpawnPoint = Random.Range(0, spawnPoints.Length);
			randomMonster = Random.Range(0, monsters.Length);
			clone = Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position,
				Quaternion.identity);
			Destroy_Timer();
			GetComponent<AudioSource>().Play();
		} 

	}

}
