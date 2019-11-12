using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs : MonoBehaviour {

	public Rigidbody2D rb2d;
	public Animator anim;
	public GameObject bird;




	void Start(){
	
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	
	
	}

	void Update(){
		
	
	}

	void OnMouseDown(){
		Settings.instance.Load ();
		if (Settings.instance.ChoosingOne) {
			print ("MouseDown:"+ this.name);
			anim.SetTrigger ("hatched");
			bird.SetActive (true);

			Settings.instance.ChosenOne = this.name;
			Settings.instance.waitEndChapter2 = true;

			Settings.instance.Save ();
			Settings.instance.Load ();
			print (Settings.instance.waitEndChapter2);
		
		}
	
	}


	public void ShakeFast(){
	

			anim.SetTrigger ("shakeFast");
		}




}

