using UnityEngine;
using System.Collections;

public class Gadgets : MonoBehaviour {

	public float offset;
	public float gadgetsHeight;
	public float gadgetsWidth;
	public float topPosition;
	public float leftPosition;
	public Color gadgetColor;
	public Texture FreezeTimeTex;
	public Texture NoSquareTex;
	public Texture FreeMoveTex;

	public bool freeMove;
	public bool freezeTime;
	public bool noSquares;

	// Use this for initialization
	void Start () {
		leftPosition  = (float)Screen.width / 16;
		topPosition   = (float)Screen.height - 60;
		gadgetsWidth  = (float)Screen.width / 4;
		gadgetsHeight = (float)Screen.height / 10;
		offset = gadgetsWidth + leftPosition;

		freeMove = false;
		freezeTime = false;
		noSquares = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {

		//Freeze time gadget
		if (GUI.Button (new Rect (leftPosition, topPosition, gadgetsWidth, gadgetsHeight), FreezeTimeTex)) {
			if(!freezeTime)
				freezeTime = true;
		}

		//Free move gadget
		if (GUI.Button (new Rect (leftPosition + offset, topPosition, gadgetsWidth, gadgetsHeight), FreezeTimeTex)) {
			freeMove = !freeMove;
		}

		//No squares gadget
		if (GUI.Button (new Rect (leftPosition + offset*2, topPosition, gadgetsWidth, gadgetsHeight), FreezeTimeTex)) {
			noSquares = !noSquares;
		}
	}
}
