using UnityEngine;
using System.Collections;

public class SquareMatrix : MonoBehaviour
{
	public GameObject square;
	public int rows, columns, offset;
	public GameObject [,] matrix;

	void Awake()
	{
		initMatrix (rows, columns);
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
		GameObject [,] matrix = new GameObject[rows, columns];

		for (int i=0; i<rows; i++) 
		{
			for (int j=0; j<columns; j++) 
			{
				GameObject squareObject = (GameObject) Instantiate(square);
				Color squareColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),Random.Range(0.0f, 1.0f), 1.0f);
				squareObject.renderer.material.color = squareColor;
				Vector3 squarePosition = new Vector3(squareObject.transform.position.x + offset * j, squareObject.transform.position.y - offset * i, squareObject.transform.position.z);
				squareObject.transform.position = squarePosition;
				matrix[i,j] = squareObject;
			}
		}
	}
}

