using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollingObject : MonoBehaviour {
	public Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		Scene scene = SceneManager.GetActiveScene();
		rb2d = GetComponent<Rigidbody2D> ();

		switch(scene.name)

		{
		case "gameScene":
			rb2d.velocity = new Vector2 (GameControl.instance.scrollSpeed, 0);
			break;
		case "ArcadeMode":
			rb2d.velocity = new Vector2 (ArcadeControl.instance.scrollSpeed, 0);
			break;
		case "Chapter1":
			rb2d.velocity = new Vector2 (GameControl.instance.scrollSpeed, 0);
			break;
		case "Chapter3":
			rb2d.velocity = new Vector2 (StoryMode.instance.scrollSpeed, 0);
			break;
		case "MainMenu":
			rb2d.velocity = new Vector2 (MainMenu.instance.scrollSpeed, 0);
			break;
		case "SinglePlayerMenu":
			rb2d.velocity = new Vector2 (SinglePlayerMenu.instance.scrollSpeed,0);
			break;
		case "OnlineMenu":
			rb2d.velocity = new Vector2 (MainMenu.instance.scrollSpeed, 0);
			break;
		case "Settings":
			rb2d.velocity = new Vector2 (MainMenu.instance.scrollSpeed, 0);
			break;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (GameControl.instance != null ) {
			if(GameControl.instance.gameOver == true){
				rb2d.velocity = Vector2.zero;
			}

		
		}
		if (ArcadeControl.instance != null) {

			if(ArcadeControl.instance.gameOver == true){
				rb2d.velocity = Vector2.zero;
			}

		}
		if (Flap.instance != null && Flap.instance.IsDead) {
			rb2d.velocity = Vector2.zero;

		}

		if (StoryMode.instance !=null) {
			if (StoryMode.instance.gameOver == true) {
			
				rb2d.velocity = Vector2.zero;
			}
		
		}


	}
}
