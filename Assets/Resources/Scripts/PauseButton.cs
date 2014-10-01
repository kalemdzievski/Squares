using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	public bool pauseEnabled = false;
	public GUISkin skin = null;
	public Font pauseMenuFont;
	public GUIStyle PauseBox = null;
	public GUIStyle PauseTitle = null;
	public GUIStyle PauseBtnBox = null;
	public float widthLeft;
	public float widthRight;
	public float speed;
	public Color pauseBoxColor;
	public GUIStyle RetryStyle = null;
	public GUIStyle ResumeStyle = null;
	public GUIStyle MainMenuStyle = null;
	public GUIStyle QuitStyle = null;
	
	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}
  
	void OnGUI () {
		ResumeStyle.fontSize = (int)Screen.width / 12;
		RetryStyle.fontSize = (int)Screen.width / 12;
		MainMenuStyle.fontSize = (int)Screen.width / 12;
		QuitStyle.fontSize = (int)Screen.width / 12;// Golemina na font na kopcinja vo pause menu
		PauseBtnBox.fontSize      = (int)Screen.width / 16;//Font na pauza kopce

		//Pause button
		if (GUI.Button (new Rect (Screen.width - Screen.height/15, Screen.height/10, Screen.height/15, Screen.height/15),"II",PauseBtnBox)) {
				pauseEnabled = true;
				AudioListener.volume = 0;
				Time.timeScale = 0;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			pauseEnabled = true;
			Time.timeScale = 0;
		}
		
		if(pauseEnabled == true){
			//Make a background box
			GUI.Box(new Rect(0, 0, Screen.width ,Screen.height), "", PauseBox);
			GUI.Label(new Rect(0,Screen.height/6.0f, Screen.width, 30),"GAME PAUSED",PauseTitle);
			PauseTitle.fontSize = (int)Screen.width/13; // golemina na font na naslov vo Pause Menu
			PauseBox.normal.background = MakeTex( 2, 2, pauseBoxColor );

			//Resume Menu button
			if(GUI.Button(new Rect(widthLeft, Screen.height/4, Screen.width , Screen.height/11), "Resume",ResumeStyle)){
				pauseEnabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;
			}

			//Make Retry button
			if(GUI.Button(new Rect(widthRight, Screen.height/4 + Screen.height/10, Screen.width , Screen.height/11), "Retry",RetryStyle)){
				pauseEnabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;
				Application.LoadLevel(1);
			}

			//Make Main Menu button
			if(GUI.Button(new Rect(widthLeft, Screen.height/4 + 2*Screen.height/10, Screen.width , Screen.height/11), "Main Menu",MainMenuStyle)){
				Application.LoadLevel(0);
			}
			
			//Make quit game button
			if (GUI.Button (new Rect (widthRight, Screen.height/4 + 3*Screen.height/10, Screen.width , Screen.height/11), "Quit Game",QuitStyle)){
				Application.Quit();
			}
		}

	}

	// Use this for initialization
	void Start () {
		widthLeft 	  = -Screen.width;
		widthRight 	  = Screen.width;
		pauseBoxColor = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (pauseEnabled) {
			widthLeft 		= Mathf.Lerp(widthLeft, 0, Time.fixedDeltaTime / 0.12f);
			widthRight 		= Mathf.Lerp(widthRight, 0, Time.fixedDeltaTime / 0.12f);
			pauseBoxColor.a = Mathf.Lerp(pauseBoxColor.a, 0.9f, Time.fixedDeltaTime / 0.2f);
		} 
		else {
			widthLeft 	= -Screen.width;
			widthRight 	= Screen.width;
			pauseBoxColor.a = 0.0f;
		}

		if(Input.GetKeyDown("escape")){
			//check if game is already paused       
			if(pauseEnabled == true){
				//unpause the game
				pauseEnabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;        
			}
			
			//else if game isn't paused, then pause it
			else if(pauseEnabled == false){
				pauseEnabled = true;
				AudioListener.volume = 0;
				Time.timeScale = 0;
			}
		}
	}
}
