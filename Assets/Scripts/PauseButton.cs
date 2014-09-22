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
		GUI.skin = skin;
		GUI.skin.box.font = pauseMenuFont;
		GUI.skin.button.font = pauseMenuFont;
		this.skin.button.fontSize = (int)Screen.width / 12; // Golemina na font na kopcinja vo pause menu
		PauseBtnBox.fontSize = (int)Screen.dpi / 8;//Font na pauza kopce
		//Pause button
		if (GUI.Button (new Rect (Screen.width - Screen.height/20, Screen.height - Screen.height/20, Screen.height/20, Screen.height/20),"II",PauseBtnBox)) {

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

		if (Input.GetKeyDown (KeyCode.Escape)) {
			pauseEnabled = true;
			Time.timeScale = 0;
		}
		
		if(pauseEnabled == true){
			//Make a background box
			GUI.Box(new Rect(0, 0, Screen.width ,Screen.height), "", PauseBox);
			GUI.TextArea(new Rect(0,Screen.height/6.0f, Screen.width, 30),"GAME PAUSED",PauseTitle);
			PauseTitle.fontSize = (int)Screen.dpi/4; // golemina na font na naslov vo Pause Menu
			PauseBox.normal.background = MakeTex( 2, 2, pauseBoxColor );

			//Resume Menu button
			widthLeft = (widthLeft >= 0) ? 0 : widthLeft;
			widthRight = (widthRight <= 0) ? 0 : widthRight;
			if(GUI.Button(new Rect(widthLeft, Screen.height/4, Screen.width , Screen.height/11), "Resume")){
				pauseEnabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;
			}

			//Make Retry button
			if(GUI.Button(new Rect(widthRight, Screen.height/4 + Screen.height/10, Screen.width , Screen.height/11), "Retry")){
				Application.LoadLevel(1);
				pauseEnabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;
			}

			//Make Main Menu button
			if(GUI.Button(new Rect(widthLeft, Screen.height/4 + 2*Screen.height/10, Screen.width , Screen.height/11), "Main Menu")){
				Application.LoadLevel(0);
			}
			
			//Make quit game button
			if (GUI.Button (new Rect (widthRight, Screen.height/4 + 3*Screen.height/10, Screen.width , Screen.height/11), "Quit Game")){
				Application.Quit();
			}
		}

	}

	// Use this for initialization
	void Start () {
		widthLeft = -Screen.width;
		widthRight = Screen.width;
		speed = Screen.width / 30.0f;
		pauseBoxColor = new Color (1.0f, 1.0f, 1.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (pauseEnabled) {
			if(widthLeft >= 0) {
				widthLeft = 0;
			}
			else {
				widthLeft += speed;
			}
			if (widthRight <= 0) {
				widthRight = 0;
			}
			else {
				widthRight -= speed;
			}
			pauseBoxColor.a = Mathf.Lerp(pauseBoxColor.a, 0.7f, Time.fixedDeltaTime / 0.6f);
		} 
		else {
			widthLeft = -Screen.width;
			widthRight = Screen.width;
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
