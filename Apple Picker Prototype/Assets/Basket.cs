using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {
	[Header("Set Dynamically")]
	public Text 			scoreGT;

	void Start(){
		// Get a link of game object ScoreCounter
		GameObject scoreGO = GameObject.Find("ScoreCounter");
		// Get component Text of the game object
		scoreGT = scoreGO.GetComponent<Text>();
		// Install start score equal 0
		scoreGT.text = "0";
	}

	void Update () {
		// Take present mouse position
		Vector3 mousePos2D = Input.mousePosition;

		mousePos2D.z = -Camera.main.transform.position.z;

		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void OnCollisionEnter( Collision coll ) {
		// Find apple, catched by basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);

			// Transform text in scoreGT into integer value
			int score = int.Parse( scoreGT.text );
			// Add score for an apple
			score += 100;
			// Transform score value backwards in string and show it on screen
			scoreGT.text = score.ToString();
			//Remember highest score
			if (score > HighScore.score) {
				HighScore.score = score;
			}
		}
	}
}
