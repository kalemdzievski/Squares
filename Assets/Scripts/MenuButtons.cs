using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public Texture2D btnImage = null;
	public GUISkin skin = null;

	void OnGUI () {

		GUI.skin = skin;

		//Tuka se kreirani kopcinjata
		if(GUI.Button (new Rect (0, Screen.height/3, Screen.width , Screen.height/10), "Start Game")) 
		{
			Application.LoadLevel(1);
		}

		GUI.Button (new Rect (0, Screen.height/3 + Screen.height/10 + Screen.height/20, Screen.width, Screen.height/10), "Options");

		GUI.Button (new Rect (0,Screen.height/3 + 2*Screen.height/10 + 2*Screen.height/20, Screen.width, Screen.height/10), "High Scores");

		if(GUI.Button (new Rect (0, Screen.height/3 + 3*Screen.height/10 + 3*Screen.height/20, Screen.width, Screen.height/10), "Quit"))
		{
			Application.Quit();
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
