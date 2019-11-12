using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryMode : MonoBehaviour {
	public static StoryMode instance;
	public GameObject GameOverText;
	public GameObject TryAgainText;
	public bool gameOver = false;
	public GameObject ExitButton;
	public GameObject RetryButton;
	public float scrollSpeed = - 1.5f;
	public int score = 0;
	public Text scoreText;
	public AudioSource BackgroundMusic;
	public GameObject GameBird;
	public bool preGame;
	public Text StartGame;
	public GameObject BlueBird;
	public GameObject RedBird;
	public GameObject GreenBird;
	public string ChosenArcadeBird;
	public AudioSource GameMusic;



	// Use this for initialization
	void Start () {
		Settings.instance.Load ();
		if (Settings.instance != null) {
			Settings.instance.Load ();

		}



		this.GetComponent<ColumnPool> ().enabled = false;
		preGame = true;

		if (Settings.instance.GameMusicOn) {

			GameMusic.Play ();
		} else {
			GameMusic.Stop ();
		}
	}

	void Awake() {

		if (instance == null) {

			instance = this;
		} else if (instance != null) {


			Destroy (gameObject);

		}
	}
	// Update is called once per frame
	void Update () {
		if(preGame == true && Input.GetMouseButtonDown (0)){
			preGame = false;
			StartGame.enabled = false;
			Destroy (GameBird.GetComponent<Flap> ());
			GameBird.GetComponent<Bird> ().enabled = true;
			this.GetComponent<ColumnPool> ().enabled = true;


		}

		if (Input.GetMouseButtonDown (0) && GameBird.GetComponent<Flap> ().enabled && GameBird.GetComponent<Flap> () !=null ) {
		Destroy (GameBird.GetComponent<Flap> ());
			GameBird.GetComponent<Bird> ().enabled = true;
		
		}




	}






	public void Scored(){

		if (gameOver) {

			return;

		}
		score = score + 10;
		scoreText.text = "Progress:" + score.ToString () + "%";

	}



/*	public void CoinScored(){

		if (gameOver) {

			return;

		}
		score = score + 100;
		scoreText.text = "Score:" + score.ToString ();

	} */


	public void BirdDied(){



		GameOverText.SetActive (true);
		TryAgainText.SetActive (true);
		ExitButton.SetActive (true);
		RetryButton.SetActive (true);
		gameOver = true;
		BackgroundMusic.Stop ();

	




	}
	public void returnHome(){

		SceneManager.LoadScene ("MainMenu");


	}

	public void Retry(){
		Settings.instance.Load ();

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
