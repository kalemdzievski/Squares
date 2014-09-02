using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {
		
	public int gore = 200;
	public int visina_ramka = 240;
	public int visina_kopce = 20;

	void OnGUI () {
			// Ova e ramkata okolu kopcinjata
		GUI.Box(new Rect(10,Screen.height/4,Screen.width-20,visina_ramka), "Main Menu");
		//Tuka se kreirani kopcinjata
		if(GUI.Button (new Rect (20, Screen.height/4 + 30, Screen.width-40 , visina_kopce), "Start Game")) 
		{
			Application.LoadLevel(1);
		}

		GUI.Button (new Rect (20, Screen.height/4 + visina_kopce + 40, Screen.width-40, visina_kopce), "Options");

		GUI.Button (new Rect (20,Screen.height/4 + 2*visina_kopce+50, Screen.width-40, visina_kopce), "High Scores");

		if(GUI.Button (new Rect (20, Screen.height/4 + 3*visina_kopce+60, Screen.width-40, visina_kopce), "Quit"))
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
