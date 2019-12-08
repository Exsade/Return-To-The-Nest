using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public GameObject Pause_Button, Pause_Panel;

	public bool paused = false;

	public void OnPause () {

		Pause_Button.SetActive(false);
		Pause_Panel.SetActive (true);
		Time.timeScale = 0;
		paused = true;
	}

	public void OnUnPause () {

		Pause_Button.SetActive (true);
		Pause_Panel.SetActive (false);
		Time.timeScale = 1;
		paused = false;
	}
	
}
