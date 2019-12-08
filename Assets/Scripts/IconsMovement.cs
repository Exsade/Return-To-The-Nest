using UnityEngine;
using System.Collections;

public class IconsMovement : MonoBehaviour {

	Rigidbody2D Player_go;

	int Direction = 1;
	
	public float speed = 1f;

	void Start() {
		GameObject Player = GameObject.FindGameObjectWithTag ("Player");

		Player_go = Player.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		Vector3 pos = gameObject.transform.position;
		float vel = speed * Player_go.velocity.x;

		if (pos.y > 4) 
			Direction = -1;
		if (pos.y < -2f)
			Direction = 1;
		
		
		transform.Translate (Vector3.right * vel * Time.deltaTime);
		transform.Translate (Vector3.up * vel/2 * Time.deltaTime * Direction);
	}
}
