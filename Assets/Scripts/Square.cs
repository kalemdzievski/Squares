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
		}
		else if(!isPainted && squareMatrixScript.selectedSquare != null)
		{
			isSelectedDest = true;
			squareMatrixScript.selectedSquareDest = this.gameObject;
		}
		else if(isPainted && squareMatrixScript.selectedSquare != null)
		{
			isSelected = true;
			squareMatrixScript.selectedSquare = this.gameObject;
			squareMatrixScript.selectedSquareDest = null;
		}

		//anim.Play("Test anim");
	}

}
