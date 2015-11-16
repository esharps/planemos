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
	public GameObject menuPage2Text;

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
			case 2:
				runState2();
				break;

				


		}
			

	}

	// In GAME_STATE 0, game runs AUTOMATED subroutine that simulates
	// running the tutorial as a program
	// GAME_STATE is changed to 1 by AutoTypeTF class through coroutine
	// (i.e.) state change is NOT driven by user
	public void runState0() {

		// Always active game objects in scene
		uiCamera.SetActive (true);
		quitButton.SetActive (true);

		// Active game objects in state 0
		loginText.SetActive (true);

		// Disabled objects in state 0
		nextButton.SetActive (false);
		prevButton.SetActive (false);
		menuPage1Text.SetActive (false);
		menuPage2Text.SetActive (false);

	}

	// In GAME_STATE 1, the tutorial prints first page of text
	// GAME_STATE is changed to 2 by user clicking NEXT button
	public void runState1() {

		nextButton.SetActive (true);
		menuPage1Text.SetActive (true);

		loginText.SetActive (false);
		prevButton.SetActive (false);
		menuPage2Text.SetActive (false);
	}

	// IN GAME_STATE 2, tutorial prints second page of text
	// GAME_STATE changed to 3 by user clicking NEXT button
	// GAME_STAE changed to 1 by user clicking PREV button
	public void runState2() {

		nextButton.SetActive (true);
		prevButton.SetActive (true);
		menuPage2Text.SetActive (true);
		
		loginText.SetActive (false);
		menuPage1Text.SetActive (false);
	

	}

}
