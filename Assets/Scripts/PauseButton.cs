using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	public bool pauseEnabled = false;
	public GUISkin skin = null;
	public Font pauseMenuFont;
	public GUIStyle PauseBox = null;
	public GUIStyle PauseTitle = null;

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
		this.skin.box.fontSize = (int)Screen.dpi / 7;
		GUI.skin = skin;
		this.skin.button.fontSize = (int)Screen.dpi / 7;
		//Pause button
		if (GUI.Button (new Rect (Screen.width - Screen.height/20, Screen.height - Screen.height/20, Screen.height/20, Screen.height/20),"II")) {


			if(pauseEnabled == true){
				//unpause the game
				pauseEnabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;
				Screen.showCursor = false;

			}
			
			//else if game isn't paused, then pause it
			else if(pauseEnabled == false){
				pauseEnabled = true;
				AudioListener.volume = 0;
				Time.timeScale = 0;
				Screen.showCursor = true;

			}

				}

		if (Input.GetKeyDown(KeyCode.Escape))
			Application.LoadLevel (0);



		GUI.skin.box.font = pauseMenuFont;
		GUI.skin.button.font = pauseMenuFont;
		
		if(pauseEnabled == true){

			//Make a background box
			GUI.Box(new Rect(0,0, Screen.width ,Screen.height), "", PauseBox);
			GUI.TextArea(new Rect(0,Screen.height/4, Screen.width, 30), "GAME PAUSED",PauseTitle);


			PauseBox.normal.background = MakeTex( 2, 2, new Color( 1f, 1f, 1f, 0.8f ) );
			//Resume Menu button
			if(GUI.Button(new Rect(0, Screen.height/7 + 2*Screen.height/10, Screen.width , Screen.height/11), "RESUME")){
				pauseEnabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;
				Screen.showCursor = false; 
			}

			//Make Main Menu button
			if(GUI.Button(new Rect(0, Screen.height/7 + 3*Screen.height/10, Screen.width , Screen.height/11), "RETRY")){
				Application.LoadLevel(1);
				pauseEnabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;
				Screen.showCursor = false; 
			}

			//Make Main Menu button
			if(GUI.Button(new Rect(0, Screen.height/7 + 4*Screen.height/10, Screen.width , Screen.height/11), "MAIN MENU")){
				Application.LoadLevel(0);
			}
			
			//Make quit game button
			if (GUI.Button (new Rect (0, Screen.height/7 + 5*Screen.height/10, Screen.width , Screen.height/11), "QUIT GAME")){
				Application.Quit();
			}
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("escape")){
			
			//check if game is already paused       
			if(pauseEnabled == true){
				//unpause the game
				pauseEnabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;
				Screen.showCursor = false;          
			}
			
			//else if game isn't paused, then pause it
			else if(pauseEnabled == false){
				pauseEnabled = true;
				AudioListener.volume = 0;
				Time.timeScale = 0;
				Screen.showCursor = true;
			}
		}
	}
}
