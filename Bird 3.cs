using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {
	public static Bird instance;
	public float upForce = 200f;
	private bool isDead = false;
	private Rigidbody2D rb2d;
	private Animator anim;
	public AudioSource Dead;
	public AudioSource Fly;
	public GameObject backgroud;
	public Scene scene;


	void Awake() {

		if (instance == null) {

			instance = this;
		} else if (instance != null) {


			Destroy (gameObject);

		}
	}


	// Use this for initialization
	void Start () {
		scene = SceneManager.GetActiveScene ();
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

			
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead == false) {



			if (Input.GetMouseButtonDown (0)) {
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2 (0, upForce));
				anim.SetTrigger ("Flap");

				if (Settings.instance.SoundFxOn) {
					Fly.Play ();
				}



			}
		
		
		
		
		
		
		
		}

		
	}


	void OnCollisionEnter2D(){

		rb2d.velocity = Vector2.zero;

		isDead = true;
		if (Settings.instance.SoundFxOn) {
			Dead.Play ();
		}
	

		anim.SetTrigger ("Die");
		if (scene.name == "gameScene") {
			GameControl.instance.BirdDied ();
			//UnityAdManager.instance.ShowAd ();
		} else if (scene.name == "ArcadeMode") {
		
			ArcadeControl.instance.BirdDied ();
			//UnityAdManager.instance.ShowAd ();
		
		} else if (scene.name == "Chapter3") {
		
			StoryMode.instance.BirdDied ();

		
		}



	}

}
