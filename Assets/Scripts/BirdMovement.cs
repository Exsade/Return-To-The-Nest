using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BirdMovement : MonoBehaviour {
	
	[SerializeField]
	AudioClip FlapHit;
	
	public GameObject Aura;
	public BirdAdvance Pick;
	
	public PlayerStats score;
	public Pause OnPause;
	
	public GameObject ResPanel;
	public bool dead = false;
	public bool falls = false;
	
	public float forwardSpeed = 6.5f;
	public float flapSpeed = 550f;
	float angle = 0;
	
	bool didFlap = false;
	
	Animator animator;
	
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();
		
		gameObject.GetComponent<AudioSource>().clip = FlapHit;
	}
	
	
	void Update () {
		if(Input.GetMouseButtonDown(0) && OnPause.paused == false ) {
			didFlap = true;
		}
		
		score.Distance +=Time.timeScale * GetComponent<Rigidbody2D>().velocity.x / 100;



	}
	
	void FixedUpdate () {
		if (!dead) {
			
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * forwardSpeed);


			forwardSpeed += 0.0015f;
			GetComponent<Rigidbody2D>().gravityScale += 0.00003f;
			
			if (didFlap) {
				GetComponent<Rigidbody2D> ().AddForce (Vector2.up * flapSpeed);
				
				animator.SetTrigger ("DoFlap");
				
				gameObject.GetComponent<AudioSource> ().Play ();
				
				didFlap = false;
			}
			
			
			if (GetComponent<Rigidbody2D> ().velocity.y < 0) {
				angle = Mathf.Lerp (0, -15, -GetComponent<Rigidbody2D> ().velocity.y / 2f);
				transform.rotation = Quaternion.Euler (0, 0, angle);
			}
			
			if (GetComponent<Rigidbody2D> ().velocity.y > 0) {
				angle = Mathf.Lerp (0, 10, GetComponent<Rigidbody2D> ().velocity.y / 2f);
				transform.rotation = Quaternion.Euler (0, 0, angle);
			}
		}

	}
	
	void OnCollisionEnter2D(Collision2D collision) {	
		
		if((collision.gameObject.tag == "Ground")&&(!falls)) {
			falls = true;
		}
		

		if (collision.gameObject.tag != "TopBlock" && dead == false) {
			animator.SetTrigger ("Death"); 
			gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
			dead = true;
			ResPanel.SetActive (true);
			Aura.SetActive (false);
			Pick.AuraPicked = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		
		if ((collider.gameObject.tag == "Rocket")&&(Pick.AuraPicked == false)&&(Pick.BoostEffect == false) && (dead == false)) {
			animator.SetTrigger ("Death"); 
			gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
			dead = true;
			ResPanel.SetActive (true);
		} 
	}
}