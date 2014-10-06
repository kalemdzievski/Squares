using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System.Collections.Generic;

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

	public SquareMatrix squareMatrixScript;
	public Square squareScript;
	public Material solidColorMat;
	public Material noPathMat;
	public GameObject popupText;

	// Use this for initialization
	void Start () {
		leftPosition  = (Screen.width / 3 - Screen.width / 3.2f)/2;
		topPosition   = (float)Screen.height - 2*Screen.width / 6;
		gadgetsWidth  = (float)Screen.width / 3.2f;
		gadgetsHeight = (float)Screen.width / 6;
		offset = Screen.width / 3 - Screen.width / 3.2f;
		//offset = gadgetsWidth + leftPosition;
		FreezeTimeContent.image = FreezeTimeIcon;
		NoSquareContent.image   = NoSquareIcon;
		FreeMoveContent.image 	= FreeMoveIcon;

		freeMove   = false;
		freezeTime = false;
		noSquares  = false;
	}

	void Awake()
	{
		Debug.Log ("GADGETS");
		squareMatrixScript = GameObject.FindGameObjectWithTag ("Block").GetComponent<SquareMatrix> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {

		//Freeze time gadget
		if (GUI.Button (new Rect (leftPosition, topPosition, gadgetsWidth, gadgetsHeight),FreezeTimeContent, FreezeTimeTex)) {
			if(!freezeTime) {
				freezeTime = true;
				GameObject popup = (GameObject)Instantiate(popupText);
				popup.GetComponent<GadgetsPopupText>().setText("Freeze time");
			}
		}

		//Free move gadget
		if (GUI.Button (new Rect (leftPosition + Screen.width / 3, topPosition, gadgetsWidth, gadgetsHeight),FreeMoveContent, FreeMoveTex)) {
			freeMove = !freeMove;
			GameObject popup = (GameObject)Instantiate(popupText);
			popup.GetComponent<GadgetsPopupText>().setText("Free move");
			if(squareMatrixScript.selectedSquare != null)
			{
				squareScript = squareMatrixScript.selectedSquare.GetComponent<Square>();
				if(freeMove)
				{
					for(int i=0; i<squareScript.noPathSquares.Count; i++)
						squareScript.noPathSquares[i].transform.GetChild(0).renderer.material = solidColorMat;
				}
				else
				{
					for(int i=0; i<squareScript.noPathSquares.Count; i++)
						squareScript.noPathSquares[i].transform.GetChild(0).renderer.material = noPathMat;
				}
			}
		}

		//No squares gadget
		if (GUI.Button (new Rect (leftPosition + 2*Screen.width / 3, topPosition, gadgetsWidth, gadgetsHeight),NoSquareContent, NoSquareTex)) {
			noSquares = !noSquares;
			GameObject popup = (GameObject)Instantiate(popupText);
			popup.GetComponent<GadgetsPopupText>().setText("No squares next turn");
		}
	}
}
