using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
	[Header("Set in Inspector")]
	public float	rotationsPerSecond = 0.1f;

	[Header("Set Dynamically")]
	public int 		levelShown = 0;

	Material		mat;

	void Start () {
		mat = GetComponent<Renderer> ().material;	
	}
	
	void Update () {
		// Read present power of protection field from object Hero
		int currLevel = Mathf.FloorToInt( Hero.S.shieldLevel);
		// If it is different from levelShown...
		if (levelShown != currLevel) {
			levelShown = currLevel;
			// Correct offset in texture in order to show the field with another power level'
			mat.mainTextureOffset = new Vector2(0.2f*levelShown, 0);
		}
		// Rotate field in each frame with constant velocity
		float rZ = -(rotationsPerSecond*Time.time*360)%360f;
		transform.rotation =Quaternion.Euler(0,0,rZ);
	}
}
