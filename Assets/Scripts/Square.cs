using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Square : MonoBehaviour {

	public bool isPainted;
	public bool isSelected;
	public bool isSelectedDest;
	public bool isAccessible;
	public SquareMatrix squareMatrixScript;
	public int i, j;
	public Animation anim;
	public char [,] mazematrix;
	public SquareColors colors;

	private void initSquare()
	{
		isPainted = false;
		isSelected = false;
		isSelectedDest = false;
		isAccessible = true;
		anim = this.gameObject.transform.GetChild (0).animation;
		colors = new SquareColors();
	}

	void Awake()
	{
		Debug.Log ("SQUARE");
		squareMatrixScript = GameObject.FindGameObjectWithTag ("Block").GetComponent<SquareMatrix> ();
		initSquare ();
		initMazeMatrix ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnMouseDown() 
	{
		if(isPainted && squareMatrixScript.selectedSquare == null)
		{
			isSelected = true;
			squareMatrixScript.selectedSquare = this.gameObject;
			anim.Play("Select");

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
						if(noPath(i,j)) {
							squareMatrixScript.matrix[i,j].GetComponent<Square>().isAccessible = false;
							squareMatrixScript.matrix[i,j].transform.GetChild(0).renderer.material.color = Color.magenta;
						}
						else {
							squareMatrixScript.matrix[i,j].GetComponent<Square>().isAccessible = true;
							squareMatrixScript.matrix[i,j].transform.GetChild(0).renderer.material.color = colors.GREY;
						}
					}
				}
			}
		}
		else if(!isPainted && squareMatrixScript.selectedSquare != null && !squareMatrixScript.selectedSquare.transform.GetChild(0).animation.isPlaying)
		{
			squareMatrixScript.selectedSquareDest = this.gameObject;
			if(squareMatrixScript.path())
			{
				for(int i = 0; i<squareMatrixScript.rows; i++) {
					for(int j = 0; j<squareMatrixScript.columns; j++) {
						if(!squareMatrixScript.matrix[i,j].GetComponent<Square>().isAccessible) {
							squareMatrixScript.matrix[i,j].GetComponent<Square>().isAccessible = true;
							squareMatrixScript.matrix[i,j].transform.GetChild(0).renderer.material.color = colors.GREY;
						}
					}
				}
				isSelectedDest = true;
				squareMatrixScript.move ();
				squareMatrixScript.selectedSquare.transform.GetChild (0).animation.Play("Deselect rotation");
				squareMatrixScript.selectedSquareDest.transform.GetChild (0).animation.Play("Rotation down");
			}
			else
			{
				isSelectedDest = false;
				squareMatrixScript.selectedSquareDest = null;
			}

		}
		else if(isPainted && squareMatrixScript.selectedSquare != null && squareMatrixScript.selectedSquareDest == null && !squareMatrixScript.selectedSquare.transform.GetChild(0).animation.isPlaying)
		{
			isSelected = true;
			squareMatrixScript.selectedSquare.GetComponent<Square>().isSelected = false;
			squareMatrixScript.selectedSquare.transform.GetChild (0).animation.Play("Deselect");
			squareMatrixScript.selectedSquare = this.gameObject;
			squareMatrixScript.selectedSquare.transform.GetChild (0).animation.Play("Select");

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
						if(noPath(i,j)) {
							squareMatrixScript.matrix[i,j].GetComponent<Square>().isAccessible = false;
							squareMatrixScript.matrix[i,j].transform.GetChild(0).renderer.material.color = Color.magenta;
						}
						else {
							squareMatrixScript.matrix[i,j].GetComponent<Square>().isAccessible = true;
							squareMatrixScript.matrix[i,j].transform.GetChild(0).renderer.material.color = colors.GREY;
						}
					}
				}
			}
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
		Path path = new Path();

		mazematrix[x + 1, y + 1] = 'E';

		for (int i = 0; i < squareMatrixScript.rows + 2; i++)
		{
			for (int j = 0; j < squareMatrixScript.columns + 2; j++)
			{
				input[i] += mazematrix[i, j];
			}
		}
		path.generateGraph(squareMatrixScript.rows + 2, squareMatrixScript.columns + 2, input);
		return !path.findPath();
	}

}
