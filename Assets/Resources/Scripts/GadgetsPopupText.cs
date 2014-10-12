using UnityEngine;
using System.Collections;

public class GadgetsPopupText : MonoBehaviour {

	public float duration;
	public float seconds;
	public Vector3 to;

	// Use this for initialization
	void Start () {
		duration = 2.0f;
		seconds  = 0.0f;
		to 		 = new Vector3 (transform.position.x, transform.position.y + 0.05f, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		seconds = seconds + Time.deltaTime;
		if (seconds > duration && guiText.color.a == 0) {
			Destroy(gameObject);		
		}
		
		Color c = Color.white;
		float ratio = seconds / duration;
		if (seconds <= duration / 2.0f) {
			c.a = Mathf.Lerp(0.0f,1.0f, ratio / 0.9f);
			guiText.color = c;
		}
		else {
			c.a = Mathf.Lerp(1.0f,0.0f, ratio / 0.9f);
			guiText.color = c;			
		}
		transform.position = Vector3.Lerp (transform.position, to, ratio / 10);
	}

	public void setText(string text) {
		guiText.text = text;
	}
}
