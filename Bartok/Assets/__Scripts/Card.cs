using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
	[Header("Set Dynamically")]
	public string			suit;
	public int				rank;
	public Color			color = Color.black;
	public string			colS = "Black";
	public List<GameObject>	decoGOs = new List<GameObject>();
	public List<GameObject> pipGOs = new List<GameObject>();
	public GameObject		back;
	public CardDefinition	def;
	public SpriteRenderer[]	spriteRenderers;

	void Start() {
		SetSortOrder(0);
	}

	public void PopulateSpriteRenderers() {
		if (spriteRenderers == null || spriteRenderers.Length == 0) {
			spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
		}
	}
	public void SetSortingLayerName(string tSLN) {
		PopulateSpriteRenderers();

		foreach (SpriteRenderer tSR in spriteRenderers){
			tSR.sortingLayerName = tSLN;
		}
	}

	public void SetSortOrder(int sOrd) {
		PopulateSpriteRenderers();

		foreach (SpriteRenderer tSR in spriteRenderers) {
			if (tSR.gameObject == this.gameObject) {
				tSR.sortingOrder = sOrd;
				continue;
			}
			switch(tSR.gameObject.name) {
				case "back":
					tSR.sortingOrder = sOrd+2;
					break;
				case "face":
				default:
					tSR.sortingOrder = sOrd+1;
					break;
			}
		}
	}
	public bool faceUp {
		get{
			return( !back.activeSelf);
		}
		set {
			back.SetActive(!value);
		}
	}
	virtual public void OnMouseUpAsButton() {
		print(name);
	}
}

[System.Serializable]
public class Decorator{
	// The class keeps information in DeckXML about every symbol on map
	public string		type;	// Symbol which defines value of the card has
								// type = "pip"
	public Vector3		loc;	// Displacement of the sprite
	public bool			flip = false;	// Sign of sprite's rotation vertically
	public float		scale = 1f;		// Sprite's scale
}

[System.Serializable]
public class CardDefinition {
	// The class keeps information about card's value
	public string face;	// Sprite which depicting face side of card
	public int rank;	// Value of card (1-13)
	public List<Decorator> pips = new List<Decorator>(); // Symbols
}
