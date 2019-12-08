using UnityEngine;
using System.Collections;

public class PickMoney : MonoBehaviour {
		
	public PlayerStats Took;

	public AudioClip Pick;

	void OnTriggerEnter2D(Collider2D collider) {
		
		if (collider.tag == "Player") {
			if (gameObject.tag == "Coin") {
				Took.Coins++;

				gameObject.GetComponent<AudioSource> ().clip = Pick;
				gameObject.GetComponent<AudioSource> ().Play ();

				Destroy (gameObject, 0.1f);
			} else {
				Took.Gems++;
				
				gameObject.GetComponent<AudioSource> ().clip = Pick;
				gameObject.GetComponent<AudioSource> ().Play ();
				
				Destroy (gameObject, 0.1f);
			}
		}
	}
}
