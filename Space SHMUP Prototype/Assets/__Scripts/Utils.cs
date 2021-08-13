using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

//======================= Functions for work with materials ========================\\

	// Returns list of all materials inside this game object and all its child objects
	static public Material[] GetAllMaterials( GameObject go) {
		Renderer [] rends = go.GetComponentsInChildren<Renderer>();

		List<Material> mats = new List<Material>();
		foreach (Renderer rend in rends ){
			mats.Add(rend.material);
		}
		return( mats.ToArray() );
}

}
