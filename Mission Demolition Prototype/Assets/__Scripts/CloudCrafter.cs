using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCrafter : MonoBehaviour {
	[Header("Set in Inspector")]
	public int 		numClouds = 40;		// Number of clouds
	public GameObject	cloudPrefab;		// Cloud's template
	public Vector3		cloudPosMin = new Vector3(-50, -5, 10);
	public Vector3 		cloudPosMax = new Vector3 (150, 100, 10);
	public float 		cloudScaleMin = 1;	// Minimal scale of each cloud
	public float		cloudScaleMax = 3;	// Maximal scale of each cloud
	public float		cloudSpeedMult = 0.5f;	// Coefficient of cloud's speed

	private GameObject[] cloudInstances;

	void Awake() {
		// Create massive for keeping of every cloud's copy
		cloudInstances = new GameObject[numClouds];
		// Find parent game object of CloudAnchor
		GameObject anchor = GameObject.Find ("CloudAnchor");
		// Create preassigned amount of clouds in cycle
		GameObject cloud;
		for (int i = 0; i < numClouds; i++) {
			// Create a copy of cloudPrefab;
			cloud = Instantiate<GameObject> (cloudPrefab);
			// choose displacement of cloud
			Vector3 cPos = Vector3.zero;
			cPos.x = Random.Range (cloudPosMin.x, cloudPosMax.x);
			cPos.y = Random.Range (cloudPosMin.y, cloudPosMax.y);
			// Rescale cloud
			float scaleU = Random.value;
			float scaleVal = Mathf.Lerp (cloudScaleMin, cloudScaleMax, scaleU);
			// Less clouds (with less value scaleU) should be closer to ground
			cPos.y = Mathf.Lerp (cloudPosMin.y, cPos.y, scaleU);
			// Less clouds should be farther
			cPos.z = 100 - 90 * scaleU;
			// Apply the values of coordinates and scale to cloud
			cloud.transform.position = cPos;
			cloud.transform.localScale = Vector3.one * scaleVal;
			// Make the cloud a child of anchor
			cloud.transform.SetParent (anchor.transform);
			// Add the cloud into massive cloudInstances
			cloudInstances [i] = cloud;
		}
	}
	
	void Update () {
		// go through all created clouds in cycle
		foreach (GameObject cloud in cloudInstances) {
			//Get scale and coordinates of the cloud
			float scaleVal = cloud.transform.localScale.x;
			Vector3 cPos = cloud.transform.position;
			// Increase speed for closer clouds
			cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;
			// If cloud moved to far in left direction 
			if (cPos.x <= cloudPosMin.x) {
				// Move it far in right direction
				cPos.x = cloudPosMax.x;
			}
			// Apply new coordinates to cloud
			cloud.transform.position = cPos;
		}
	}
}
