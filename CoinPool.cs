using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour {
	public int coinPoolSize = 5;
	private GameObject[] coins;
	public GameObject coinPrefab;
	private Vector2 objectPoolPosition = new Vector2(-15f,-25f);
	private float timeSinceLastSpawned;
	public float SpawnRate = 4f;
	public float coinMax = 3.5f;
	public float coinMin = -1f;
	private float spawnxPosition = 10f;
	private int currentColumn = 0;

	// Use this for initialization
	void Start () {
		coins = new GameObject[coinPoolSize ];

		for (int i = 0; i < coinPoolSize; i++) {

			coins [i] = (GameObject)Instantiate (coinPrefab, objectPoolPosition, Quaternion.identity);

		}
	}

	// Update is called once per frame
	void Update () {

		timeSinceLastSpawned += Time.deltaTime;

		if (ArcadeControl.instance.gameOver == false && timeSinceLastSpawned >= SpawnRate) {



			timeSinceLastSpawned = 0f;
			float spawnYPosition = Random.Range (coinMin,coinMax);
			coins [currentColumn].transform.position = new Vector2 (spawnxPosition,spawnYPosition);
			currentColumn++;
			if (currentColumn >= coinPoolSize) {

				currentColumn = 0;

			}

		}


	}
}
