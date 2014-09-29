using UnityEngine;
using System.Collections;

public class Gadgets : MonoBehaviour {

	public float offset;
	public float gadgetsHeight;
	public float gadgetsWidth;
	public float topPosition;
	public float leftPosition;
	public Color gadgetColor;
	public GUIStyle FreezeTimeTex;
	public GUIStyle NoSquareTex;
	public GUIStyle FreeMoveTex;
	public Texture2D FreezeTimeIcon = null;
	public Texture2D NoSquareIcon = null;
	public Texture2D FreeMoveIcon = null;
	public GUIContent FreezeTimeContent;
	public GUIContent NoSquareContent;
	public GUIContent FreeMoveContent;

	public bool freeMove;
	public bool freezeTime;
	public bool noSquares;

	// Use this for initialization
	void Start () {
		leftPosition  = (Screen.width / 3 - Screen.width / 3.2f)/2;
		topPosition   = (float)Screen.height - 2*Screen.width / 6;
		gadgetsWidth  = (float)Screen.width / 3.2f;
		gadgetsHeight = (float)Screen.width / 6;
		offset = Screen.width / 3 - Screen.width / 3.2f;
		//offset = gadgetsWidth + leftPosition;
		FreezeTimeContent.image = FreezeTimeIcon;
		NoSquareContent.image = NoSquareIcon;
		FreeMoveContent.image = FreeMoveIcon;

		freeMove = false;
		freezeTime = false;
		noSquares = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {

		//Freeze time gadget
		if (GUI.Button (new Rect (leftPosition, topPosition, gadgetsWidth, gadgetsHeight),FreezeTimeContent, FreezeTimeTex)) {
			if(!freezeTime)
				freezeTime = true;
		}

		//Free move gadget
		if (GUI.Button (new Rect (leftPosition + Screen.width / 3, topPosition, gadgetsWidth, gadgetsHeight),FreeMoveContent, FreeMoveTex)) {
			freeMove = !freeMove;
		}

		//No squares gadget
		if (GUI.Button (new Rect (leftPosition + 2*Screen.width / 3, topPosition, gadgetsWidth, gadgetsHeight),NoSquareContent, NoSquareTex)) {
			noSquares = !noSquares;
		}
	}
}
