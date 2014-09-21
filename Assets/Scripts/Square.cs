using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {

	public bool isPainted;
	public bool isSelected;
	public bool isSelectedDest;
	public SquareMatrix squareMatrixScript;
	public int i, j;
	public Animation anim;

	private void initSquare()
	{
		isPainted = false;
		isSelected = false;
		isSelectedDest = false;
		anim = this.gameObject.transform.GetChild (0).animation;
	}

	void Awake()
	{
		Debug.Log ("SQUARE");
		initSquare ();
		squareMatrixScript = GameObject.FindGameObjectWithTag ("Block").GetComponent<SquareMatrix> ();
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
		}
		else if(!isPainted && squareMatrixScript.selectedSquare != null)
		{
			squareMatrixScript.selectedSquareDest = this.gameObject;
			if(squareMatrixScript.path())
			{
				isSelectedDest = true;
				squareMatrixScript.move ();
				squareMatrixScript.selectedSquare.transform.GetChild (0).animation.Play("Rotation up");
				squareMatrixScript.selectedSquare.transform.GetChild (0).animation.Play("Deselect");
				squareMatrixScript.selectedSquareDest.transform.GetChild (0).animation.Play("Rotation down");
			}
			else
			{
				isSelectedDest = false;
				squareMatrixScript.selectedSquareDest = null;
			}

		}
		else if(isPainted && squareMatrixScript.selectedSquare != null)
		{
			isSelected = true;
			squareMatrixScript.selectedSquare.GetComponent<Square>().isSelected = false;
			squareMatrixScript.selectedSquare.transform.GetChild (0).animation.Play("Deselect");
			squareMatrixScript.selectedSquare = this.gameObject;
			squareMatrixScript.selectedSquare.transform.GetChild (0).animation.Play("Select");
		}

	}

}
