using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
	[Header("Set in Inspector")]
	public GameObject 		basketPrefab;
	public int				numBaskets = 3;
	public float			basketBottomY = -14f;
	public float			basketSpacingY = 2f;
	public List<GameObject>	basketList;

	void Start () {
		basketList = new List<GameObject> ();
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGO = Instantiate<GameObject> (basketPrefab);
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
		}
	}

	public void AppleDestroyed() {
		// Delete all fallen apples
		GameObject[] tAppleArray=GameObject.FindGameObjectsWithTag("Apple");
		foreach( GameObject tGO in tAppleArray ) {
			Destroy (tGO);
		}

		// Delete one basket
		// Get index last basket in basketList
		int basketIndex = basketList.Count-1;
		// Get link of the game object Basket
		GameObject tBasketGO = basketList[basketIndex];
		// Exclude basket from list and delete game object
		basketList.RemoveAt( basketIndex );
		Destroy (tBasketGO);
		if (basketList.Count == 0) {
			SceneManager.LoadScene ("_Scene_1");
		}
	}

}
