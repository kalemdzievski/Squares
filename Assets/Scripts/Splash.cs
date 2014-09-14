using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour
{
	public float UpTimeSpeed = 1;
	public float WaitingTime = 3;
	public float DownTimeSpeed = 1;
	
	private GUITexture splash;
	
	IEnumerator Start()
	{
		Color c = Color.white;
		c.a = 0;
		splash = (GetComponent(typeof(GUITexture)) as GUITexture);
		splash.color = c;
		
		while (c.a < 1)
		{
			c.a += Time.deltaTime * UpTimeSpeed;
			splash.color = c;
			yield return null;
		}
		yield return new WaitForSeconds(WaitingTime);
		while (c.a > 0)
		{
			c.a -= Time.deltaTime * DownTimeSpeed;
			splash.color = c;
			yield return null;
		}
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
}