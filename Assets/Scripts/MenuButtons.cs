using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {
<<<<<<< HEAD

	public int levo;
	public int gore;
	public int shirina_ramka;
	public int visina_ramka;
	public int shirina_kopce;
	public int visina_kopce;
=======
	
	public int gore = 200;
	public int visina_ramka = 240;
	public int visina_kopce = 20;
>>>>>>> e094397f58e21b83f9e14f3a366e5ca89f53d31a
		
	void OnGUI () {
			// Ova e ramkata okolu kopcinjata
		GUI.Box(new Rect(10,Screen.height/4,Screen.width-20,visina_ramka), "Main Menu");
		//Tuka se kreirani kopcinjata
<<<<<<< HEAD
		if(GUI.Button (new Rect (levo+10, gore+30, shirina_kopce, visina_kopce), "Start Game")) {
			Application.LoadLevel(1);
		}

		GUI.Button (new Rect (levo+10, gore+visina_kopce+40, shirina_kopce, visina_kopce), "Options");
		GUI.Button (new Rect (levo+10, gore+2*visina_kopce+50, shirina_kopce, visina_kopce), "High Scores");
		GUI.Button (new Rect (levo+10, gore+3*visina_kopce+60, shirina_kopce, visina_kopce), "Quit");
=======
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
>>>>>>> e094397f58e21b83f9e14f3a366e5ca89f53d31a
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
