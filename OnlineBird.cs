using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class OnlineBird : NetworkBehaviour {
	[System.Serializable]
	public class ToggleEvent : UnityEvent<bool>{}



	[SerializeField] ToggleEvent onToggleShared;
	[SerializeField] ToggleEvent onToggleRemote;
	[SerializeField] ToggleEvent onToggleLocal;
	private Animator anim;
	public AudioSource Fly;
	private Rigidbody2D rb2d;
	public bool IsFlying =true;
	public float upForce = 200f;
	public AudioSource Dead;
	public bool IsDead;
	public string test ="Do you see this string";
	public GameObject player1;





	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		InvokeRepeating("Flapping", 0.0f, 0.8f);

		if (!isLocalPlayer) {
			print ("wtf");
		}


		EnablePlayer ();


	}

	void DisablePlayer(){
		onToggleShared.Invoke (false);
		if (isLocalPlayer) {
			onToggleLocal.Invoke (false);
		} else {

			onToggleRemote.Invoke (false);
		}
	}

	void EnablePlayer(){
		onToggleShared.Invoke (true);
		if (isLocalPlayer) {
			onToggleLocal.Invoke (true);
		} else {
		
			onToggleRemote.Invoke (true);
		}
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

