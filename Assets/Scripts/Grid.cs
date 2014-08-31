using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public GameObject quad;
	public int width = 6;
	public int height = 6;

	public GameObject [,] grid = new GameObject[6,6];

	void Awake ()
	{
		for (int x=0; x<width; x++) {
			for (int y=0; y<height; y++) {
				GameObject gridQuad = (GameObject)Instantiate(quad);
				//gridQuad.transform.position = new Vector2(gridQuad.transform.position.x+4*x, gridQuad.transform.position.y+4*y);
				gridQuad.transform.position = new Vector3(gridQuad.transform.position.x+4*x, gridQuad.transform.position.y+4*y, gridQuad.transform.position.z);
				grid[x,y] = gridQuad;
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
