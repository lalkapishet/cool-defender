using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{

	public GameObject prefab;

	public Transform borderTop;
	public Transform borderBottom;

	public int 	countSpawnPrefabs;

	public float spawnInterval = 1;
	public float spawnTimer;


	void Start()
	{
		countSpawnPrefabs = countSpawnPrefabs + LevelController.Level * 2;
	}

	void Update()
	{
		spawnTimer -= Time.deltaTime;

		if (spawnTimer <= 0)
		{
			Spawn();
		}
	}

	void Spawn()
	{
		if(countSpawnPrefabs == 0) return;

		float randomY = Random.Range(borderBottom.position.y, borderTop.position.y);

		Vector3 position = transform.position;
		position.y = randomY;

		Instantiate(prefab, position, Quaternion.identity);
		spawnTimer = spawnInterval;

		countSpawnPrefabs -= 1;
	}

}
