using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {
	
	public bool isPainted, isClicked, isSelected;

	void OnMouseDown() 
	{
		Debug.Log("clicked");
		isClicked = isClicked ? false : true;
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
		if (isClicked) {
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
