using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public string btnStart 		 = string.Empty;
	public string btnScores 	 = string.Empty;
	public string btnHelp 		 = string.Empty;
	public string btnExit 		 = string.Empty;
	public GameObject clicksound = null;
	public GUIStyle StartStyle = null;
	public GUIStyle ScoresStyle = null;
	public GUIStyle HelpStyle = null;
	public GUIStyle ExitStyle = null;
	public GUIStyle startTex = null;
	public GUIStyle scoresTex = null;
	public GUIStyle helpTex = null;
	public GUIStyle exitTex = null;
	public GUIStyle HelpceStyle = null;
	public GUIStyle gpStyle = null;
	public float pos1, pos2, pos3, pos4, endPos;
	public GUIContent gpContent = null;
	public Texture2D gpTex = null;

	void OnGUI () {

		StartStyle.fontSize 	 = (int)Screen.width/10;
		StartStyle.padding.left  = Screen.width / 20;
		ScoresStyle.fontSize 	 = (int)Screen.width/10;
		ScoresStyle.padding.left = Screen.width / 20;
		HelpStyle.fontSize 		 = (int)Screen.width/10;
		HelpStyle.padding.left   = Screen.width / 20;
		ExitStyle.fontSize 		 = (int)Screen.width/10;
		ExitStyle.padding.left   = Screen.width / 20;
		HelpceStyle.fontSize 	 = (int)Screen.width/12;
		gpContent.image = gpTex;

		//Sharenite kocki desno pokraj kopcinjata
		GUI.Box(new Rect(pos1, Screen.height/4, Screen.height/11, Screen.height/11),"",startTex);
		GUI.Box(new Rect(pos2, Screen.height / 4 + Screen.height / 11 + Screen.height / 20, Screen.height/11, Screen.height/11),"",scoresTex);
		GUI.Box(new Rect(pos3, Screen.height / 4 + 2 * Screen.height / 11 + 2 * Screen.height / 20, Screen.height/11, Screen.height/11),"",helpTex);
		GUI.Box(new Rect(pos4, Screen.height/4 + 3*Screen.height/11 + 3*Screen.height/20, Screen.height/11, Screen.height/11),"",exitTex);

		//Tuka se kreirani kopcinjata

		if(GUI.Button (new Rect (0, Screen.height/4, Screen.width - Screen.width/5 , Screen.height/11),btnStart,StartStyle)) 
		{
			clicksound.audio.Play();
			DontDestroyOnLoad(clicksound);
			Application.LoadLevel(1);
			Time.timeScale = 1;
			AudioListener.volume = 1;
			Screen.showCursor = false; 
		}

		if (GUI.Button (new Rect (0, Screen.height / 4 + Screen.height / 11 + Screen.height / 20, Screen.width - Screen.width/5, Screen.height / 11), btnScores,ScoresStyle)) {
			clicksound.audio.Play();
			DontDestroyOnLoad(clicksound);
		}

		if (GUI.Button (new Rect (0, Screen.height / 4 + 2 * Screen.height / 11 + 2 * Screen.height / 20, Screen.width - Screen.width/5, Screen.height / 11), btnHelp,HelpStyle)) {

	
			clicksound.audio.Play();
			DontDestroyOnLoad(clicksound);
			Application.LoadLevel(2);
		}

		if(GUI.Button (new Rect (0, Screen.height/4 + 3*Screen.height/11 + 3*Screen.height/20, Screen.width - Screen.width/5, Screen.height/11), btnExit,ExitStyle))
		{
			clicksound.audio.Play();
			Application.Quit();
		}


		//helpce kopcence dolcence u kjoshence desnence
		if(GUI.Button (new Rect (Screen.width-Screen.height/11,Screen.height-Screen.height/11,Screen.height/11,Screen.height/11),"?",HelpceStyle))
		{
			clicksound.audio.Play();
		}

		if(GUI.Button (new Rect (0,Screen.height-Screen.height/11,Screen.height/11,Screen.height/11),gpContent,gpStyle))
		{
			clicksound.audio.Play();
		}

		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
	
	// Use this for initialization
	void Start () {
		pos1 = Screen.width + 50;
		pos2 = Screen.width + 100;
		pos3 = Screen.width + 200;
		pos4 = Screen.width + 300;
		endPos = Screen.width - Screen.height / 11;
	}
	
	// Update is called once per frame
	void Update () {
		pos1 = Mathf.Lerp (pos1, endPos, Time.fixedDeltaTime / 0.2f);
		pos2 = Mathf.Lerp (pos2, endPos, Time.fixedDeltaTime / 0.2f);
		pos3 = Mathf.Lerp (pos3, endPos, Time.fixedDeltaTime / 0.2f);
		pos4 = Mathf.Lerp (pos4, endPos, Time.fixedDeltaTime / 0.2f);
	}	
}
