using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {
	public Texture2D fadeOutTexture; // the texture that will overlay the screen. This can be a black image or a loading graphic
	public float fadeSpeed = 0.8f;  // the fading speed
	public float scrollSpeed = - 1.5f;
	public static MainMenu instance;
	private int drawDepth = -1000;  // the texture's order in the draw hierarchy: a low number means it renders on top
	private float alpha = 1.0f;   // the texture's alpha value between 0 and 1
	private int fadeDir = -1;   // the direction to fade: in = -1 or out = 1
	//public Text StoreButton;
	public GameObject Warning;

	IEnumerator ShowWarning()
	{
		Warning.SetActive (true);
		yield return new WaitForSeconds (2);
		Warning.SetActive (false);




	}
	// Use this for initialization
	void Start () {
		//if (Settings.instance.Logged) {
			//StoreButton.text = "Store";
		
		
		//}

	//	if (Settings.instance.Email != null && Settings.instance.Logged != true) {
		
		//	StoreButton.text = "Login";
		//}

	}

	// Update is called once per frame
	void Update () {

	}

	void Awake() {

		if (instance == null) {

			instance = this;
		} else if (instance != null) {


			Destroy (gameObject);

		}
	}


	public void pleaseShowWarning(){
		//Warning.SetActive (true);
		StartCoroutine(ShowWarning());
	
	}


	public void openSinglePlayerMenu(){


		BeginFade(-1);  // call the fade in function



		SceneManager.LoadScene ("SinglePlayerMenu");

	}
	public void openOnlineMenu(){


		BeginFade(-1);  // call the fade in function
		//ShowWarning();
		SceneManager.LoadScene ("OnlineMenu");

	}

	public void openSettings(){
		print ("Opening Settings Scene");

		BeginFade(-1);  // call the fade in function

		SceneManager.LoadScene ("Settings");

	}




	void OnGUI()
	{
		// fade out/in the alpha value using a direction, a speed and Time.deltaTime to convert the operation to seconds
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		// force (clamp) the number to be between 0 and 1 because GUI.color uses Alpha values between 0 and 1
		alpha = Mathf.Clamp01(alpha);

		// set color of our GUI (in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;                // make the black texture render on top (drawn last)
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);  // draw the texture to fit the entire screen area
	}





	// sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1
	public float BeginFade (int direction)
	{
		fadeDir = direction;
		return (fadeSpeed);
	}


}
