using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private BoundsCheck bndCheck;
	private Renderer	rend;

	[Header("Set Dynamically")]
	public Rigidbody	rigid;
	[SerializeField]
	private WeaponType _type;
	
	public WeaponType type {
		get {
			return(_type);
		}
		set {
			SetType( value );
		}
	}
	void Awake() {
		bndCheck = GetComponent<BoundsCheck> ();
		rend = GetComponent<Renderer>();
		rigid = GetComponent<Rigidbody>();
	}
	
	void Update () {
		if (bndCheck.offUp) {
			Destroy (gameObject);
		}
	}

	/// <summary>
	/// It changes private field _type and install colour of the projectile, as it was defined in WeaponDefinition
	/// </summary>
	/// <param name="eType">
	/// Type WeaponType of weapon in use.
	/// </param>
	public void SetType( WeaponType eType){
		_type = eType;
		WeaponDefinition def = Main.GetWeaponDefinition( _type);
		rend.material.color = def.projectileColor;
	}
}
