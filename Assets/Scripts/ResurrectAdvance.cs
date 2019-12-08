using UnityEngine;
using System.Collections;

public class ResurrectAdvance : MonoBehaviour {
	
	public GameObject Player;
	public BirdMovement Dead;

	Animator BirdResAnim;
	

	void OnEnable () {

		BirdResAnim = Player.GetComponentInChildren<Animator> ();

		if (BirdResAnim == null)
			Debug.LogError ("Didnt find anim");

		Player.GetComponent<Rigidbody2D> ().isKinematic = true;
	}
	
	void Update () {

		Vector3 Pos = Player.transform.position;

		//Ressurection process

			if (Pos.y < 3f) {
				Pos += Vector3.up * 3f * Time.deltaTime;
				Player.transform.position = Pos;
			} 
			else {
				Player.transform.rotation = Quaternion.Euler (0, 0, 0); 
				BirdResAnim.SetTrigger ("DoRes");
				Dead.falls = false;
				Dead.dead = false;

				Player.GetComponent<Rigidbody2D> ().isKinematic = false;
				Player.GetComponent<Rigidbody2D> ().freezeRotation = false;

				GameObject[] Barriers = GameObject.FindGameObjectsWithTag("Barrier");
				GameObject[] Coins = 	GameObject.FindGameObjectsWithTag("Coin");	

				foreach (GameObject Bar in Barriers)
				Bar.SetActive(false);
				
				foreach(GameObject Coin in Coins)
				Coin.SetActive(false);
				
				gameObject.SetActive (false);
			}
		
	}
}
