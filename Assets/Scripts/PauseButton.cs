using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	public GUISkin skin = null;
	private string pause = "II";

	void OnGUI () {

		GUI.skin = skin;
		this.skin.button.fontSize = (int)Screen.dpi / 3;
		//Pause button
		if (GUI.Button (new Rect (Screen.width - Screen.height/11, Screen.height - Screen.height/14, Screen.height/11, Screen.height/14),pause)) {
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
