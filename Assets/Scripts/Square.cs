using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {

	public bool isPainted, isClicked, isSelected;
	public SquareMatrix squareMatrixScript;

	void OnMouseDown() 
	{
		Debug.Log("clicked");
		isClicked = isClicked ? false : true;

		squareMatrixScript = GameObject.FindGameObjectWithTag ("Block").GetComponent<SquareMatrix> ();
		if (squareMatrixScript.selectedSquare == null) 
		{
			isSelected = true;
			squareMatrixScript.selectedSquare = this.gameObject;
		}
		else
		{
			renderer.material.color = squareMatrixScript.selectedSquare.renderer.material.color;
			squareMatrixScript.selectedSquare = null;
		}
	}

	void Awake()
	{
		initSquare ();
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isSelected) {
			renderer.material.color -= Color.white / 1.1f * Time.deltaTime;
			if(renderer.transform.rotation.y < 1)
				renderer.transform.Rotate(0,3,0);
		}
	}

	private void initSquare()
	{
		isPainted = false;
		isClicked = false;
		isSelected = false;
	}
}
