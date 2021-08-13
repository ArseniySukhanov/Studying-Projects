using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour {
	private GameObject		sword;
	private Dray			dray;
	
	void Start () {
		sword = transform.Find("Sword").gameObject;
		dray = transform.parent.GetComponent<Dray>();
		// Deactivate sword
		sword.SetActive(false);
	}
	
	void Update () {
		transform.rotation= Quaternion.Euler( 0, 0, 90*dray.facing);
		transform.localScale= new Vector3 (1, 1-2 * (dray.facing/2), 1);
		sword.SetActive(dray.mode == Dray.eMode.attack);
	}
}
