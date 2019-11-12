using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class CreateAccount : MonoBehaviour {
	public Text userEmail;
	public Text userPassword;
	public Text userConfirmPassword;
	public InputField email;
	public InputField password;
	public InputField confirmPassword;


	public Toggle terms;
	public Button saveButton;
	public Text OutputText;


	// Use this for initialization
	void Start () {
		email.characterValidation = InputField.CharacterValidation.EmailAddress;
		password.inputType = InputField.InputType.Password;
		confirmPassword.inputType = InputField.InputType.Password;
		password.characterLimit = 15;
		confirmPassword.characterLimit = 15;

		if(Settings.instance.Email != null){
			email.text = Settings.instance.Email;


		}

		
	}
	
	// Update is called once per frame
	void Update () {
		if (userEmail && userPassword && userConfirmPassword != null & terms.isOn == true ) {
			
			saveButton.interactable = true;
		
		}
		
		if (OutputText.text.Contains("_")) {


			SceneManager.LoadScene ("Login");


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




	public void SaveAccount(){
		
		string url = "http://beyondimagination.co.technology/signUp.php?confirmPassword="+confirmPassword.text+"&password=" + password.text+"&email="+ email.text;
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));



	}

















}
