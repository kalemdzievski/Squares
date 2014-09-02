using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {
		
	public int gore = 200;
	public int visina_kopce = 10;

	public Texture2D btnImage = null;
	public GUISkin skin = null;

	void OnGUI () {

		GUI.skin = skin;

		//Tuka se kreirani kopcinjata
		if(GUI.Button (new Rect (0, Screen.height/4 + 30, Screen.width , visina_kopce), "Start Game")) 
		{
			Application.LoadLevel(1);
		}

		GUI.Button (new Rect (0, Screen.height/4 + visina_kopce + 40, Screen.width, visina_kopce), "Options");

		GUI.Button (new Rect (0,Screen.height/4 + 2*visina_kopce+50, Screen.width, visina_kopce), "High Scores");

		if(GUI.Button (new Rect (0, Screen.height/4 + 3*visina_kopce+60, Screen.width, visina_kopce), "Quit"))
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
