using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flap : MonoBehaviour {
	
	public static Flap instance;
	private Animator anim;
	public AudioSource Fly;
	private Rigidbody2D rb2d;
	public bool IsFlying =true;
	public float upForce = 200f;
	public AudioSource Dead;
	public bool IsDead;
	public string test ="Do you see this string";


	void Awake() {

		if (instance == null) {

			instance = this;
		} else if (instance != null) {


			Destroy (gameObject);

		}
	}


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	
			InvokeRepeating("Flapping", 0.0f, 0.8f);



		


	}

	
	// Update is called once per frame
	void Update () {
		if (IsDead) {
		
			CancelInvoke();
		}
	

		
	}

	public void Flapping(){
		var startPosition = transform.position;


		rb2d.velocity = Vector2.zero;
		rb2d.AddForce (new Vector2 (0, upForce));
		anim.SetTrigger ("Flap");
		if (Settings.instance.SoundFxOn ) {
			Fly.Play ();
		}
		 


	}


	void OnCollisionEnter2D(){

		rb2d.velocity = Vector2.zero;
		print ("Collision");

		Dead.Play ();

		anim.SetTrigger ("Die");

		IsDead = true;


	}


}

