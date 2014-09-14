using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	public bool pauseEnabled = false;
	public GUISkin skin = null;
	public string mainMenuSceneName;
	public Font pauseMenuFont;
  
	void OnGUI () {
		this.skin.box.fontSize = (int)Screen.dpi / 7;
		GUI.skin = skin;
		this.skin.button.fontSize = (int)Screen.dpi / 7;
		//Pause button
		if (GUI.Button (new Rect (Screen.width - Screen.height/20, Screen.height - Screen.height/20, Screen.height/20, Screen.height/20),"II")) {
			//Application.LoadLevel(0);

			if(pauseEnabled == true){
				//unpause the game
				pauseEnabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;
				Screen.showCursor = false;
				light.enabled = false;
			}
			
			//else if game isn't paused, then pause it
			else if(pauseEnabled == false){
				pauseEnabled = true;
				AudioListener.volume = 0;
				Time.timeScale = 0;
				Screen.showCursor = true;
				light.enabled = true;
			}

				}

		if (Input.GetKeyDown(KeyCode.Escape))
			Application.LoadLevel (0);



		GUI.skin.box.font = pauseMenuFont;
		GUI.skin.button.font = pauseMenuFont;
		
		if(pauseEnabled == true){
			
			//Make a background box
			GUI.Box(new Rect(0, 6*Screen.height/20, Screen.width , 5*Screen.height/11), "PAUSE");
			
			//Resume Menu button
			if(GUI.Button(new Rect(0, Screen.height/5 + 2*Screen.height/10, Screen.width , Screen.height/11), "RESUME")){
				pauseEnabled = false;
				Time.timeScale = 1;
				AudioListener.volume = 1;
				Screen.showCursor = false; 
			}

			//Make Main Menu button
			if(GUI.Button(new Rect(0, Screen.height/5 + 3*Screen.height/10, Screen.width , Screen.height/11), "MAIN MENU")){
				Application.LoadLevel(0);
			}
			
			//Make quit game button
			if (GUI.Button (new Rect (0, Screen.height/5 + 4*Screen.height/10, Screen.width , Screen.height/11), "QUIT GAME")){
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
