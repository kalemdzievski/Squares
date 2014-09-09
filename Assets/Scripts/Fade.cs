using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
	enum EaseType {None, In, Out, InOut}
	static Fade use;
	
	void  Awake (){
		if (use) {
			Debug.LogWarning("Only one instance of the Fade script in a scene is allowed");
			return;
		}
		use = this;
	}
	
	void  Alpha (Material material, float start, float end, float timer){
		Alpha(material, start, end, timer, EaseType.None);
	}
	
	void  Alpha (Material material, float start, float end, float timer, EaseType easeType){

		float t = 0.0f;
		while (t < 1.0f) {
			t += Time.deltaTime * (1.0f/timer);
			Color color = material.color;
			color.a = Mathf.Lerp(start, end, Ease(t, easeType)) * 0.5f;
			material.color = color;
		}
	}
	
	void  Colors (Material material, Color start , Color end, float timer){
		Colors(material, start, end, timer, EaseType.None);
	}
	
	void  Colors (Material material, Color start, Color end, float timer, EaseType easeType){

		float t = 0.0f;
		while (t < 1.0f) {
			t += Time.deltaTime * (1.0f/timer);
			Color color = material.color;
			color = Color.Lerp(start, end, Ease(t, easeType)) * 0.5f;
			material.color = color;
		}
	}
	
	void  Colors (Material material , Color[] colorRange , float timer , bool repeat){

		if (colorRange.Length < 2) {
			Debug.LogError("Error: color array must have at least 2 entries");
			return;
		}
		timer /= colorRange.Length;
		int i = 0;

		while (true) {
			float t = 0.0f;
			while (t < 1.0f) {
				t += Time.deltaTime * (1.0f/timer);
				Color color = material.color;
				color = Color.Lerp(colorRange[i], colorRange[(i+1) % colorRange.Length], t) * 0.5f;
				material.color = color;
			}
			i = ++i % colorRange.Length;
			if (!repeat && i == 0) break;
		}	
	}
	
	private float Ease (float t, EaseType easeType){
		if (easeType == EaseType.None)
			return t;
		else if (easeType == EaseType.In)
			return Mathf.Lerp(0.0f, 1.0f, 1.0f - Mathf.Cos(t * Mathf.PI * 0.5f));
		else if (easeType == EaseType.Out)
			return Mathf.Lerp(0.0f, 1.0f, Mathf.Sin(t * Mathf.PI * 0.5f));
		else
			return Mathf.SmoothStep(0.0f, 1.0f, t);
	}
}