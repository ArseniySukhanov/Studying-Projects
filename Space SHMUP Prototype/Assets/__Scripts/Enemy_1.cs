using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy {

	[Header("Set in Inspector: Enemy_1")]
	// Period of sin in seconds
	public float	waveFrequency = 2;
	// Width of sin in meters
	public float	waveWidth = 4;
	public float	waveRotY = 45;

	private float	x0; // Start value of x coordinate
	private float	birthTime;


	// Method Start is not used by superclass Enemy
	void Start () {
		x0 = pos.x;	

		birthTime = Time.time;
	}

	public override void Move()	{
		Vector3 tempPos = pos;
		float age = Time.time - birthTime;
		float theta = Mathf.PI * 2 * age / waveFrequency;
		float sin = Mathf.Sin (theta);
		tempPos.x = x0 + waveWidth * sin;
		pos = tempPos;

		Vector3 rot = new Vector3 (0, sin * waveRotY, 0);
		this.transform.rotation = Quaternion.Euler (rot);

		base.Move ();
	}
}
