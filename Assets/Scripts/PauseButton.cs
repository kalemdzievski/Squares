using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {


	public GUISkin skin = null;

	void OnGUI () {

		GUI.skin = skin;
		this.skin.button.fontSize = (int)Screen.dpi / 7;
		//Pause button
		if (GUI.Button (new Rect (Screen.width - Screen.height/20, Screen.height - Screen.height/20, Screen.height/20, Screen.height/20),"II")) {
			Application.LoadLevel(0);
				}

		if (Input.GetKeyDown(KeyCode.Escape))
			Application.LoadLevel (0);

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
