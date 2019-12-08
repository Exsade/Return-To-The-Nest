using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResManager : MonoBehaviour {

	public Text GemsAmount;
	public Text GemsCost;
	public GameObject Resurrection;

	int Cost = 1;
	int Gems;

	void OnEnable () {
		if (PlayerPrefs.HasKey ("GemsScore"))
			Gems = PlayerPrefs.GetInt ("GemsScore");
		else
			Gems = 5;

		GemsAmount.text = Gems + "";
		GemsCost.text = Cost + "";
	}
	

	public void Res () {

		if (Cost < Gems + 1) {

			Resurrection.SetActive (true);
		
			PlayerPrefs.SetInt ("GemsScore", Gems - Cost);
			PlayerPrefs.Save();

			Cost *= 2;

			gameObject.SetActive(false);
		}
	}
}
