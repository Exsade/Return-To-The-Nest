using UnityEngine;
using System.Collections;

public class Inst_Dest : MonoBehaviour {
	
	
	[SerializeField]
	GameObject barrier;
	
	[SerializeField]
	GameObject coin;

	[SerializeField]
	GameObject Gem;

	[SerializeField]
	GameObject Rocket;
	
	[SerializeField]
	GameObject AuraIcon;

	[SerializeField]
	GameObject MagnetIcon;

	[SerializeField]
	GameObject BoostIcon;

	
	public BirdMovement BirdMove;
	public BirdAdvance Pick;

	float RespTime = 2f;
	float MinRespTime = 0.8f;
	 //This is will down reduce  RespTime

	int RandomNumberY, RandomNumber;

	void Start () {
		StartCoroutine(CoinsAndBarriers ());
		StartCoroutine(Icons ());
		StartCoroutine(Rockets ());
	}
	
	
	IEnumerator CoinsAndBarriers() {

		yield return new WaitForSeconds(RespTime);

		if (Pick.BoostEffect == false && BirdMove.dead == false) {

			RandomNumberY = Random.Range (0, 3);
			RandomNumber = Random.Range (0, 2);
			
			float PosX = transform.position.x + 10f;

			if (RandomNumber == 1) {	//Inst barrier + coin
			
				if (RandomNumberY == 0) { //Inst barrier in top
			
					Instantiate (barrier, new Vector3 (PosX, 4.3f, 0), Quaternion.Euler (0, 0, 0));
					Instantiate (coin, new Vector3 (Random.Range (PosX - 1f, PosX + 1f), Random.Range (-2, 2.2f), -2), Quaternion.Euler (0, 0, 0));

				} else if (RandomNumberY == 1) { //Inst barrier + 2 coins in  middle
				
					Instantiate (barrier, new Vector3 (PosX, 0.75f, 0), Quaternion.Euler (0, 0, 90));

					Instantiate (coin, new Vector3 (PosX, Random.Range (5, 2.25f), -2), Quaternion.Euler (0, 0, 0));
					Instantiate (coin, new Vector3 (PosX, Random.Range (-3, -0.75f), -2), Quaternion.Euler (0, 0, 0));
				
				} else { //Inst barrier in bottom

					Instantiate (barrier, new Vector3 (PosX, -2.76f, 0), Quaternion.Euler (0, 0, 0));
					Instantiate (coin, new Vector3 (Random.Range (PosX - 1f, PosX + 1f), Random.Range (0.1f, 5), -2), Quaternion.Euler (0, 0, 0));

				}
			} 

			else {  //Inst only coin or BoostIcon or Gem
				RandomNumber = Random.Range (0, 100);
				if(RandomNumber < 95)
					Instantiate (coin, new Vector3 (Random.Range (PosX - 1f, PosX + 1f), Random.Range (-2, 4), -2), Quaternion.Euler (0, 0, 0));
				else if (RandomNumber < 99)
					Instantiate (BoostIcon, new Vector3 (Random.Range (PosX - 1f, PosX + 1f), Random.Range (-2, 4), -2), Quaternion.Euler (0, 0, 0));
				else
					Instantiate (Gem, new Vector3 (PosX, 1, -3), Quaternion.identity);
			}


			if (RespTime > MinRespTime) {
				RespTime -= 0.008f * BirdMove.forwardSpeed;
				Debug.Log (RespTime);
			} 
		}

		RepeatCAB();
	}

	
	IEnumerator Rockets() {
		yield return new WaitForSeconds (8);
		if (Pick.BoostEffect == false && BirdMove.dead == false) {

			float PosX = transform.position.x - 0.45f;
			Instantiate (Rocket, new Vector3 (PosX, Random.Range (-4f, 3.5f), -3), Quaternion.identity);
		}
		
		RepeatR ();
	}

	IEnumerator Icons() {
		yield return new WaitForSeconds (16);

		RandomNumber = Random.Range (0, 100);
		float PosX = transform.position.x + 6f;

		if (RandomNumber < 51)
			Instantiate (MagnetIcon, new Vector3 (PosX, 1, -3), Quaternion.identity);
		else 
			Instantiate (AuraIcon, new Vector3 (PosX, 1, -3), Quaternion.identity);

		RepeatI ();
	}

	void RepeatCAB () {
		StartCoroutine (CoinsAndBarriers ());
	}
	
	void RepeatI () {
		StartCoroutine (Icons ());
	}

	void RepeatR () {
		StartCoroutine (Rockets ());
	}
	
}
