using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chapters : MonoBehaviour {

	public GameObject Cutscene;

	public GameObject CommentBox;
	public Image NextArrow;
	public int ChapterNumber;
	public Text ChapterText;
	public string CutsceneText1;
	public string CutsceneText2;
	public GameObject Bubble;
	public bool CutsceneStarted;
	public string CutsceneText3;
	public string CutsceneText4;
	public string CutsceneText5;
	public bool CutsceneEnd;
	public AudioSource music;
	public GameObject KillerColumn;
	public GameObject Ground1;
	public GameObject Ground2;
	public GameObject RedEgg;
	public GameObject BlueEgg;
	public GameObject GreenEgg;
	public bool Chapter1Completed;
	public GameObject Chapter2Cutscene;
	public Text CommentatorText;
	public GameObject RoyalNameBox;
	public GameObject SaveName;
	public string ChosenOneName;
	public Color BirdColor;
	public bool waitEndChapter2;
	public GameObject RedBird;
	public GameObject BlueBird;
	public GameObject GreenBird;










	// Use this for initialization
	void Start () {
		waitEndChapter2 = Settings.instance.waitEndChapter2;
		//SET MANUALLY FOR TESTING PURPOSES on chapter 2 COMMENT OUT WHEN DONE-----------------------------
		Settings.instance.StoryModeProgress=0;
		Settings.instance.ChosenOne = null;
		Settings.instance.Save ();

			//------------------------------------------------------





		Settings.instance.Load ();
		if (Settings.instance.StoryModeProgress == 0) {
			Settings.instance.StoryModeProgress++;
		}






			
		ChapterNumber = Settings.instance.StoryModeProgress;

		print (ChapterNumber);

		if (RoyalNameBox != null) {
			RoyalNameBox.GetComponent<InputField> ().characterValidation = InputField.CharacterValidation.Alphanumeric;
			RoyalNameBox.GetComponent<InputField> ().characterLimit = 8;

		}





		



			StartCoroutine (StartChapter ());
		





	

		
	}




	void Update(){
		
		if (CutsceneEnd== true && Input.GetMouseButtonDown (0) && ChapterNumber == 1) {

			EndCutscene ();
		}
		if (Flap.instance != null && Flap.instance.IsDead && ChapterNumber == 1) {
			Chapter1Completed = true;
			StartCoroutine(StartChapter2());
		
		}

		switch (ChapterNumber) {
		//CHAPTER 1
		case 1:
			if (CutsceneStarted == true && Input.GetMouseButtonDown (0)) {
				Bubble.SetActive (true);
				CommentatorText.text = CutsceneText2;
				StartCoroutine (RepeatFlash ());
				StartCoroutine (FinishCutscene ());

			}
			;
			break;

			//CHAPTER 2
		case 2:
			if (CutsceneStarted == true && Input.GetMouseButtonDown (0)) {
				shakeEggFast (BlueEgg);
				shakeEggFast (RedEgg);
				shakeEggFast (GreenEgg);
				CommentatorText.text = CutsceneText5;
				CutsceneStarted = false;
				StartCoroutine (RepeatFlash ());
				Settings.instance.ChoosingOne = true;
				Settings.instance.Save ();
				Settings.instance.Load ();

		

			}
			;
			break;


		}

	
		if (ChapterNumber==2 && Settings.instance.waitEndChapter2 == true) {


			StartCoroutine (NameRoyalCharacter ());
		}

		if (ChapterNumber == 3 && StoryMode.instance.preGame == false) {
		
			CommentBox.SetActive (false);
		
		}



		if (ChapterNumber == 3 && StoryMode.instance.score == 100) {
		
			Settings.instance.StoryModeProgress = 4;
			Settings.instance.Save ();
			ChapterNumber = 4;
			SceneManager.LoadScene ("Chapter4");
		}
	
	}















	//START CHAPTER STORY MODE ENTRY-----------------------------------------------------------------------
	IEnumerator StartChapter()
	{
		yield return new WaitForSeconds(1);
		if (ChapterNumber == 2) {
			ChapterText.text = "3 days later";
		
		}

		yield return new WaitForSeconds(1);
		FadeCutscene (Cutscene);
		yield return new WaitForSeconds(2);
		StartScene();

		yield return new WaitForSeconds(1);
		ShowCommentBox ();
	}


	public void FadeCutscene(GameObject cutscene){

		cutscene.GetComponent<Image>().CrossFadeAlpha(0.1f, 2.0f, false);
	}

	public void StartScene(){
		Destroy (Cutscene);
	
	
	}


	

	public void ShowCommentBox(){
		
		
		CommentBox.SetActive (true);
		if (ChapterNumber == 1) {
		
			StartCoroutine (StartScene1());
		}
		if (ChapterNumber == 2) {
			print ("Chapter 2");
			CommentatorText.text = CutsceneText4;
			CutsceneStarted = true;

			StartCoroutine(RepeatFlash());
		}
		if (ChapterNumber == 3) {
			switch (Settings.instance.ChosenOne) {
			case "RedEgg":
				RedBird.SetActive (true);
				StoryMode.instance.GameBird = RedBird;
				break;

			case "BlueEgg":
				BlueBird.SetActive (true);
				StoryMode.instance.GameBird = BlueBird;
				break;
			case "GreenEgg":
				GreenBird.SetActive (true);
				StoryMode.instance.GameBird = GreenBird;
				break;

 

			}
			CommentatorText.text = "Help " + Settings.instance.CharacterName + " " + "recon the area.";

		
		}
	
	
	}
		
	IEnumerator StartScene1(){
		StartCoroutine(RepeatFlash());
		CommentatorText.text = CutsceneText1;
		yield return new WaitForSeconds (2);
		CutsceneStarted = true;

	
	
	}


	public void shakeEggFast(GameObject egg){
	
		egg.GetComponent<Animator> ().SetTrigger ("fastShaking");
	}






	IEnumerator RepeatFlash()
	{
		NextArrow.CrossFadeAlpha(0.1f, 1.0f, false);
		yield return new WaitForSeconds(1);
		NextArrow.CrossFadeAlpha(1.0f, 1.0f, false);
		yield return new WaitForSeconds(1);
		NextArrow.CrossFadeAlpha(0.1f, 1.0f, false);
		yield return new WaitForSeconds(1);
		NextArrow.CrossFadeAlpha(1.0f, 1.0f, false);
		NextArrow.CrossFadeAlpha(0.1f, 1.0f, false);
		yield return new WaitForSeconds(1);
		NextArrow.CrossFadeAlpha(1.0f, 1.0f, false);
		yield return new WaitForSeconds(1);
		NextArrow.CrossFadeAlpha(0.1f, 1.0f, false);
		yield return new WaitForSeconds(1);
		NextArrow.CrossFadeAlpha(1.0f, 1.0f, false);
	}

	IEnumerator FinishCutscene()
	{
		switch (ChapterNumber) {
		//CHAPTER 1 
		case 1:
			yield return new WaitForSeconds (3);
			CommentatorText.text = CutsceneText3;
			CutsceneEnd = false;
			break;
			//CHAPTER 2
		case 2:
			yield return new WaitForSeconds (1);
			CutsceneEnd = true;
			EndCutscene ();

			break;

		}
		
			
		
	}
		
	IEnumerator StartChapter2()
	{
		yield return new WaitForSeconds (3);
		CutsceneStarted = false;
		Settings.instance.StoryModeProgress = 2;
		Settings.instance.Save ();

		SceneManager.LoadScene ("Chapter2");
	

	}

	IEnumerator NameRoyalCharacter()
	{
		if (Settings.instance.ChosenOne == "RedEgg") {
			BirdColor = Color.red;
		
		} else if (Settings.instance.ChosenOne == "BlueEgg") {
			BirdColor = Color.blue;
		
		} else if (Settings.instance.ChosenOne == "GreenEgg") {
		
			BirdColor = Color.green;
		
		}

		CommentatorText.text = "Congratulations! You've Hatched A Royal:" + Settings.instance.ChosenOne;
		//Settings.instance.ChosenOne = null;
		Settings.instance.Save ();
		Settings.instance.Load ();
		Settings.instance.waitEndChapter2 = false;
	
		yield return new WaitForSeconds (3);
		CommentatorText.text = "What Shall we name our Royal Bird?";
		RoyalNameBox.SetActive (true);
		Destroy (NextArrow);
		SaveName.SetActive (true);


	}

	public void EndCutscene(){



		if (ChapterNumber == 1) {
			Destroy (CommentBox);
			Destroy (Bubble);
			music.Stop ();
			StartScrolling (RedEgg);
			StartScrolling (BlueEgg);
			StartScrolling (GreenEgg);
			StartScrolling (Ground1);
			StartScrolling (Ground2);
			StartScrolling (KillerColumn);
		
			
		
		
		}
		if (ChapterNumber == 2) {
			
		
			Settings.instance.Load ();
			EndChapter2 ();


		
		}
	
	
	}

	public void StartScrolling(GameObject ScrollItem){
		ScrollItem.GetComponent<ScrollingObject>().enabled = true;
	
	
	}

	public void EndChapter2(){

	


			StartCoroutine (NameRoyalCharacter ());
	
	
		
	}
	public void SaveCharacterName(){
		
		if (RoyalNameBox.GetComponent<InputField> ().text.Length >= 1) {
			print ("Name Chosen");
			ChosenOneName = RoyalNameBox.GetComponent<InputField> ().text;
			Settings.instance.CharacterName = ChosenOneName;
			ChapterNumber = 3;
			Settings.instance.StoryModeProgress = 3;
			Settings.instance.Save ();
		} 
		StartChapter3 ();

	
	
	}

	public void StartChapter3(){
		Settings.instance.Load ();
		if (ChapterNumber == 3) {
			print ("Starting Chapter 3");
			SceneManager.LoadScene ("Chapter3");
		
		
		
		}
	
	
	}



}
