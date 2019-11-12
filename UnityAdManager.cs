using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour {
	public static UnityAdManager instance;

	// Use this for initialization

	void Awake(){

		if (instance == null) {
			instance = this;

			DontDestroyOnLoad (this.gameObject);

		}  else {

			Destroy (this);

		}

	}
	void Start () {
		Settings.instance.AdCount = 0;
		Settings.instance.Save ();

	}

	// Update is called once per frame
	void Update () {

	}

	public void ShowAd(){
		Settings.instance.Load ();
		
		if (Settings.instance.AdCount == 2) {
				//Show Add
				if (Advertisement.IsReady ("video")) {
					Advertisement.Show ("video");
				Settings.instance.AdCount = 0;
				Settings.instance.Save ();
				}

			}  else {

			Settings.instance.AdCount = Settings.instance.AdCount + 1;
			Settings.instance.Save ();

			}
	


		} 
	




}

