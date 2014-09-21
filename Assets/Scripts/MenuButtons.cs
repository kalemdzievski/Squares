using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {
	
	public GUISkin skin = null;
	public string btnStart = string.Empty;
	public string btnOptions = string.Empty;
	public string btnScores = string.Empty;
	public string btnExit = string.Empty;
	public GameObject clicksound = null;


	void OnGUI () {

		GUI.skin = skin;
		skin.button.fontSize = (int)Screen.width/10;

		//Tuka se kreirani kopcinjata
		if(GUI.Button (new Rect (0, Screen.height/3, Screen.width , Screen.height/11),btnStart)) 
		{
			clicksound.audio.Play();
			DontDestroyOnLoad(clicksound);
			Application.LoadLevel(1);
			Time.timeScale = 1;
			AudioListener.volume = 1;
			Screen.showCursor = false;   

		}

		if (GUI.Button (new Rect (0, Screen.height / 3 + Screen.height / 11 + Screen.height / 20, Screen.width, Screen.height / 11), btnOptions)) {

			clicksound.audio.Play();
			DontDestroyOnLoad(clicksound);
		}


		if (GUI.Button (new Rect (0, Screen.height / 3 + 2 * Screen.height / 11 + 2 * Screen.height / 20, Screen.width, Screen.height / 11), btnScores)) {
			clicksound.audio.Play();
			DontDestroyOnLoad(clicksound);
		}

		if(GUI.Button (new Rect (0, Screen.height/3 + 3*Screen.height/11 + 3*Screen.height/20, Screen.width, Screen.height/11), btnExit))
		{
			clicksound.audio.Play();
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
