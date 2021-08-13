using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
	static public int score = 1000;

	void Awake() {
		// If value HighScore already exists in PlayerPrefs, read it
		if (PlayerPrefs.HasKey ("HighScore")) {
			score = PlayerPrefs.GetInt ("HighScore");
		}
		// Save HighScore
		PlayerPrefs.SetInt ("HighScore", score);
	}

	void Update () {
		Text gt = this.GetComponent<Text> ();
		gt.text = "High Score: " + score;
		// Update High Score in PlayerPrefs, if necessary
		if (score > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", score);
		}
	}
}
