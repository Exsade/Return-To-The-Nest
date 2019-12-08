using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {


	void Start() {


	}

	void OnTriggerEnter2D(Collider2D collider) {

		Vector3 pos = collider.transform.position;


		if (collider.tag == "Rocket"){
			Destroy(collider.gameObject);
		}

	 	if (collider.tag == "Ground" || collider.tag == "Mountain")
			pos.x += 60;

		if ((collider.tag == "Coin")||(collider.tag == "Barrier"))
			Destroy(collider.gameObject);

		if (collider.tag == "drop_by_more")
		    pos.x += 350;

		if (collider.tag == "Fog")
			pos.x += 500;

		collider.transform.position = pos;
	}
}