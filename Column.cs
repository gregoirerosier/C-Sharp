using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Column : MonoBehaviour {
	public Scene scene;


	void Start(){
		 scene = SceneManager.GetActiveScene();
	
	}
	private void OnTriggerEnter2D (Collider2D other){


	
		if (other.GetComponent<Bird> () != null) {
		
			if (scene.name == "gameScene") {
			
				GameControl.instance.Scored ();
			} else if (scene.name == "ArcadeMode") {
			
			
				ArcadeControl.instance.Scored ();
			} else if (scene.name == "Chapter3") {
			
				StoryMode.instance.Scored ();
			
			}

		
		}
	
	}


}
