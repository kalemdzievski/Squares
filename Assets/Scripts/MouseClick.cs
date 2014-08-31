using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {

	private Vector3 vec = new Vector3(0,5,0);
	private bool clicked = false;

	void OnMouseDown() 
	{
		Debug.Log ("clicked");
		clicked = clicked ? false : true;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (clicked) {
			renderer.transform.Rotate (vec);
		}
	}
}
