using UnityEngine;
using System.Collections;

public class MagnetForce : MonoBehaviour {
	
	public BirdAdvance Pick;
	
	float smoothTime;
	float yVelocity = 0f;
	Transform BirdPos;
	
	void Start () {
		GameObject Bird = GameObject.FindGameObjectWithTag("Player");
		
		if (Bird == null)
			Debug.LogError ("Didnt find Player");
		
		BirdPos = Bird.GetComponent<Transform> ();
	}
	
	void FixedUpdate () {
		
		if (Pick.MagnetPicked) {
			
			float spacing = Mathf.Abs (BirdPos.position.x - transform.position.x);
			
			smoothTime = spacing / 7;
			
			if ( spacing < 10) {
				float newPositionY = Mathf.SmoothDamp (transform.position.y, BirdPos.position.y, ref yVelocity, smoothTime);
				transform.position = new Vector3 (transform.position.x - 0.05f, newPositionY, transform.position.z);
			}
			

		}
	}
}