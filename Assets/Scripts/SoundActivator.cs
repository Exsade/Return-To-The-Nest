using UnityEngine;
using System.Collections;

public class SoundActivator : MonoBehaviour {

	public BirdMovement Move;

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player" && Move.falls == false)
			gameObject.GetComponent<AudioSource> ().Play ();
	}
}
