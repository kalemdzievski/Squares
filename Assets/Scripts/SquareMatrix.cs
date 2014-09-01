using UnityEngine;
using System.Collections;

public class SquareMatrix : MonoBehaviour
{
	public GameObject square;
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

}

