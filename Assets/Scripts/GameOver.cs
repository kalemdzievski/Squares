using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

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
		BackgroundFade = null;
		pauseBoxColor = new Color (1.0f, 1.0f, 1.0f, 0.0f);
		Title.fontSize = (int)Screen.dpi/4;
	}
	
	// Update is called once per frame
	void Update () {
		pauseBoxColor.a = Mathf.Lerp(pauseBoxColor.a, 0.7f, Time.fixedDeltaTime / 0.2f);
	}

	void OnGUI () {
		GUI.Label (new Rect (0, Screen.height / 6.0f, Screen.width, 30), "GAME OVER", Title);
		BackgroundFade.normal.background = MakeTex( 2, 2, pauseBoxColor );
	}
}
