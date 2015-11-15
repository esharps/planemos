using UnityEngine;
using System.Collections;

public class TutorialManagerTF : MonoBehaviour {

	public static int GAME_STATE;
	public GameObject uiCamera;
	public GameObject quitButton;
	public GameObject nextButton;
	public GameObject prevButton;
	public GameObject loginText;
	public GameObject menuPage1Text;
	//public GameObject menuPage2Text;

	// Use this for initialization
	void Start () {
		GAME_STATE = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
		// If the hologram has been full rendered, render UI camera
		if (MainMenuStartupTF.menuFinished == 1 && GAME_STATE == 0) {
			runState0();
		} 

		switch (GAME_STATE) 
		{
			case 1:
			//Debug.Log ("GAME_STATE: 1");
				runState1();
				break;

				


		}
			

	}

	// In GAME_STATE 0, game runs automated subroutine that simulates
	// running the tutorial as a program
	// GAME_STATE is changed by AutoTypeTF class through coroutine
	public void runState0() {

		uiCamera.SetActive (true);
		quitButton.SetActive (true);
		loginText.SetActive (true);

	}

	// In GAME_STATE 1, the tutorial prints first page of text
	// 
	public void runState1() {

		loginText.SetActive (false);
		nextButton.SetActive (true);
		menuPage1Text.SetActive (true);

	}

}
