using UnityEngine;
using System.Collections;

public class BirdAdvance : MonoBehaviour {
	
	[SerializeField]
	GameObject Aura;
	[SerializeField]
	GameObject MagnetEffect;
	[SerializeField]
	GameObject SpeedBoost;



	public bool AuraPicked = false;
	public bool MagnetPicked = false;
	public bool BoostEffect = false;
	
	float TimeOfEffect;
	int Breaks;

	public Sprite[] AuraSprites = new Sprite[4];

	void Update () {
		if (!MagnetPicked)
			MagnetEffect.SetActive (false);

		else {
			if (TimeOfEffect > 0)
				TimeOfEffect -= Time.deltaTime;
			else 
				MagnetPicked = false;
		}

	}
	
	
	void OnTriggerEnter2D (Collider2D collider) {
		
		if (collider.tag == "AuraIcon") {
			if (!AuraPicked) {
				int selectedShield = PlayerPrefs.GetInt ("SelectedShield");
				if (selectedShield == 0){
					Breaks = 1;
					Aura.GetComponent<SpriteRenderer>().sprite = AuraSprites[0];
				}else {
					Breaks = selectedShield;
					Aura.GetComponent<SpriteRenderer>().sprite = AuraSprites[selectedShield];
				}
			}

			Aura.SetActive (true);
			collider.gameObject.GetComponent<AudioSource>().Play ();
			AuraPicked = true;
			Destroy (collider.gameObject, 0.1f);
		}
		
		if (collider.tag == "Rocket" && AuraPicked == true && BoostEffect == false) {
			if(Breaks > 1)
				Breaks--;
			else{
			Aura.SetActive (false);
			AuraPicked = false;
			}
		}
		
		if (collider.tag == "MagnetIcon") {
			MagnetEffect.SetActive(true);
			MagnetPicked = true;
			collider.gameObject.GetComponent<AudioSource>().Play ();
			Destroy (collider.gameObject, 0.1f);

			if(PlayerPrefs.HasKey("SelectedMagnet")) {
				if(PlayerPrefs.GetInt("SelectedMagnet") == 4)
					TimeOfEffect = 10;
				else if (PlayerPrefs.GetInt("SelectedMagnet") == 5)
					TimeOfEffect = 15;
				else 
					TimeOfEffect = 20;
				}
			else
				TimeOfEffect = 10;

			Debug.Log ("TimeOfMagnetEffect: " + TimeOfEffect);
		}

		if (collider.tag == "BoostIcon") {
			BoostEffect = true;
			SpeedBoost.SetActive (true);
			collider.gameObject.GetComponent<AudioSource> ().Play ();
			Destroy (collider.gameObject, 0.1f);
		}
	} 
}
