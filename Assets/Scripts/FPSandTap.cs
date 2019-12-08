using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSandTap : MonoBehaviour {

	public Text Fps;

	float fps=0;
	float Timer=0;
	float NextSecond=1;

	public GameObject TapToFly;

	void Start () { 
		if (!PlayerPrefs.HasKey ("PlayedBefor")) {
			TapToFly.SetActive (true);

			PlayerPrefs.SetInt("PlayedBefor", 1);
			PlayerPrefs.Save ();

			Time.timeScale = 0;
		}
	}

}
