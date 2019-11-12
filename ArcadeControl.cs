using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArcadeControl : MonoBehaviour {
	public static ArcadeControl instance;
	public bool gameOver = false;
    public GameObject gameOverPanel;
	public float scrollSpeed = - 1.5f;
	public int score = 0;
	public Text scoreText;
    public Text scoreTextOver;
    public AudioSource BackgroundMusic;
	public Text HighScore;
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
			HighScore.text = "High Score:" + Settings.instance.ArcadeHighScore;

		}

		GameInit (Settings.instance.ArcadeBirdColor);
		GameBird.SetActive (true);
		GameBird.GetComponent<Flap> ().enabled = true;
		preGame = true;
		this.GetComponent<ColumnPool> ().enabled = false;
		this.GetComponent<CoinPool> ().enabled = false;
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
			Destroy (GameBird.GetComponent<Flap> ());
			GameBird.GetComponent<Bird> ().enabled = true;
			this.GetComponent<ColumnPool> ().enabled = true;
			this.GetComponent<CoinPool> ().enabled = true;

			}
		

	

	}



	public void GameInit(string color){
		ChosenArcadeBird = color;
		if (ChosenArcadeBird == "R") {
			
			GreenBird.SetActive (false);
			BlueBird.SetActive (false);
			RedBird.SetActive (true);
			GameBird = RedBird;
		
		
		
		}else if(ChosenArcadeBird == "B") {

			GreenBird.SetActive (false);
			RedBird.SetActive (false);
			BlueBird.SetActive (true);
			GameBird = BlueBird;



		}else if(ChosenArcadeBird == "G") {

			BlueBird.SetActive (false);
			RedBird.SetActive (false);
			GreenBird.SetActive (true);

			GameBird = GreenBird;




		}




	}


	public void Scored(){

		if (gameOver) {

			return;

		}
		score = score + 2;
		scoreText.text = "Score:" + score.ToString ();
		
	}



	public void CoinScored(){

		if (gameOver) {

			return;

		}
		score = score + 10;
		scoreText.text = "Score:" + score.ToString ();

	}


	public void BirdDied(){

		UnityAdManager.instance.ShowAd ();

		gameOverPanel.SetActive (true);
        scoreTextOver.text = "Score:" + score.ToString();
        gameOver = true;
		BackgroundMusic.Stop ();

		if (score > Settings.instance.ArcadeHighScore) {
			Settings.instance.ArcadeHighScore = score;
			scoreText.text = "New High Score!!";
			HighScore.text = "High Score:" + score;
			Settings.instance.ArcadeHighScore = score;
			Settings.instance.Save ();

		
		}




	}
	public void returnHome(){
	
		SceneManager.LoadScene ("MainMenu");
	
	
	}

	public void Retry(){
		Settings.instance.Load ();

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
