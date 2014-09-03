using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class SquareMatrix : MonoBehaviour
{
	public GameObject square, selectedSquare, selectedSquareDest;
	public int rows, columns, offset, randomSquaresPainted;
	public float squareWidth;
	public GameObject [,] matrix;

	void Awake()
	{

	}

	// Use this for initialization
	void Start ()
	{
		rows = 6;
		columns = 6;
		offset = 4;
		squareWidth = 3.5f;
		selectedSquare = null;
		selectedSquareDest = null;
		initMatrix (rows, columns);
		paintRandomSquares (5);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (selectedSquare != null && selectedSquareDest != null) 
		{
			if(path())
			{
				Color selectedSquareColor = selectedSquare.renderer.material.color;
				Color selectedSquareDestColor = selectedSquareDest.renderer.material.color;
				selectedSquare.renderer.material.color = selectedSquareDestColor;
				selectedSquareDest.renderer.material.color = selectedSquareColor;
				selectedSquare.GetComponent<Square>().isPainted = false;
				selectedSquareDest.GetComponent<Square>().isPainted = true;
				if(!hasLine(selectedSquareDest.GetComponent<Square>().i, selectedSquareDest.GetComponent<Square>().j))
					paintRandomSquares(5);
				selectedSquare = null;
				selectedSquareDest = null;
			}
			else 
			{
				selectedSquare = null;
				selectedSquareDest = null;
			}
		}
	}

	void initMatrix(int rows, int columns)
	{
		matrix = new GameObject[rows, columns];

		for (int i = 0; i < rows; i++) 
		{
			for (int j = 0; j < columns; j++) 
			{
				GameObject squareObject = (GameObject) Instantiate(square);
				squareObject.renderer.material.color = Color.black;
				Vector3 squarePosition = new Vector3(squareObject.transform.position.x + offset * j, squareObject.transform.position.y - offset * i, squareObject.transform.position.z);
				squareObject.transform.position = squarePosition;
				squareObject.GetComponent<Square>().i = i;
				squareObject.GetComponent<Square>().j = j;
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
			i = Random.Range(0, rows);
			j = Random.Range(0, columns);
			squareObject = matrix[i,j];
			squareScript = squareObject.GetComponent<Square>();
			
			if(!squareScript.isPainted)
			{
				Color squareColor = getRandomColor();
				squareObject.renderer.material.color = squareColor;
				squareScript.isPainted = true;
				if(!hasLine(i, j))
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
					Debug.Log("SELECTED");
					mazematrix[i + 1, j + 1] = 'S';
				}
				if (matrix[i,j].Equals(selectedSquareDest))
				{
					Debug.Log("DESTINATION");
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

	public bool hasLine(int i, int j)
	{
		Color color = matrix[i,j].renderer.material.color;
		if (i == 0 && j == 0) // GOREN - LEV KOSH
		{
			if (color != matrix[i,j + 1].renderer.material.color && color != matrix[i + 1,j].renderer.material.color)
				return false;
			else
			{
				if (color == matrix[i,j + 1].renderer.material.color && color == matrix[i,j + 2].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i, j + 1].renderer.material.color = Color.black;
					matrix[i, j + 2].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i, j + 1].GetComponent<Square>().isPainted = false;
					matrix[i, j + 2].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if (color == matrix[i + 1,j].renderer.material.color && color == matrix[i + 2,j].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i + 1, j].renderer.material.color = Color.black;
					matrix[i + 2, j].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i + 1, j].GetComponent<Square>().isPainted = false;
					matrix[i + 2, j].GetComponent<Square>().isPainted = false;
					return true;
				}
				else return false;
			}
		}
		else if (i == 0 && j == (columns - 1)) // GOREN - DESEN KOSH
		{
			if (color != matrix[i,j - 1].renderer.material.color && color != matrix[i + 1,j].renderer.material.color)
				return false;
			else
			{
				if (color == matrix[i,j - 1].renderer.material.color && color == matrix[i,j - 2].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i, j - 1].renderer.material.color = Color.black;
					matrix[i, j - 2].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i, j - 1].GetComponent<Square>().isPainted = false;
					matrix[i, j - 2].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if (color == matrix[i + 1,j].renderer.material.color && color == matrix[i + 2,j].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i + 1, j].renderer.material.color = Color.black;
					matrix[i + 2, j].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i + 1, j].GetComponent<Square>().isPainted = false;
					matrix[i + 2, j].GetComponent<Square>().isPainted = false;
					return true;
				}
				else return false;
			}
		}
		else if (i == (rows - 1) && j == 0) // DOLEN - LEV KOSH
		{
			if (color != matrix[i,j + 1].renderer.material.color && color != matrix[i - 1,j].renderer.material.color)
				return false;
			else
			{
				if (color == matrix[i,j + 1].renderer.material.color && color == matrix[i,j + 2].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i, j + 1].renderer.material.color = Color.black;
					matrix[i, j + 2].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i, j + 1].GetComponent<Square>().isPainted = false;
					matrix[i, j + 2].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if (color == matrix[i - 1,j].renderer.material.color && color == matrix[i - 2,j].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i - 1, j].renderer.material.color = Color.black;
					matrix[i - 2, j].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i - 1, j].GetComponent<Square>().isPainted = false;
					matrix[i - 2, j].GetComponent<Square>().isPainted = false;
					return true;
				}
				else return false;
			}
		}
		else if (i == (rows - 1) && j == (columns - 1)) // DOLEN - DESEN KOSH
		{
			if (color != matrix[i,j - 1].renderer.material.color && color != matrix[i - 1,j].renderer.material.color)
				return false;
			else
			{
				if (color == matrix[i,j - 1].renderer.material.color && color == matrix[i,j - 2].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i, j - 1].renderer.material.color = Color.black;
					matrix[i, j - 2].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i, j - 1].GetComponent<Square>().isPainted = false;
					matrix[i, j - 2].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if (color == matrix[i - 1,j].renderer.material.color && color == matrix[i - 2,j].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i - 1, j].renderer.material.color = Color.black;
					matrix[i - 2, j].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i - 1, j].GetComponent<Square>().isPainted = false;
					matrix[i - 2, j].GetComponent<Square>().isPainted = false;
					return true;
				}
				else return false;
			}
		}
		else if (i == 0) // PRVA REDICA
		{
			if (color != matrix[i,j - 1].renderer.material.color && color != matrix[i,j + 1].renderer.material.color && color != matrix[i + 1,j].renderer.material.color)
				return false;
			else if (color == matrix[i,j - 1].renderer.material.color && color == matrix[i,j + 1].renderer.material.color)
			{
				matrix[i, j].renderer.material.color = Color.black;
				matrix[i, j - 1].renderer.material.color = Color.black;
				matrix[i, j + 1].renderer.material.color = Color.black;
				matrix[i, j].GetComponent<Square>().isPainted = false;
				matrix[i, j - 1].GetComponent<Square>().isPainted = false;
				matrix[i, j + 1].GetComponent<Square>().isPainted = false;
				return true;
			}
			else
			{
				if ((j - 2) >= 0 && color == matrix[i,j - 1].renderer.material.color && color == matrix[i,j - 2].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i, j - 1].renderer.material.color = Color.black;
					matrix[i, j - 2].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i, j - 1].GetComponent<Square>().isPainted = false;
					matrix[i, j - 2].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if ((j + 2) <= (columns - 1) && color == matrix[i,j + 1].renderer.material.color && color == matrix[i,j + 2].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i, j + 1].renderer.material.color = Color.black;
					matrix[i, j + 2].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i, j + 1].GetComponent<Square>().isPainted = false;
					matrix[i, j + 2].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if (color == matrix[i + 1,j].renderer.material.color && color == matrix[i + 2,j].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i + 1, j].renderer.material.color = Color.black;
					matrix[i + 2, j].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i + 1, j].GetComponent<Square>().isPainted = false;
					matrix[i + 2, j].GetComponent<Square>().isPainted = false;
					return true;
				}
				else return false;
			}
		}
		else if (i == (rows - 1)) // POSLEDNA REDICA
		{
			if (color != matrix[i,j - 1].renderer.material.color && color != matrix[i,j + 1].renderer.material.color && color != matrix[i - 1,j].renderer.material.color)
				return false;
			else if (color == matrix[i,j - 1].renderer.material.color && color == matrix[i,j + 1].renderer.material.color)
			{
				matrix[i, j].renderer.material.color = Color.black;
				matrix[i, j - 1].renderer.material.color = Color.black;
				matrix[i, j + 1].renderer.material.color = Color.black;
				matrix[i, j].GetComponent<Square>().isPainted = false;
				matrix[i, j - 1].GetComponent<Square>().isPainted = false;
				matrix[i, j + 1].GetComponent<Square>().isPainted = false;
				return true;
			}
			else
			{
				if ((j - 2) >= 0 && color == matrix[i,j - 1].renderer.material.color && color == matrix[i,j - 2].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i, j - 1].renderer.material.color = Color.black;
					matrix[i, j - 2].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i, j - 1].GetComponent<Square>().isPainted = false;
					matrix[i, j - 2].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if ((j + 2) <= (columns - 1) && color == matrix[i,j + 1].renderer.material.color && color == matrix[i,j + 2].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i, j + 1].renderer.material.color = Color.black;
					matrix[i, j + 2].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i, j + 1].GetComponent<Square>().isPainted = false;
					matrix[i, j + 2].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if (color == matrix[i - 1,j].renderer.material.color && color == matrix[i - 2,j].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i - 1, j].renderer.material.color = Color.black;
					matrix[i - 2, j].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i - 1, j].GetComponent<Square>().isPainted = false;
					matrix[i - 2, j].GetComponent<Square>().isPainted = false;
					return true;
				}
				else return false;
			}
		}
		else if (j == 0) // PRVA KOLONA
		{
			if (color != matrix[i - 1,j].renderer.material.color && color != matrix[i + 1,j].renderer.material.color && color != matrix[i,j + 1].renderer.material.color)
				return false;
			else if (color == matrix[i - 1,j].renderer.material.color && color == matrix[i + 1,j].renderer.material.color)
			{
				matrix[i, j].renderer.material.color = Color.black;
				matrix[i - 1, j].renderer.material.color = Color.black;
				matrix[i + 1, j].renderer.material.color = Color.black;
				matrix[i, j].GetComponent<Square>().isPainted = false;
				matrix[i - 1, j].GetComponent<Square>().isPainted = false;
				matrix[i + 1, j].GetComponent<Square>().isPainted = false;
				return true;
			}
			else
			{
				if (color == matrix[i,j + 1].renderer.material.color && color == matrix[i,j + 2].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i, j + 1].renderer.material.color = Color.black;
					matrix[i, j + 2].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i, j + 1].GetComponent<Square>().isPainted = false;
					matrix[i, j + 2].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if ((i - 2) >= 0 && color == matrix[i - 1,j].renderer.material.color && color == matrix[i - 2,j].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i - 1, j].renderer.material.color = Color.black;
					matrix[i - 2, j].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i - 1, j].GetComponent<Square>().isPainted = false;
					matrix[i - 2, j].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if ((i + 2) <= (rows - 1) && color == matrix[i + 1,j].renderer.material.color && color == matrix[i + 2,j].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i + 1, j].renderer.material.color = Color.black;
					matrix[i + 2, j].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i + 1, j].GetComponent<Square>().isPainted = false;
					matrix[i + 2, j].GetComponent<Square>().isPainted = false;
					return true;
				}
				else return false;
			}
		}
		else if (j == (columns - 1)) // POSLEDNA KOLONA
		{
			if (color != matrix[i - 1,j].renderer.material.color && color != matrix[i + 1,j].renderer.material.color && color != matrix[i,j - 1].renderer.material.color)
				return false;
			else if (color == matrix[i - 1,j].renderer.material.color && color == matrix[i + 1,j].renderer.material.color)
			{
				matrix[i, j].renderer.material.color = Color.black;
				matrix[i - 1, j].renderer.material.color = Color.black;
				matrix[i + 1, j].renderer.material.color = Color.black;
				matrix[i, j].GetComponent<Square>().isPainted = false;
				matrix[i - 1, j].GetComponent<Square>().isPainted = false;
				matrix[i + 1, j].GetComponent<Square>().isPainted = false;
				return true;
			}
			else
			{
				if (color == matrix[i,j - 1].renderer.material.color && color == matrix[i,j - 2].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i, j - 1].renderer.material.color = Color.black;
					matrix[i, j - 2].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i, j - 1].GetComponent<Square>().isPainted = false;
					matrix[i, j - 2].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if ((i - 2) >= 0 && color == matrix[i - 1,j].renderer.material.color && color == matrix[i - 2,j].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i - 1, j].renderer.material.color = Color.black;
					matrix[i - 2, j].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i - 1, j].GetComponent<Square>().isPainted = false;
					matrix[i - 2, j].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if ((i + 2) <= (rows - 1) && color == matrix[i + 1,j].renderer.material.color && color == matrix[i + 2,j].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i + 1, j].renderer.material.color = Color.black;
					matrix[i + 2, j].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i + 1, j].GetComponent<Square>().isPainted = false;
					matrix[i + 2, j].GetComponent<Square>().isPainted = false;
					return true;
				}
				else return false;
			}
		}
		else // SITE IZMEGJU
		{
			if (color != matrix[i - 1,j].renderer.material.color && color != matrix[i + 1,j].renderer.material.color && color != matrix[i,j + 1].renderer.material.color && color != matrix[i,j - 1].renderer.material.color)
				return false;
			else if (color == matrix[i - 1,j].renderer.material.color && color == matrix[i + 1,j].renderer.material.color)
			{
				matrix[i, j].renderer.material.color = Color.black;
				matrix[i - 1, j].renderer.material.color = Color.black;
				matrix[i + 1, j].renderer.material.color = Color.black;
				matrix[i, j].GetComponent<Square>().isPainted = false;
				matrix[i - 1, j].GetComponent<Square>().isPainted = false;
				matrix[i + 1, j].GetComponent<Square>().isPainted = false;
				return true;
			}
			else if (color == matrix[i,j - 1].renderer.material.color && color == matrix[i,j + 1].renderer.material.color)
			{
				matrix[i, j].renderer.material.color = Color.black;
				matrix[i, j - 1].renderer.material.color = Color.black;
				matrix[i, j + 1].renderer.material.color = Color.black;
				matrix[i, j].GetComponent<Square>().isPainted = false;
				matrix[i, j - 1].GetComponent<Square>().isPainted = false;
				matrix[i, j + 1].GetComponent<Square>().isPainted = false;
				return true;
			}
			else
			{
				if ((j - 2) >= 0 && color == matrix[i,j - 1].renderer.material.color && color == matrix[i,j - 2].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i, j - 1].renderer.material.color = Color.black;
					matrix[i, j - 2].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i, j - 1].GetComponent<Square>().isPainted = false;
					matrix[i, j - 2].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if ((j + 2) <= (columns - 1) && color == matrix[i,j + 1].renderer.material.color && color == matrix[i,j + 2].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i, j + 1].renderer.material.color = Color.black;
					matrix[i, j + 2].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i, j + 1].GetComponent<Square>().isPainted = false;
					matrix[i, j + 2].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if ((i - 2) >= 0 && color == matrix[i - 1,j].renderer.material.color && color == matrix[i - 2,j].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i - 1, j].renderer.material.color = Color.black;
					matrix[i - 2, j].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i - 1, j].GetComponent<Square>().isPainted = false;
					matrix[i - 2, j].GetComponent<Square>().isPainted = false;
					return true;
				}
				else if ((i + 2) <= (rows - 1) && color == matrix[i + 1,j].renderer.material.color && color == matrix[i + 2,j].renderer.material.color)
				{
					matrix[i, j].renderer.material.color = Color.black;
					matrix[i + 1, j].renderer.material.color = Color.black;
					matrix[i + 2, j].renderer.material.color = Color.black;
					matrix[i, j].GetComponent<Square>().isPainted = false;
					matrix[i + 1, j].GetComponent<Square>().isPainted = false;
					matrix[i + 2, j].GetComponent<Square>().isPainted = false;
					return true;
				}
				else return false;
			}
		}
	}

	public Color getRandomColor()
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

