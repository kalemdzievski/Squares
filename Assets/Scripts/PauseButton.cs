using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	public GUISkin skin = null;

	void OnGUI () {

		GUI.skin = skin;

		//Pause button
		if (GUI.Button (new Rect (Screen.width - Screen.height/8, Screen.height - Screen.height/8, Screen.height/8, Screen.height/8), "II")) {
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
