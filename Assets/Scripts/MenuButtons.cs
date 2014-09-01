using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public int levo;
	public int gore;
	public int shirina_ramka;
	public int visina_ramka;
	public int shirina_kopce;
	public int visina_kopce;
		
	void OnGUI () {
			// Ova e ramkata okolu kopcinjata
			GUI.Box(new Rect(levo,gore,shirina_ramka,visina_ramka), "Main Menu");
		//Tuka se kreirani kopcinjata
		if(GUI.Button (new Rect (levo+10, gore+30, shirina_kopce, visina_kopce), "Start Game")) {
			Application.LoadLevel(1);
		}

		GUI.Button (new Rect (levo+10, gore+visina_kopce+40, shirina_kopce, visina_kopce), "Options");
		GUI.Button (new Rect (levo+10, gore+2*visina_kopce+50, shirina_kopce, visina_kopce), "High Scores");
		GUI.Button (new Rect (levo+10, gore+3*visina_kopce+60, shirina_kopce, visina_kopce), "Quit");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
