using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
	
	public float barWidth;
	public float barHeight;
	public float timer;
	public Texture progressBar;

	// Use this for initialization
	void Start () {
		barWidth = Screen.width - 20.0f;
		barHeight = 12.0f;
		timer = barWidth / 60.0f * Time.deltaTime;
		Debug.Log ("BAR WIDTH: " + barWidth);
	}
	
	// Update is called once per frame
	void Update () {
		barWidth -= timer;
	}

	void OnGUI () {
		GUI.DrawTexture (new Rect (10.0f, 10.0f, barWidth, barHeight), progressBar, ScaleMode.StretchToFill, true, 1.0f);
	}
}
