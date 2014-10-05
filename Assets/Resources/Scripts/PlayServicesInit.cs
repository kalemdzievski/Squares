using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class PlayServicesInit : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}

	// Use this for initialization
	void Awake () {
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();

		// authenticate user:
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
