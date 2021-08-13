using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode {
	idle,
	playing,
	levelEnd
}

public class MissionDemolition : MonoBehaviour {
	static private MissionDemolition S;

	[Header("Set in Inspector")]
	public Text 			uitLevel; // UIText_Level link
	public Text			uitShots; // UIText_Shots link
	public Text			uitButton; // UIButton_View's child Text link
	public Vector3			castlePos; // Castle displacement
	public GameObject[]		castles; // Massive of castles

	[Header("Set Dynamically")]
	public int			level;	// Present level
	public int 			levelMax; // Number of levels
	public int			shotsTaken;
	public GameObject 		castle;	// Present castle
	public GameMode			mode = GameMode.idle;
	public string 			showing = "Show Slingshot"; // Mode FollowCam

	void Start () {
		S = this;

		level = 0;
		levelMax = castles.Length;
		StartLevel ();
	}

	void StartLevel() {
		// Destroy previous castle, if it exists
		if (castle != null) {
			Destroy (castle);
		}

		// Destroy previous projectiles, if they exist
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
		foreach (GameObject pTemp in gos) {
			Destroy (pTemp);
		}

		// Create new castle
		castle = Instantiate<GameObject>( castles[level] );
		castle.transform.position = castlePos;
		shotsTaken = 0;

		// Reinstall camera into start position
		SwitchView("Show Both");
		ProjectileLine.S.Clear ();

		// Discard goal
		Goal.goalMet = false;

		UpdateGUI ();

		mode = GameMode.playing;
	}

	void UpdateGUI() {
		// Show data into the UI elements
		uitLevel.text = "Level: "+(level + 1)+ " of "+levelMax;
		uitShots.text = "Shots Taken: " + shotsTaken;
	}
		
	void Update () {
		UpdateGUI ();

		// Check the level end
		if ((mode == GameMode.playing) && Goal.goalMet) {
			// Change mode in order to stop check of level ending
			mode = GameMode.levelEnd;
			// Decrease scale
			SwitchView ("Show Both");
			// Start new level after 2 seconds
			Invoke ("NextLevel", 2f);
		}
	}

	void NextLevel() {
		level++;
		if (level == levelMax) {
			level = 0;
		}
		StartLevel();
	}

	public void SwitchView( string eView = "") {
		if (eView == "") {
			eView = uitButton.text;
		}
		showing = eView;
		switch (showing) {
		case "Show Slingshot":
			FollowCam.POI = null;
			uitButton.text = "Show Castle";
			break;
		case "Show Castle":
			FollowCam.POI = S.castle;
			uitButton.text = "Show Both";
			break;
		case "Show Both":
			FollowCam.POI = GameObject.Find ("ViewBoth");
			uitButton.text = "Show Slingshot";
			break;
		}
	}

	public static void ShotFired() {
		S.shotsTaken++;
	}
}
