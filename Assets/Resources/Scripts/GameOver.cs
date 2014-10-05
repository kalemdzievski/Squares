using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GUISkin skin;
	public GUIStyle BackgroundFade;
	public GUIStyle Title;
	public GUIStyle ScoreStyle;
	public GUIStyle ScoreValStyle;
	public Font pauseMenuFont;
	public Color pauseBoxColor;
	public GUIText ScoreText;
	public GUIStyle retryStyle;
	public GUIStyle mmStyle;
	public SquareMatrix squareMatrixScript;

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

	void Awake() {
		squareMatrixScript = GameObject.FindGameObjectWithTag ("Block").GetComponent<SquareMatrix> ();
	}

	// Use this for initialization
	void Start () {
		pauseBoxColor = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		Time.timeScale = 0;
		Destroy (GameObject.FindGameObjectWithTag("Pause"));
	}
	
	// Update is called once per frame
	void Update () {
		pauseBoxColor.a = Mathf.Lerp(pauseBoxColor.a, 0.9f, Time.fixedDeltaTime / 0.2f);
	}

	void OnGUI () {
		GUI.skin = skin;
		GUI.Box(new Rect(0, 0, Screen.width ,Screen.height), "", BackgroundFade);
		GUI.Label (new Rect (0, Screen.height / 3, Screen.width, 30), "GAME OVER", Title);
		GUI.Label (new Rect (0, Screen.height / 10, Screen.width, 30), "SCORE", ScoreStyle);
		GUI.Label (new Rect (0, Screen.height / 6, Screen.width, 30), squareMatrixScript.score.ToString(), ScoreValStyle);
		BackgroundFade.normal.background = MakeTex( 2, 2, pauseBoxColor );
		Title.fontSize = (int)Screen.width / 12;
		Title.normal.textColor = new Color (1.0f, 0.0f, 0.3f);
		ScoreStyle.fontSize = (int)Screen.width / 10;
		ScoreValStyle.fontSize = (int)Screen.width / 10;
		ScoreStyle.normal.textColor = new Color (1.0f, 1.0f, 1.0f);
		ScoreValStyle.normal.textColor = new Color(0.5f,0.7f,0.0f);

		retryStyle.fontStyle = FontStyle.Bold;
		retryStyle.alignment = TextAnchor.MiddleCenter;
		retryStyle.normal.textColor = new Color (0.0f, 0.0f, 0.0f);
		retryStyle.normal.background = (Texture2D)Resources.Load("Textures/resumeTex");
		retryStyle.fontSize = (int)Screen.width / 12;

		mmStyle.fontStyle = FontStyle.Bold;
		mmStyle.alignment = TextAnchor.MiddleCenter;
		mmStyle.normal.textColor = new Color (0.0f, 0.0f, 0.0f);
		mmStyle.normal.background = (Texture2D)Resources.Load("Textures/moveTex");
		mmStyle.fontSize = (int)Screen.width / 12;

		//Retry button
		if(GUI.Button(new Rect(0, Screen.height/3 + Screen.height/10, Screen.width , Screen.height/11), "Retry",retryStyle)){
			Application.LoadLevel(1);
			Time.timeScale = 1;
			AudioListener.volume = 1;
		}
		
		//Main menu button
		if(GUI.Button(new Rect(0, Screen.height/3 + 2*Screen.height/10, Screen.width , Screen.height/11), "Main Menu",mmStyle)){
			Application.LoadLevel(0);
		}
	}
}
