using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
	
	public float barWidth;
	public float currWidth;
	public float barHeight;
	public float seconds;
	public Texture progressBar;
	public Color startColor;
	public Color endColor;

	// Use this for initialization
	void Start () {
		barWidth = Screen.width - 20.0f;
		barHeight = 10.0f;
		seconds = 10.0f;
		startColor = guiTexture.color;
		endColor = Color.red;
		transform.position = Vector3.zero;
		transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (currWidth <= 0) {
			currWidth = barWidth;
			guiTexture.color = startColor;
		}
		currWidth -= barWidth / seconds * Time.deltaTime;
		guiTexture.color = Color.Lerp (guiTexture.color, endColor, Time.deltaTime / seconds);
	}

	void OnGUI () {

		guiTexture.pixelInset = new Rect (10 ,Screen.height - 18, currWidth, barHeight);
	}
}
