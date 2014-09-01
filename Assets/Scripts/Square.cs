using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {
	

	bool clicked = false;

	void OnMouseDown() {
		Debug.Log("clicked");
		clicked = clicked ? false : true;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (clicked) {
			renderer.material.color -= Color.white / 1.1f * Time.deltaTime;
			if(renderer.transform.rotation.y < 1)
				renderer.transform.Rotate(0,3,0);
		}
	}
}
