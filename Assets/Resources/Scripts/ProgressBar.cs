using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	public float barWidth;
	public float currWidth;
	public float barHeight;
	public float seconds;
	public float freezeSeconds;
	public float fadeDuration;
	public Color startColor;
	public Color endColor;
	public GUITexture progressBar;
	public GameObject popupText;
	public SquareMatrix squareMatrixScript;
	public Gadgets gadgetsScript;

	void Awake()
	{
		progressBar = GameObject.Find ("ProgressBar").guiTexture;
		currWidth = barWidth = Screen.width;
		barHeight = Screen.width/14;
		seconds = 60.0f;
		currWidth = barWidth;
		fadeDuration = 2.0f;
		startColor = guiTexture.color;
		endColor = Color.red;
		transform.position = Vector3.zero;
		transform.localScale = Vector3.zero;
		squareMatrixScript = GameObject.FindGameObjectWithTag ("Block").GetComponent<SquareMatrix> ();
		gadgetsScript = GameObject.FindGameObjectWithTag ("Gadgets").GetComponent<Gadgets> ();
		freezeSeconds = 0f;
	}
		
	// Update is called once per frame
	void Update () {

		if (currWidth < 0) {
			if(squareMatrixScript.randomSquaresPainted < 10)
				++squareMatrixScript.randomSquaresPainted;
			currWidth = barWidth;
			progressBar.color = startColor;
			Instantiate(popupText);
		}

		if(!gadgetsScript.freezeTime)
		{
			currWidth -= barWidth / seconds * Time.deltaTime;
			progressBar.color = Color.Lerp (guiTexture.color, endColor, Time.deltaTime / seconds);
		}
		else
		{
			freezeSeconds += Time.deltaTime;
		}

		if(freezeSeconds >= 10)
		{
			freezeSeconds = 0f;
			gadgetsScript.freezeTime = false;
		}
	}
		
	void OnGUI () {
		progressBar.pixelInset = new Rect (0 ,Screen.height-barHeight, currWidth, barHeight);
	}
}
