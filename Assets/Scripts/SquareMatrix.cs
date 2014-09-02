using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class SquareMatrix : MonoBehaviour
{
	public GameObject square, selectedSquare, selectedSquareDest;
	public int rows, columns, offset, randomSquaresPainted;
	public GameObject [,] matrix;

	void Awake()
	{
		rows = 6;
		columns = 6;
		initMatrix (rows, columns);
		paintRandomSquares (5);
	}

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void initMatrix(int rows, int columns)
	{
		matrix = new GameObject[rows, columns];

		for (int i = 0; i < rows; i++) 
		{
			for (int j = 0; j < columns; j++) 
			{
				GameObject squareObject = (GameObject) Instantiate(square);
				//Color squareColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f), 1.0f);
				//squareObject.renderer.material.color = squareColor;
				Vector3 squarePosition = new Vector3(squareObject.transform.position.x + offset * j, squareObject.transform.position.y - offset * i, squareObject.transform.position.z);
				squareObject.transform.position = squarePosition;
				matrix[i,j] = squareObject;
			}
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
			Debug.Log("paintedSquares: " + paintedSquares);
			Debug.Log("rows: " + rows);
			Debug.Log("columns: " + columns);
			i = Random.Range(0, rows);
			j = Random.Range(0, columns);
			Debug.Log("i: " + i + " ,j: " + j);
			squareObject = matrix[i,j];
			squareScript = squareObject.GetComponent<Square>();
			
			if(!squareScript.isPainted)
			{
				Color squareColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
				squareObject.renderer.material.color = squareColor;
				squareScript.isPainted = true;
				paintedSquares++;
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
	
}

