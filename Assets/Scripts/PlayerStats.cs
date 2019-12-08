using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour {
	
	public Text ScoreText, CoinsText;
	
	public BirdMovement dead;
	
	public float Distance = 0;
	public int Coins = 0;
	public int Gems = 0;
	
	bool Saved = false;
	
	int LastCoinsScore;
	int LastGemsScore;
	float LastHighScore;
	
	void Update () {
		ScoreText.text = Mathf.Ceil(Distance) + " m";
		CoinsText.text = Coins + "";
		
		if (dead.dead == true && Saved == false) 
			SavePlayerStats ();
	}
	
	void SavePlayerStats () {
		//Cheking for saves
		if (PlayerPrefs.HasKey ("CoinsScore"))
			LastCoinsScore = PlayerPrefs.GetInt ("CoinsScore");
		else
			LastCoinsScore = 0;
		
		if (PlayerPrefs.HasKey ("GemsScore"))
			LastGemsScore = PlayerPrefs.GetInt ("GemsScore");
		else
			LastGemsScore = 0;

		if (PlayerPrefs.HasKey ("HighScore"))
			LastHighScore = PlayerPrefs.GetFloat ("HighScore");
		else
			LastHighScore = 0;


		//Saving
		if (LastHighScore < Mathf.Ceil (Distance))
			PlayerPrefs.SetFloat ("HighScore", Mathf.Ceil (Distance));
		
		PlayerPrefs.SetInt ("CoinsScore", LastCoinsScore + Coins);
		PlayerPrefs.SetInt ("GemsScore", LastGemsScore + Gems);
		
		PlayerPrefs.Save ();
		Saved = true;
	}
}

