 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Settings : MonoBehaviour {
    public static Settings instance;
    public int StoryModeProgress;
    public int StoryModeDeaths;
    public bool SoundFxOn;
    public bool MenuMusicOn;
    public bool GameMusicOn;
    public Toggle SoundFxOnT;
    public Toggle MenuMusicOnT;
    public Toggle GameMusicOnT;
    public AudioSource SoundFx;
    public AudioSource GameMusic;
    public AudioSource MenuMusic;
    public bool ChoosingOne;
    public string ChosenOne;
    public string CharacterName;
    public bool waitEndChapter2;
    public int ClassicHighScore;
    public int ArcadeHighScore;
    public Text SettingsClassicScore;
    public Text SettingsArcadeScore;
    public Scene scene;
    public string ArcadeBirdColor;
    public bool AccCreated = false;
    public bool Logged;
    public string Email;
    public Text Account;
    public Button SignOut;
    public string userName;
    public int AdCount;
    public GameObject UserEmail;
    public Text manageAccount;




	void Awake() {

		if (instance == null) {

			instance = this;
		} else if (instance != null) {


			Destroy (gameObject);

		}
	}
	// Use this for initialization
	void Start () {
		print (Email);
		
	//	manageAccount.text = Email ;
			
		if (SettingsClassicScore && SettingsArcadeScore != null) {
			SettingsClassicScore.text = "score:" + ClassicHighScore;
			SettingsArcadeScore.text = "score:" + ArcadeHighScore;
		
		}

		
		setSoundSystem (SoundFx,SoundFxOnT,SoundFxOn);
		setSoundSystem (MenuMusic,MenuMusicOnT,MenuMusicOn);
		setSoundSystem (GameMusic,GameMusicOnT,GameMusicOn);

	

	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
	public void signOut(){
		Logged = false;
		Account.text = "Sign Out";
		SignOut.interactable = false;
		saveSettings ();

	}


	public void setSoundSystem(AudioSource sound,Toggle button,Boolean userChoice){


		if (userChoice) {
			if (button != null) {
				button.isOn = true;
			}
		

			sound.Play ();
			

		} else if (userChoice == false) {

			if (button != null) {
				button.isOn = false;
			}
		
			if (sound.isPlaying) {
			
				sound.Stop ();
			}
		
		}
	




	}

	public void saveSettings(){
		if(SoundFxOnT.isOn)
		{SoundFxOn = true;print ("Is on");}
		else
		{SoundFxOn = false;}





		if (MenuMusicOnT.isOn) {
			MenuMusicOn = true;
		} else {
			MenuMusicOn = false;
		}


		if (GameMusicOnT.isOn) {
			GameMusicOn = true;
		} else {
			GameMusicOn = false;
		}




		Save ();
	
	}

	public void Save(){
	
		BinaryFormatter BF = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/Settings.dat");
		PlayerData data = new PlayerData ();
		data.StoryModeProgress = StoryModeProgress;
		data.StoryModeDeaths = StoryModeDeaths;
		data.SoundFxOn = SoundFxOn;
		data.MenuMusicOn = MenuMusicOn;
		data.GameMusicOn = GameMusicOn;
		data.ChoosingOne = ChoosingOne;
		data.ChosenOne = ChosenOne;
		data.CharacterName = CharacterName;
		data.waitEndChapter2 = waitEndChapter2;
		data.ClassicHighScore = ClassicHighScore;
		data.ArcadeHighScore = ArcadeHighScore;
		data.ArcadeBirdColor = ArcadeBirdColor;
		data.AccCreated = AccCreated;
		data.Logged = Logged;
		data.Email = Email;
		data.userName = userName;
		data.AdCount = AdCount;
		BF.Serialize (file,data);
		file.Close ();
	
	}

	public void Load(){
	
		if (File.Exists (Application.persistentDataPath + "/Settings.dat")) {
			BinaryFormatter BF = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/Settings.dat",FileMode.Open); 
			PlayerData data = (PlayerData)BF.Deserialize (file);
			file.Close ();
			StoryModeDeaths = data.StoryModeDeaths;
		  	StoryModeProgress = data.StoryModeProgress;
			SoundFxOn = data.SoundFxOn;
			MenuMusicOn = data.MenuMusicOn;
			GameMusicOn = data.GameMusicOn;
			ChoosingOne = data.ChoosingOne;
			ChosenOne = data.ChosenOne;
			CharacterName = data.CharacterName;
			waitEndChapter2 = data.waitEndChapter2;
			ClassicHighScore = data.ClassicHighScore;
			ArcadeHighScore = data.ArcadeHighScore;
			ArcadeBirdColor = data.ArcadeBirdColor;
			Logged = data.Logged;
			AccCreated = data.AccCreated;
			Email = data.Email;
			userName = data.userName;
			AdCount = data.AdCount;


		
		}




	
	
	}
}

[Serializable]
class PlayerData
{
	public int StoryModeProgress;
	public int StoryModeDeaths;
	public bool SoundFxOn;
	public bool MenuMusicOn;
	public bool GameMusicOn;
	public string ChosenOne;
	public bool ChoosingOne;
	public string CharacterName;
	public bool waitEndChapter2;
	public int ClassicHighScore;
	public int ArcadeHighScore;
	public string ArcadeBirdColor;
	public bool AccCreated;
	public bool Logged;
	public string Email;
	public string userName;
	public int AdCount;





}