using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {
	public int columnPoolSize = 5;
	private GameObject[] columns;
	public GameObject columnPrefab;
	private Vector2 objectPoolPosition = new Vector2(-15f,-25f);
	private float timeSinceLastSpawned;
	public float SpawnRate = 4f;
	public float columMax = 3.5f;
	public float columMin = -1f;
	private float spawnxPosition = 10f;
	private int currentColumn = 0;

	// Use this for initialization
	void Start () {
		columns = new GameObject[columnPoolSize ];

		for (int i = 0; i < columnPoolSize; i++) {

			columns [i] = (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity);

		}
	}
	
	// Update is called once per frame
	void Update () {



		timeSinceLastSpawned += Time.deltaTime;

		if (GameControl.instance != null && GameControl.instance.gameOver == false && timeSinceLastSpawned >= SpawnRate) {



			timeSinceLastSpawned = 0f;
			float spawnYPosition = Random.Range (columMin,columMax);
			columns [currentColumn].transform.position = new Vector2 (spawnxPosition,spawnYPosition);
			currentColumn++;
			if (currentColumn >= columnPoolSize) {
			
				currentColumn = 0;
			
			}
		
		}
		if (ArcadeControl.instance != null && ArcadeControl.instance.gameOver == false && timeSinceLastSpawned >= SpawnRate) {



			timeSinceLastSpawned = 0f;
			float spawnYPosition = Random.Range (columMin,columMax);
			columns [currentColumn].transform.position = new Vector2 (spawnxPosition,spawnYPosition);
			currentColumn++;
			if (currentColumn >= columnPoolSize) {

				currentColumn = 0;

			}

		}

		if (StoryMode.instance != null && StoryMode.instance.gameOver == false && timeSinceLastSpawned >= SpawnRate) {



			timeSinceLastSpawned = 0f;
			float spawnYPosition = Random.Range (columMin,columMax);
			columns [currentColumn].transform.position = new Vector2 (spawnxPosition,spawnYPosition);
			currentColumn++;
			if (currentColumn >= columnPoolSize) {

				currentColumn = 0;

			}

		}


	}
}
