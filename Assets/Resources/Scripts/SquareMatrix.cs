using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class SquareMatrix : MonoBehaviour
{
	public GUIStyle GameOverBox = null;
	public GameObject square;
	public GameObject selectedSquare;
	public GameObject selectedSquareDest;
	public GameObject gameOverPopUp;
	private Color selectedSquareColor;
	private Color selectedSquareDestColor;
	public int rows;
	public int columns;
	public int randomSquaresPainted;
	public int paintedSquares;
	public int score;
	public int combo;
	public float offset;
	public GameObject [,] matrix;
	public Gadgets gadgetsScript;
	private List<string> listLeft;
	private List<string> listRight;
	private List<string> listDown;
	private List<string> listUp;
	private List<string> listLine;
	public SquareColors colors;
	public bool matrixFull = false;
	public string FinalScore = string.Empty;

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
		offset = 3.8f;
		score = 0;
		combo = 0;
		paintedSquares = 0;
		randomSquaresPainted = 4;
		listLeft = new List<string>();
		listRight = new List<string>();
		listDown = new List<string>();
		listUp = new List<string>();
		listLine = new List<string>();
		selectedSquare = null;
		selectedSquareDest = null;
		selectedSquareColor = Color.clear;
		selectedSquareDestColor = Color.clear;
		colors = new SquareColors ();
		gadgetsScript = GameObject.FindGameObjectWithTag ("Gadgets").GetComponent<Gadgets> ();
	}
	
	void Awake()
	{
		Debug.Log ("SQUARE MATRIX");
		initVariables ();
		initMatrix (rows, columns);
		paintRandomSquares (randomSquaresPainted);
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
			selectedSquare.transform.GetChild(0).renderer.material.color = Color.Lerp(selectedSquareColor, selectedSquareDestColor, Time.time);
			selectedSquareDest.transform.GetChild(0).renderer.material.color = Color.Lerp(selectedSquareDestColor, selectedSquareColor, Time.time);
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
				paintRandomSquares(randomSquaresPainted);
				combo = 0;
			}
			else {
				if(combo != 0)
					score += line * 10 * combo;
				else
					score += line * 10;
				paintedSquares -= line;		
				combo++;
			}

			GameObject.FindGameObjectWithTag ("Score").guiText.text = score.ToString();
			GameObject.FindGameObjectWithTag ("Combo").guiText.text = "x" + combo.ToString();
		}
	}

	void paintRandomSquares(int numberOfSquares)
	{
		if (gadgetsScript.noSquares)
			return;

		int randomPaintedSquares = 0;
		int i, j;
		GameObject squareObject;
		Square squareScript;
		
		while(randomPaintedSquares < numberOfSquares)
		{
			i = Random.Range(0, rows);
			j = Random.Range(0, columns);
			squareObject = matrix[i,j];
			squareScript = squareObject.GetComponent<Square>();

			if(!squareScript.isPainted)
			{
				Color squareColor = getRandomColor();
				squareObject.transform.GetChild(0).renderer.material.color = squareColor;
				squareObject.transform.GetChild(0).transform.localScale = new Vector3(4.3f, 4.3f, 0.8f);
				squareObject.transform.GetChild(0).animation.Play("Deselect");
				squareScript.isPainted = true;
				randomPaintedSquares++;
				paintedSquares++;
				int line = checkForLine(i, j);
				if(line != 1){
					if(combo != 0)
						score += line * 10 * combo;
					else
						score += line * 10;
					paintedSquares -= line;
					combo++;
				}
			}

			if(paintedSquares >= 49)
			{
				Instantiate(gameOverPopUp);
				Destroy(gadgetsScript);
				Destroy(GameObject.FindGameObjectWithTag("ComboText"));
				Destroy(GameObject.FindGameObjectWithTag("Combo"));
				Destroy(GameObject.FindGameObjectWithTag("ScoreText"));
				Destroy(GameObject.FindGameObjectWithTag("Score"));

				Social.ReportScore(score, "CgkIip-4vp4DEAIQBg", (bool success) => {
					// handle success or failure
				});

				Debug.Log("GAME OVER");
				break;
			}
			if(paintedSquares <= 0)
				paintRandomSquares(randomSquaresPainted);
		}
	}

	//Path algorithm
	public bool path()
	{
		if (gadgetsScript.freeMove)
			return true;

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

		if(listLeft.Count + listRight.Count >= 3)
		{
			listLeft.AddRange(listRight);
			setDefaultColorToLine(i, j, listLeft);
			line += listLeft.Count;
		}
		if(listUp.Count + listDown.Count >= 3)
		{
			listUp.AddRange(listDown);
			setDefaultColorToLine(i, j, listUp);
			line += listUp.Count;
		}

		return line;
	}

	void setDefaultColorToLine(int i, int j, List<string> list)
	{
		matrix[i, j].transform.GetChild(0).renderer.material.color = colors.GREY;
		matrix[i, j].GetComponent<Square>().isPainted = false;
		foreach(string index in list)
		{
			int i2 = System.Convert.ToInt32(index.Split(';')[0]);
			int j2 = System.Convert.ToInt32(index.Split(';')[1]);
			matrix[i2, j2].transform.GetChild(0).renderer.material.color = colors.GREY;
			matrix[i2, j2].GetComponent<Square>().isPainted = false;
		}
	}
	
	Color getRandomColor()
	{
		int color = Random.Range (0, randomSquaresPainted);

		switch (color)
		{
			case 0:
				return colors.RED;
			case 1:
				return colors.BLUE;
			case 2:
				return colors.YELLOW;
			case 3:
				return colors.GREEN;
			case 4:
				return colors.PURPLE;
			case 5:
				return colors.ORANGE;
			case 6:
				return colors.TEAL;
			case 7:
				return colors.WHITE;
			default:
				return colors.RED;
				
		}
	}
	
}

