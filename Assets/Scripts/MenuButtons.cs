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
		skin.button.fontSize = (int)Screen.width/10;

		//Tuka se kreirani kopcinjata
		if(GUI.Button (new Rect (0, Screen.height/3, Screen.width , Screen.height/11),btnStart)) 
		{
			Application.LoadLevel(1);
		}

		GUI.Button (new Rect (0, Screen.height / 3 + Screen.height / 11 + Screen.height / 20, Screen.width, Screen.height / 11), btnOptions);


		GUI.Button (new Rect (0,Screen.height/3 + 2*Screen.height/11 + 2*Screen.height/20, Screen.width, Screen.height/11), btnScores);

		if(GUI.Button (new Rect (0, Screen.height/3 + 3*Screen.height/11 + 3*Screen.height/20, Screen.width, Screen.height/11), btnExit))
		{
			Application.Quit();
		}
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		
	
	}
}
