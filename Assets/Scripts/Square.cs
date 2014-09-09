using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {

	public bool isPainted, isClicked, isSelected, isSelectedDest;
	public SquareMatrix squareMatrixScript;
	public int i, j;
	public Animation anim;

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

	}

	private void initSquare()
	{
		isPainted = false;
		isClicked = false;
		isSelected = false;
		isSelectedDest = false;
		anim = this.gameObject.transform.GetChild (0).animation;
	}

	void OnMouseDown() 
	{
		squareMatrixScript = GameObject.FindGameObjectWithTag ("Block").GetComponent<SquareMatrix> ();

		if(isPainted && squareMatrixScript.selectedSquare == null)
		{
			isSelected = true;
			squareMatrixScript.selectedSquare = this.gameObject;
			//anim.Play("Front to back");
		}
		else if(!isPainted && squareMatrixScript.selectedSquare != null)
		{
			isSelectedDest = true;
			squareMatrixScript.selectedSquare.transform.GetChild (0).animation.Play("Rotation up");
			squareMatrixScript.selectedSquareDest = this.gameObject;
			squareMatrixScript.selectedSquareDest.transform.GetChild (0).animation.Play("Rotation down");
		}
		else if(isPainted && squareMatrixScript.selectedSquare != null)
		{
			isSelected = true;
			//squareMatrixScript.selectedSquare.transform.GetChild (0).animation.Play("Back to front rotation");
			squareMatrixScript.selectedSquare = this.gameObject;
			//squareMatrixScript.selectedSquare.transform.GetChild (0).animation.Play("Front to back");
			squareMatrixScript.selectedSquareDest = null;
		}
	}

	void OnMouseUp() 
	{
		//if(squareMatrixScript.selectedSquare == null)
			//anim.Play("Back to front rotation");
	}

}
