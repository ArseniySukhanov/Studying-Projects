using System.Collections;
using UnityEngine;

public class FollowCam : MonoBehaviour {
	static public GameObject POI; // Link on object which is interesting for us

	public float 			easing = 0.05f;
	public Vector2			minXY = Vector2.zero;

	[Header("Set Dynamically")]
	public float			camZ; // Desired z coordinate of camera

	void Awake(){
		camZ = this.transform.position.z;
	}
	
	void FixedUpdate () {
//		if (POI == null)
//			return;				// Check if the object exists
//
//		// Gather position of the object
//		Vector3 destination = POI.transform.position;

		Vector3 destination;
		// If there is not an object interesting for us, return P:[0, 0, 0]
		if (POI == null) {
			destination = Vector3.zero;
		} else {
			// Get position of the object
			destination = POI.transform.position;
			// If the object - projectile, check, that it stopped
			if (POI.tag == "Projectile") {
				// If it is not moving
				if (POI.GetComponent<Rigidbody> ().IsSleeping ()) {
					// Return original settings of camera's field of view
					POI = null;
					// in next frame
					return;
				}
			}
		}

		// Restrict X and Y by minimal values
		destination.x = Mathf.Max( minXY.x, destination.x);
		destination.y = Mathf.Max( minXY.y, destination.y);
		// Find a point between present camera's displacement and destination
		destination = Vector3.Lerp(transform.position, destination, easing);
		// Forcibly install destination.z value equal to camZ, in order to move camera along
		destination.z = camZ;
		// Displace camera into destination position
		transform.position = destination;
		// Change size of orthographicSize, in order to ground being visible
		Camera.main.orthographicSize = destination.y + 10;
	}
}
