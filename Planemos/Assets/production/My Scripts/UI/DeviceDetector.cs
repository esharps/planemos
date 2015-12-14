using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeviceDetector : MonoBehaviour {


	Text resolutionDisplay; 

	// Use this for initialization
	void Start () {

		resolutionDisplay = GetComponent<Text> ();
		resolutionDisplay.text = Screen.currentResolution.ToString ();
		StartCoroutine (TimeDelay ());
	}
	
	// Update is called once per frame
	void Update () {

	}



	void DeviceDetection() {

		//iPhone 5
		if (Screen.currentResolution.ToString ().Contains ("1136"))
			Application.LoadLevel ("Main Menu iPhone Master");

		//iPhone 6
		else if (Screen.currentResolution.ToString ().Contains ("1334"))
			Application.LoadLevel ("Main Menu iPhone Master");

		//iPhone 6S
		else if (Screen.currentResolution.ToString ().Contains ("2208"))
			Application.LoadLevel ("Main Menu iPhone Master");

		//iPad Mini
		else if (Screen.currentResolution.ToString ().Contains ("1024"))
			Application.LoadLevel ("Main Menu iPad Master");

		//iPad Air
		else if (Screen.currentResolution.ToString ().Contains ("2048"))
			Application.LoadLevel ("Main Menu iPad Master");
		else
			Application.LoadLevel ("Main Menu iPad Master");
	}
	
	IEnumerator TimeDelay() {

		Debug.Log ("Start Coroutine");

		//iPhone 5
		if (Screen.currentResolution.ToString ().Contains ("1136"))
			resolutionDisplay.text = "iPhone 5 Detected";
		
		//iPhone 6
		else if (Screen.currentResolution.ToString ().Contains ("1334"))
			resolutionDisplay.text = "iPhone 6 Detected";
		
		//iPhone 6S
		else if (Screen.currentResolution.ToString ().Contains ("2208"))
			resolutionDisplay.text = "iPhone 6 Plus Detected";
		
		//iPad Mini
		else if (Screen.currentResolution.ToString ().Contains ("1024"))
			resolutionDisplay.text = "iPad Mini Detected";
		
		//iPad Air
		else if (Screen.currentResolution.ToString ().Contains ("2048"))
			resolutionDisplay.text = "iPad Air Detected";
		else
			resolutionDisplay.text = "Non-iOS Device Detected";

		yield return new WaitForSeconds (4.0f);
		//Ready to run terminal login sequence
		DeviceDetection ();


	}
}
