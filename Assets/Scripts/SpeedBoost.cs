using UnityEngine;
using System.Collections;

public class SpeedBoost : MonoBehaviour {

	[SerializeField]
	GameObject Bird;

	[SerializeField]
	GameObject Wind;

	public BirdMovement Movement;
	public BirdAdvance Pick;


	float LastForwardSpeed;
	float LastFlapSpeed;
	float LastGravityScale;

	float NewPositionY;
	float smoothTime = 0.4f;
	float yVelocity = 0f;

	public bool EffectIsComplate = false;
	float TimeOfHighestSpeed = 2f;
	float TimeOfCleanMap = 2f;

	void OnEnable () {

		if (Pick.BoostEffect) {

			Wind.SetActive(true);

			LastForwardSpeed = Movement.forwardSpeed;
			LastFlapSpeed = Movement.flapSpeed;
			LastGravityScale = Bird.GetComponent<Rigidbody2D>().gravityScale;

			Bird.GetComponent<CircleCollider2D> ().isTrigger = true;

			Bird.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
		//	Bird.GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.None;

			Movement.forwardSpeed = 100f;
			Movement.flapSpeed = 20f;

		}

	}

	void FixedUpdate () {
		if (Pick.BoostEffect) {

			if (!EffectIsComplate) {

				NewPositionY = Mathf.SmoothDamp (Bird.transform.position.y, 3f, ref yVelocity, smoothTime);
				Bird.transform.position = new Vector3(Bird.transform.position.x, NewPositionY, Bird.transform.position.z);

				if (TimeOfHighestSpeed > 0)
					TimeOfHighestSpeed -= Time.deltaTime;

				else {

					if (Movement.forwardSpeed > LastForwardSpeed)
						Movement.forwardSpeed -= Movement.forwardSpeed * Time.deltaTime;

					else {
						TimeOfHighestSpeed = 1.5f;

						Movement.forwardSpeed = LastForwardSpeed;
						Movement.flapSpeed = LastFlapSpeed;
						Bird.GetComponent<Rigidbody2D>().gravityScale = LastGravityScale;

						Bird.GetComponent<CircleCollider2D> ().isTrigger = false;
						Wind.SetActive(false);
						EffectIsComplate = true;
					}
				}
			}

			else {
				if (TimeOfCleanMap > 0) 
					TimeOfCleanMap -= Time.deltaTime;

				if (TimeOfCleanMap < 0) {
					TimeOfCleanMap = 2;

					EffectIsComplate = false;
					Pick.BoostEffect = false;
			//		Bird.GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.Interpolate;
					gameObject.SetActive(false);
				}

			}

		}

	}
}
