using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class Username : MonoBehaviour {

	// Use this for initialization
	public Text userName;

	public InputField UserName;

	public Button LoginButton;
	public Text OutputText;


	// Use this for initialization
	void Start () {
		
		UserName.characterLimit = 15;





	}

	// Update is called once per frame
	void Update () {
		if (UserName.text !="") {

			LoginButton.interactable = true;

		}

		if (OutputText.text.Contains("L")) {

			Settings.instance.userName = UserName.text;
			Settings.instance.Save ();
			SceneManager.LoadScene ("PlayOnline");


		}

	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			OutputText.text = www.text;





			Debug.Log("WWW Ok!: " + www.text);
		} 










		else {
			OutputText.text = "Network Error";
			Debug.Log("WWW Error: "+ www.error);
		}    
	}




	public void CreateUser(){

		string url = "http://beyondimagination.co.technology/journeys/username.php?userName=" + UserName.text+"&email="+ Settings.instance.Email;
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));

		OutputText.text = www.text;

	}




}
