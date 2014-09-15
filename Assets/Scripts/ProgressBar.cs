using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {
	
	public float barWidth;
	public float currWidth;
	public float barHeight;
	public float seconds;
	public float fadeDuration;
	public Color startColor;
	public Color endColor;
	public GUITexture progressBar;

	// Use this for initialization
	void Start () {
		progressBar = GameObject.Find ("ProgressBar").guiTexture;
		barWidth = Screen.width - 20.0f;
		barHeight = 10.0f;
		seconds = 10.0f;
		fadeDuration = 2.0f;
		startColor = guiTexture.color;
		endColor = Color.red;
		transform.position = Vector3.zero;
		transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (currWidth <= 0) {
			currWidth = barWidth;
			progressBar.color = startColor;
		}
		currWidth -= barWidth / seconds * Time.deltaTime;
		progressBar.color = Color.Lerp (guiTexture.color, endColor, Time.deltaTime / seconds);
	}

	void OnGUI () {
		progressBar.pixelInset = new Rect (10 ,Screen.height - 18, currWidth, barHeight);
	}

	/*
 	private IEnumerator Fade (float startLevel, float endLevel, float time)
	{
		float speed = 1.0f/time;
		
		for (float t = 0.0f; t < 1.0; t += Time.deltaTime*speed)
		{
			float a = Mathf.Lerp(startLevel, endLevel, t);
			popupText.font.material.color = new Color(popupText.font.material.color.r,
			                                        popupText.font.material.color.g,
			                                        popupText.font.material.color.b, a);
			yield return 0;
		}
	}
	*/
}
