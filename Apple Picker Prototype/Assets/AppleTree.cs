using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
	[Header("Set in Inspector")]
	// Template for apples' creation
	public GameObject 	applePrefab;

	// Speed of appletree's movement
	public float		speed = 1f;

	// Distance on which direction of appletree movement should be changed;
	public float		leftAndRightEdge = 10f;

	// Possobility of random movement's direction change
	public float 		chanceToChangeDirections = 0.1f;

	// Apple creation frequency
	public float 		secondsBetweenAppleDrops = 1f;

	void Start () {
		// Throw apples once in a second
		Invoke( "DropApple", 2f);
	}

	void Update () {
		// Simple movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		// Direction change
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed);
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed);
		}
	}

	void FixedUpdate () {
		// Random direction change
		if (Random.value < chanceToChangeDirections) {
			speed *= -1;
		}
	}

	void DropApple() {
		GameObject apple = Instantiate<GameObject> (applePrefab);
		apple.transform.position = transform.position;
		Invoke ("DropApple", secondsBetweenAppleDrops);
	}
}
