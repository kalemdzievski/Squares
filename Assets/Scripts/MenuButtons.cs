using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public int levo = 70;
	public int gore = 200;
	public int shirina_ramka = 200;
	public int visina_ramka = 240;
	public int shirina_kopce = 180;
	public int visina_kopce = 40;
		
	void OnGUI () {
			// Ova e ramkata okolu kopcinjata
			GUI.Box(new Rect(levo,gore,shirina_ramka,visina_ramka), "Main Menu");
		//Tuka se kreirani kopcinjata
		if(GUI.Button (new Rect (levo+10, gore+30, shirina_kopce, visina_kopce), "Start Game")) 
		{
			Application.LoadLevel(1);
		}

		GUI.Button (new Rect (levo + 10, gore + visina_kopce + 40, shirina_kopce, visina_kopce), "Options");

		GUI.Button (new Rect (levo+10, gore+2*visina_kopce+50, shirina_kopce, visina_kopce), "High Scores");

		if(GUI.Button (new Rect (levo+10, gore+3*visina_kopce+60, shirina_kopce, visina_kopce), "Quit"))
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
