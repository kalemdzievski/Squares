using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GUISkin skin;
	public GUIStyle BackgroundFade;
	public GUIStyle Title;
	public Font pauseMenuFont;
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

	// Use this for initialization
	void Start () {
		pauseBoxColor = new Color (1.0f, 1.0f, 1.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		pauseBoxColor.a = Mathf.Lerp(pauseBoxColor.a, 0.7f, Time.fixedDeltaTime / 0.2f);
	}

	void OnGUI () {
		GUI.skin = skin;
		GUI.Box(new Rect(0, 0, Screen.width ,Screen.height), "", BackgroundFade);
		GUI.Label (new Rect (0, Screen.height / 4.0f, Screen.width, 30), "GAME OVER", Title);
		BackgroundFade.normal.background = MakeTex( 2, 2, pauseBoxColor );

		//Retry button
		if(GUI.Button(new Rect(0, Screen.height/4 + Screen.height/10, Screen.width , Screen.height/11), "Retry")){
			Application.LoadLevel(1);
			Time.timeScale = 1;
			AudioListener.volume = 1;
		}
		
		//Main menu button
		if(GUI.Button(new Rect(0, Screen.height/4 + 2*Screen.height/10, Screen.width , Screen.height/11), "Main Menu")){
			Application.LoadLevel(0);
		}
	}
}
