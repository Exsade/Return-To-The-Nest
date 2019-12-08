using UnityEngine;
using System.Collections;

public class RocketAdvance : MonoBehaviour {

	public RocketMovement Move;

	public AudioClip Warning;
	public AudioClip RocketFly;
	public AudioClip TouchRocket;

	[SerializeField]
	float TimeOfWarning = 3f;

	Animator animator;
	
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();
		
		if(animator == null) 
			Debug.LogError("Didn't find animator!");

		gameObject.GetComponent<AudioSource> ().clip = Warning;
		gameObject.GetComponent<AudioSource> ().spatialBlend = 0; //3D sound is off
		gameObject.GetComponent<AudioSource> ().volume = 0.4f;
		gameObject.GetComponent<AudioSource> ().pitch = 0.8f;
		gameObject.GetComponent<AudioSource> ().Play ();
	}

	void Update() {
		if (TimeOfWarning > 0)
			TimeOfWarning -= Time.deltaTime;
		else if (Move.Warning) {
			animator.SetTrigger ("Start");
			gameObject.GetComponent<AudioSource> ().clip = RocketFly;
			gameObject.GetComponent<AudioSource> ().spatialBlend = 1; //3D sound is off
			gameObject.GetComponent<AudioSource> ().volume = 1f;
			gameObject.GetComponent<AudioSource> ().pitch = 1.3f;
			gameObject.GetComponent<AudioSource> ().Play ();
			Move.Warning = false;
		}
	} 
	
	void OnTriggerEnter2D(Collider2D collider) {

		if (collider.tag == "Player") {
			animator.SetTrigger ("Bang");

			gameObject.GetComponent<AudioSource> ().clip = TouchRocket;
			gameObject.GetComponent<AudioSource> ().loop = false;
			gameObject.GetComponent<AudioSource> ().Play ();
			
			Destroy (gameObject, 0.5f);
		}
	}
}
