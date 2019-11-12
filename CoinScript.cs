using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {

		transform.Rotate (new Vector3 (0,90,0) * Time.deltaTime);

	}
	private void OnTriggerEnter2D (Collider2D other){

		if (other.GetComponent<Bird> () != null) {

			Destroy (gameObject);
			ArcadeControl.instance.CoinScored ();

		}
	}

}
