using UnityEngine;
using System.Collections;

public class RocketMovement : MonoBehaviour {

	Transform player;
	//Rigidbody2D playerRigid;

	public bool Warning = true;

	public float speed = 10f;	
	public float WarningIconSpeed = 1f; //Velocity of Warning icon movement

	float OffSetX;

	float yVelocity = 0f;

	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");

		if (player_go == null) {
			Debug.LogError ("Didnt find player");
			return;
		}

		player = player_go.transform;
	//	playerRigid = player_go.GetComponent<Rigidbody2D> ();

		OffSetX = transform.position.x - player.position.x;
	}
	

	void Update () {
		Vector3 pos = transform.position;

		if (Warning) {
			pos.x = player.position.x + OffSetX;
			pos.y = Mathf.SmoothDamp (pos.y, player.position.y, ref yVelocity, WarningIconSpeed);

			transform.position = pos;
		} 
		else {
			pos.x -= speed * Time.deltaTime;
			transform.position = pos;
		}

	}
}
