using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class SquareMatrix : MonoBehaviour
{
	public GameObject square;
	public GameObject selectedSquare;
	public GameObject selectedSquareDest;
	private Color selectedSquareColor;
	private Color selectedSquareDestColor;
	public int rows;
	public int columns;
	public int randomSquaresPainted;
	private int score;
	private int combo;
	public float offset;
	public GameObject [,] matrix;
	private List<string> listLeft;
	private List<string> listRight;
	private List<string> listDown;
	private List<string> listUp;
	private List<string> listLine;

	void initMatrix(int rows, int columns)
	{
		matrix = new GameObject[rows, columns];
		
		for (int i = 0; i < rows; i++) 
		{
			for (int j = 0; j < columns; j++) 
			{
				Vector3 squarePosition = new Vector3(square.transform.position.x + offset * j, square.transform.position.y - offset * i, square.transform.position.z);
				GameObject squareObject = (GameObject)Instantiate(square, squarePosition, Quaternion.identity);
				squareObject.GetComponent<Square>().i = i;
				squareObject.GetComponent<Square>().j = j;
				matrix[i,j] = squareObject;
			}
		}
	}

	void initVariables()
	{		
		rows = 7;
		columns = 7;
		offset = 3.5f;
		score = 0;
		combo = 0;
		listLeft = new List<string>();
		listRight = new List<string>();
		listDown = new List<string>();
		listUp = new List<string>();
		listLine = new List<string>();
		selectedSquare = null;
		selectedSquareDest = null;
		selectedSquareColor = Color.clear;
		selectedSquareDestColor = Color.clear;
	}
	
	void Awake()
	{
		initVariables ();
		initMatrix (rows, columns);
		paintRandomSquares (5);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(selectedSquare != null && selectedSquareDest != null && !selectedSquare.transform.GetChild(0).animation.isPlaying && !selectedSquareDest.transform.GetChild(0).animation.isPlaying)
		{
			selectedSquare = null;
			selectedSquareDest = null;
			selectedSquareColor = Color.clear;
			selectedSquareDestColor = Color.clear;
		}
		/*
		if(selectedSquareColor != Color.clear && selectedSquareDestColor != Color.clear)
		{
			Debug.Log("Lerp");
			selectedSquare.transform.GetChild(0).renderer.material.color = Color.Lerp(selectedSquareColor, selectedSquareDestColor, Time.deltaTime*60);
			selectedSquareDest.transform.GetChild(0).renderer.material.color = Color.Lerp(selectedSquareDestColor, selectedSquareColor, Time.deltaTime*60);
		}
		*/
	}

	public void move()
	{
		if (selectedSquare != null && selectedSquareDest != null && path()) 
		{
			selectedSquareColor = selectedSquare.transform.GetChild(0).renderer.material.color;
			selectedSquareDestColor = selectedSquareDest.transform.GetChild(0).renderer.material.color;
				
			selectedSquare.GetComponent<Square>().isPainted = false;
			selectedSquareDest.GetComponent<Square>().isPainted = true;
				
			selectedSquare.transform.GetChild(0).renderer.material.color = selectedSquareDestColor;
			selectedSquareDest.transform.GetChild(0).renderer.material.color = selectedSquareColor;
				
			int line = checkForLine(selectedSquareDest.GetComponent<Square>().i, selectedSquareDest.GetComponent<Square>().j);
				
			if(line == 1) {
				if(combo >= 3)
					score += combo * 100;
				paintRandomSquares(5);
				combo = 0;
			}
			else {
				score += line * 100;
				combo++;
			}
				
			GameObject.FindGameObjectWithTag ("Score").guiText.text = score.ToString();
			GameObject.FindGameObjectWithTag ("Combo").guiText.text = "x" + combo.ToString();
		}
	}

	void paintRandomSquares(int numberOfSquares)
	{
		int paintedSquares = 0;
		int i, j;
		GameObject squareObject;
		Square squareScript;

		while(paintedSquares < numberOfSquares)
		{
			i = Random.Range(0, rows);
			j = Random.Range(0, columns);
			squareObject = matrix[i,j];
			squareScript = squareObject.GetComponent<Square>();

			if(!squareScript.isPainted)
			{
				Color squareColor = getRandomColor();
				squareObject.transform.GetChild(0).renderer.material.color = squareColor;
				squareScript.isPainted = true;
				int line = checkForLine(i, j);
				if(line == 1)
					paintedSquares++;
				else 
					score += line * 100;
			}
		}

	}

	//Path algorithm
	public bool path()
	{
		string [] input = new string[rows + 2];
		Path path = new Path();
		char [,] mazematrix = new char[rows + 2, columns + 2];

		for (int i = 0; i < rows + 2; i++)
		{
			mazematrix[0, i] = '#';
			mazematrix[rows + 1, i] = '#';
			mazematrix[i, 0] = '#';
			mazematrix[i, columns + 1] = '#';
		}
		
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < columns; j++)
			{
				if (matrix[i,j].GetComponent<Square>().isPainted)
				{
					mazematrix[i + 1, j + 1] = '#';
				}
				else mazematrix[i + 1, j + 1] = ' ';
				
				if (matrix[i,j].Equals(selectedSquare))
				{
					mazematrix[i + 1, j + 1] = 'S';
				}
				if (matrix[i,j].Equals(selectedSquareDest))
				{
					mazematrix[i + 1, j + 1] = 'E';
				}
			}
		}
		for (int i = 0; i < rows + 2; i++)
		{
			for (int j = 0; j < columns + 2; j++)
			{
				input[i] += mazematrix[i, j];
			}
		}
		path.generateGraph(rows + 2, columns + 2, input);
		return path.findPath();
	}

	int checkForLine(int i, int j)
	{
		Color color = matrix[i,j].transform.GetChild(0).renderer.material.color;

		// Clear Lists
		listLeft.Clear ();
		listRight.Clear ();
		listUp.Clear ();
		listDown.Clear ();
		listLine.Clear ();

		//Fill Lists

		// List Left
		for (int k = j - 1; (k >= 0) && (color == matrix[i,k].transform.GetChild(0).renderer.material.color); k--) 
			listLeft.Add(i + ";" + k);

		// List Right
		for (int k = j + 1; (k < columns) && (color == matrix[i,k].transform.GetChild(0).renderer.material.color); k++) 
			listRight.Add(i + ";" + k);

		// List Up
		for (int k = i - 1; (k >= 0) && (color == matrix[k,j].transform.GetChild(0).renderer.material.color); k--) 
			listUp.Add(k + ";" + j);

		// List Down
		for (int k = i + 1; (k < rows) && (color == matrix[k,j].transform.GetChild(0).renderer.material.color); k++) 
			listDown.Add(k + ";" + j);

		// Checks for line
		int line = 1;

		if(listLeft.Count + listRight.Count >= 2)
		{
			listLeft.AddRange(listRight);
			setDefaultColorToLine(i, j, listLeft);
			line += listLeft.Count;
		}
		if(listUp.Count + listDown.Count >= 2)
		{
			listUp.AddRange(listDown);
			setDefaultColorToLine(i, j, listUp);
			line += listUp.Count;
		}

		return line;
	}

	void setDefaultColorToLine(int i, int j, List<string> list)
	{
		matrix[i, j].transform.GetChild(0).renderer.material.color = Color.black;
		matrix[i, j].GetComponent<Square>().isPainted = false;
		foreach(string index in list)
		{
			int i2 = System.Convert.ToInt32(index.Split(';')[0]);
			int j2 = System.Convert.ToInt32(index.Split(';')[1]);
			matrix[i2, j2].transform.GetChild(0).renderer.material.color = Color.black;
			matrix[i2, j2].GetComponent<Square>().isPainted = false;
		}
	}
	
	Color getRandomColor()
	{
		int color = Random.Range (0, 5);

		switch (color)
		{
			case 0:
				return Color.blue;
			case 1:
				return Color.red;
			case 2:
				return Color.green;
			case 3:
				return Color.yellow;
			case 4:
				return Color.white;
			default:
				return Color.black;
		}
	}
	
}

