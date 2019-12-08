using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {
	
	// Update is called once per frame
	public void ChangeScene (string LoadLevel1) {
		FadeInOut.sceneEnd = true;
		FadeInOut.nextLevel = LoadLevel1;
		Time.timeScale = 1;

	}
	
}
