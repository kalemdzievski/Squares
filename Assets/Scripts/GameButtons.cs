using UnityEngine;
using System.Collections;

public class GameButtons : MonoBehaviour {

	void OnGUI () {

		// Back button
		if(GUI.Button (new Rect (0,Screen.height-30, 30 , 30), "<<")) 
		{
			Application.LoadLevel(0);
		}
		//Pause button
		GUI.Button (new Rect (Screen.width - 30, Screen.height - 30, 30, 30), "||");

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
