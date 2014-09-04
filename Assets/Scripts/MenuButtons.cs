using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public Texture2D btnImage = null;
	public GUISkin skin = null;
	public string btnStart = string.Empty;
	public string btnOptions = string.Empty;
	public string btnScores = string.Empty;
	public string btnExit = string.Empty;


	void OnGUI () {

		GUI.skin = skin;
		skin.button.fontSize = (int)Screen.dpi/3;

		//Tuka se kreirani kopcinjata
		if(GUI.Button (new Rect (0, Screen.height/3, Screen.width , Screen.height/10),btnStart)) 
		{

			Application.LoadLevel(1);
		}

		if (GUI.Button (new Rect (0, Screen.height / 3 + Screen.height / 10 + Screen.height / 20, Screen.width, Screen.height / 10), btnOptions));

		GUI.Button (new Rect (0,Screen.height/3 + 2*Screen.height/10 + 2*Screen.height/20, Screen.width, Screen.height/10), btnScores);

		if(GUI.Button (new Rect (0, Screen.height/3 + 3*Screen.height/10 + 3*Screen.height/20, Screen.width, Screen.height/10), btnExit))
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
