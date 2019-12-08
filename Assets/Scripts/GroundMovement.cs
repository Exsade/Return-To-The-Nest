using UnityEngine;
using System.Collections;

public class GroundMovement : MonoBehaviour {

	public float speed = 0.5f;
	public SpeedBoost Effect;
	public BirdAdvance Pick;

	Rigidbody2D player;

	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		
		if (player_go == null) {
			Debug.LogError ("Couldn't find an object with tag 'Player'!");
			return;
		}
		
		player = player_go.GetComponent<Rigidbody2D>();
	
	}

	void FixedUpdate () {
			float vel = player.velocity.x * speed;
			transform.Translate (Vector3.right * vel * Time.deltaTime);

	}

	
}
	

