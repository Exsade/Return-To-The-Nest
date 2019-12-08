using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetPlayerPrefsForMenu : MonoBehaviour {
	
	public Text HighScoreText;
	public Text CoinsText;
	public Text GemsText;


	void Start(){
		StartCoroutine (ChekForUpdate ());
	}

	IEnumerator ChekForUpdate() {
		
		yield return new WaitForSeconds(0.5f);
		
		if (PlayerPrefs.HasKey ("HighScore"))
			HighScoreText.text = PlayerPrefs.GetFloat ("HighScore") + "";
		else 
			HighScoreText.text = "0";
		
		if (PlayerPrefs.HasKey ("CoinsScore"))
			CoinsText.text = PlayerPrefs.GetInt ("CoinsScore") + "";
		else
			CoinsText.text = "0";
		
		if (PlayerPrefs.HasKey ("GemsScore"))
			GemsText.text = PlayerPrefs.GetInt ("GemsScore") + "";
		else {
			PlayerPrefs.SetInt ("GemsScore", 5);
			PlayerPrefs.Save ();
			GemsText.text = "5";
		}

		Repeat ();
	}

	void Repeat() {
		StartCoroutine (ChekForUpdate ());
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.D)) {
			PlayerPrefs.DeleteAll();
			PlayerPrefs.Save();
		}
	}
}