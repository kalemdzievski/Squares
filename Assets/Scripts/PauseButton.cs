using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	public GUISkin skin = null;

	void OnGUI () {

		GUI.skin = skin;

		//Pause button
		if (GUI.Button (new Rect (Screen.width - 40, Screen.height - 40, 40, 40), "II")) {
			Application.LoadLevel(1);
				}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
