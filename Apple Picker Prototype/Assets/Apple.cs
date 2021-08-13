using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
	public static float 	bottomY = -20f;

	void Update () {
		// Delete apple if it is lower then bottom
		if (transform.position.y < bottomY ) {
			Destroy (this.gameObject);

			// Get a link of the component ApplePicker of the Main Camera
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
			// Call public method AppleDestroyed() from apScript
			apScript.AppleDestroyed();
		}
	}
}
