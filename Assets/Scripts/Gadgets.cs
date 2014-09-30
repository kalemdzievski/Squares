using UnityEngine;
using System.Collections;
using AssemblyCSharp;

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
	public Material solidColorMat;
	public Material noPathMat;
	public char [,] mazematrix;
	public Path path;

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
		path = new Path();
	}

	void Awake()
	{
		Debug.Log ("GADGETS");
		squareMatrixScript = GameObject.FindGameObjectWithTag ("Block").GetComponent<SquareMatrix> ();
		initMazeMatrix ();
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
			if(squareMatrixScript.selectedSquare != null)
			{
				if(freeMove)
				{
					for(int i = 0; i<squareMatrixScript.rows; i++) {
						for(int j = 0; j<squareMatrixScript.columns; j++) {
							if(!squareMatrixScript.matrix[i,j].GetComponent<Square>().isAccessible) {
								squareMatrixScript.matrix[i,j].GetComponent<Square>().isAccessible = true;
								squareMatrixScript.matrix[i,j].transform.GetChild(0).renderer.material = solidColorMat;
							}
						}
					}
				}
				else{
					//Initialize maze
					for (int i = 0; i < squareMatrixScript.rows; i++)
					{
						for (int j = 0; j < squareMatrixScript.columns; j++)
						{
							if (squareMatrixScript.matrix[i,j].GetComponent<Square>().isPainted)
							{
								mazematrix[i + 1, j + 1] = '#';
							}
							else mazematrix[i + 1, j + 1] = ' ';
							
							if (squareMatrixScript.matrix[i,j].Equals(squareMatrixScript.selectedSquare))
							{
								mazematrix[i + 1, j + 1] = 'S';
							}
						}
					}

					for(int i = 0; i<squareMatrixScript.rows; i++) {
						for(int j = 0; j<squareMatrixScript.columns; j++) {
							if(!squareMatrixScript.matrix[i,j].GetComponent<Square>().isPainted) {
								/*
								if(noPath(i,j)) {
									squareMatrixScript.matrix[i,j].GetComponent<Square>().isAccessible = false;
									squareMatrixScript.matrix[i,j].transform.GetChild(0).renderer.material = noPathMat;
								}
								else {
									squareMatrixScript.matrix[i,j].GetComponent<Square>().isAccessible = true;
									squareMatrixScript.matrix[i,j].transform.GetChild(0).renderer.material = solidColorMat;
								}
								*/
							}
						}
					}
				}
			}
		}

		//No squares gadget
		if (GUI.Button (new Rect (leftPosition + 2*Screen.width / 3, topPosition, gadgetsWidth, gadgetsHeight),NoSquareContent, NoSquareTex)) {
			noSquares = !noSquares;
		}
	}
	
	private void initMazeMatrix() {
		
		mazematrix = new char[squareMatrixScript.rows + 2, squareMatrixScript.columns + 2];
		
		for (int i = 0; i < squareMatrixScript.rows + 2; i++)
		{
			mazematrix[0, i] = '#';
			mazematrix[squareMatrixScript.rows + 1, i] = '#';
			mazematrix[i, 0] = '#';
			mazematrix[i, squareMatrixScript.columns + 1] = '#';
		}
	}
	
	public bool noPath(int x, int y) //Checks path with [x,y] and selectedSquare
	{
		string [] input = new string[squareMatrixScript.rows + 2];

		path.pathDictionary ();

		mazematrix[x + 1, y + 1] = 'E';
		for (int i = 0; i < squareMatrixScript.rows + 2; i++)
		{
			for (int j = 0; j < squareMatrixScript.columns + 2; j++)
			{
				Debug.Log("i: " + i + " y:" + y);
				input[i] += mazematrix[i, j];
			}
		}
		path.generateGraph(squareMatrixScript.rows + 2, squareMatrixScript.columns + 2, input);
		return !path.findPath();
	}
}
