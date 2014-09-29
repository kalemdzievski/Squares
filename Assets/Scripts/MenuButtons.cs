using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public string btnStart = string.Empty;
	public string btnScores = string.Empty;
	public string btnHelp = string.Empty;
	public string btnExit = string.Empty;
	public GameObject clicksound = null;
	public GUIStyle StartStyle = null;
	public GUIStyle ScoresStyle = null;
	public GUIStyle HelpStyle = null;
	public GUIStyle ExitStyle = null;

	void OnGUI () {

		StartStyle.fontSize = (int)Screen.width/10;
		StartStyle.padding.left = Screen.width / 20;
		ScoresStyle.fontSize = (int)Screen.width/10;
		ScoresStyle.padding.left = Screen.width / 20;
		HelpStyle.fontSize = (int)Screen.width/10;
		HelpStyle.padding.left = Screen.width / 20;
		ExitStyle.fontSize = (int)Screen.width/10;
		ExitStyle.padding.left = Screen.width / 20;
		//Tuka se kreirani kopcinjata
		if(GUI.Button (new Rect (0, Screen.height/3, Screen.width , Screen.height/11),btnStart,StartStyle)) 
		{
			clicksound.audio.Play();
			DontDestroyOnLoad(clicksound);
			Application.LoadLevel(1);
			Time.timeScale = 1;
			AudioListener.volume = 1;
			Screen.showCursor = false;   

		}

		if (GUI.Button (new Rect (0, Screen.height / 3 + Screen.height / 11 + Screen.height / 20, Screen.width, Screen.height / 11), btnScores,ScoresStyle)) {

			clicksound.audio.Play();
			DontDestroyOnLoad(clicksound);
		}


		if (GUI.Button (new Rect (0, Screen.height / 3 + 2 * Screen.height / 11 + 2 * Screen.height / 20, Screen.width, Screen.height / 11), btnHelp,HelpStyle)) {
			clicksound.audio.Play();
			DontDestroyOnLoad(clicksound);
			Application.LoadLevel(2);
		}

		if(GUI.Button (new Rect (0, Screen.height/3 + 3*Screen.height/11 + 3*Screen.height/20, Screen.width, Screen.height/11), btnExit,ExitStyle))
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
