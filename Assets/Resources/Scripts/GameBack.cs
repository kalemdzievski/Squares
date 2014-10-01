using UnityEngine;
using System.Collections;

public class GameBack : MonoBehaviour {

	// Use this for initialization
	SpriteRenderer sr;
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		float xmas = Screen.width*Camera.main.orthographicSize*2.5f /(Screen.height*1.0f);//
		float yScale =Camera.main.orthographicSize*2.5f  / sr.renderer.bounds.size.y; 
		float xScale = 0;
		if (Screen.height > Screen.width)
			xScale = xmas / sr.renderer.bounds.size.x;
		else
			xScale = 1.5f; //for web view etc . you can change 1.5 according to you
		transform.localScale = new Vector3 (xScale,yScale,1);// I am using 2d so z doesn't needed.
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
