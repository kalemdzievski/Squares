using UnityEngine;
using System.Collections;

public class HelpDescription : MonoBehaviour {

	public Color HelpBoxColor;
	public GUIStyle BackgroundFade;
	public Vector2 scrollPosition = Vector2.zero;
	public GUIStyle HelpButton;

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
		HelpBoxColor = new Color (1.0f, 1.0f, 1.0f, 0.1f);
	}

	void OnGUI()
	{
		HelpButton.padding.left = Screen.width / 20;
		GUI.BeginScrollView (new Rect (0, 0, Screen.width, Screen.height), scrollPosition, new Rect (0, 0, 20, 20));
		GUI.Box(new Rect(Screen.width/20,Screen.height/40,Screen.width - 2*Screen.width/20,Screen.height - 8*Screen.width/22),"",BackgroundFade);
		BackgroundFade.normal.background = MakeTex( 2, 2, HelpBoxColor );
		if (GUI.Button (new Rect (0, Screen.height - 2 * Screen.height / 12, Screen.width, Screen.height / 11), "Main Menu", HelpButton)) {
			Application.LoadLevel(0);		
		}
		HelpButton.fontSize = (int)Screen.width/10;
		GUI.EndScrollView ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
