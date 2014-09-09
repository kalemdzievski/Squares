//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;

namespace AssemblyCSharp
{
	public class Fade2
	{
		public enum EaseType {None, In, Out, InOut}
		public static Fade2 use;
		
		public static Fade2 getInstance (){
			if (use == null)
				use = new Fade2();
			return use;
		}
		
		public void  Alpha (Material material, float start, float end, float timer){
			Alpha(material, start, end, timer, EaseType.None);
		}
		
		public void  Alpha (Material material, float start, float end, float timer, EaseType easeType){
			
			float t = 0.0f;
			while (t < 1.0f) {
				t += Time.deltaTime * (1.0f/timer);
				Color color = material.color;
				color.a = Mathf.Lerp(start, end, Ease(t, easeType)) * 0.5f;
				material.color = color;
			}
		}
		
		public void  Colors (Material material, Color start , Color end, float timer){
			Colors(material, start, end, timer, EaseType.None);
		}
		
		public void  Colors (Material material, Color start, Color end, float timer, EaseType easeType){
			
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
		
		public  float Ease (float t, EaseType easeType){
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
}

