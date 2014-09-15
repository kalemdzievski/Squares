using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
	
	public float barWidth;
	public float currWidth;
	public float barHeight;
	public float seconds;
	public Texture progressBar;

	// Use this for initialization
	void Start () {
		barWidth = Screen.width - 20.0f;
		barHeight = 12.0f;
		seconds = 60.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (currWidth <= 0) {
			currWidth = barWidth;
		}
	
		currWidth -= barWidth / seconds * Time.deltaTime;
	}

	void OnGUI () {
		GUI.DrawTexture (new Rect (10.0f, 10.0f, currWidth, barHeight), progressBar, ScaleMode.StretchToFill, true, 1.0f);
	}
}
