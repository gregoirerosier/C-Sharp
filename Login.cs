using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {

	public Text userEmail;
	public Text userPassword;
	public InputField email;
	public InputField password;
	public Button LoginButton;
	public Text OutputText;


	// Use this for initialization
	void Start () {
		email.characterValidation = InputField.CharacterValidation.EmailAddress;
		password.inputType = InputField.InputType.Password;
		password.characterLimit = 15;





	}

	// Update is called once per frame
	void Update () {
		if (password.text !="") {

			LoginButton.interactable = true;

		}

		if (OutputText.text.Contains("L")) {
			Settings.instance.Logged = true;
			Settings.instance.Email = email.text;
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




	public void LoginAccount(){

		string url = "http://beyondimagination.co.technology/signIn.php?password=" + password.text+"&email="+ email.text;
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));

		OutputText.text = www.text;

	}






}
