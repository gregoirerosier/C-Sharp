using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameControl : MonoBehaviour {
    public GameObject gameOverPanel;
	public static GameControl instance;
	public bool gameOver = false;
	public float scrollSpeed = - 1.5f;
	public int score = 0;
    public Text scoreText;
    public Text scoreTextOver;
    public AudioSource BackgroundMusic;
	public AudioSource GameMusic;
	public Text HighScore;
    public Text ClassicalModeHighScore;
    public GameObject bird;
	public bool preGame;
	public Text StartGame;


	// Use this for initialization
	void Start () {
		Settings.instance.Load ();
		HighScore.text = "High Score:" + Settings.instance.ClassicHighScore;
		bird.GetComponent<Flap> ().enabled = true;
		preGame = true;
		this.GetComponent<ColumnPool> ().enabled = false;
		StartGame.enabled = true;


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
			Destroy (bird.GetComponent<Flap> ());
			bird.GetComponent<Bird> ().enabled = true;
			this.GetComponent<ColumnPool> ().enabled = true;
		

		}

	
		
	}
	public void Scored(){

		if (gameOver) {

			return;

		}
		score++;
		scoreText.text = "Score:" + score.ToString ();
		
	}
	public void CoinScored(){

		if (gameOver) {

			return;

		}
		score = score + 100;
		scoreText.text = "Score:" + score.ToString ();

	}


	public void BirdDied(){

		UnityAdManager.instance.ShowAd ();
		gameOverPanel.SetActive (true);
        scoreTextOver.text = "Score:" + score.ToString();
        gameOver = true;
		BackgroundMusic.Stop ();
		if (score > Settings.instance.ClassicHighScore) {
			Settings.instance.ClassicHighScore = score;
			scoreText.text = "New High Score!!";
			HighScore.text = "High Score:" + score;
            ClassicalModeHighScore.text = "High Score:" + score;
            Settings.instance.ClassicHighScore = score;
			Settings.instance.Save ();

		
		}




	}
	public void returnHome(){
	
		Destroy (bird);
		SceneManager.LoadScene ("MainMenu");
	
	
	}

	public void Retry(){
		Settings.instance.Load ();

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
