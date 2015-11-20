using UnityEngine;
using System.Collections;

public class TutorialMenuManagerTF : MonoBehaviour {

	public static int GAME_STATE;

	//Separate Camera for UI rendering
	public GameObject uiCamera;

	//UI Elements
	public GameObject quitButton;
	public GameObject nextButton;
	public GameObject prevButton;
	public GameObject playButton;
	public GameObject loginText;
	public GameObject menuPage1Text;
	public GameObject menuPage2Text;
	public GameObject menuPage3Text;


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
			case 3:
				runState3();
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
		playButton.SetActive (false);
		menuPage1Text.SetActive (false);
		menuPage2Text.SetActive (false);
		menuPage3Text.SetActive (false);

	}

	// In GAME_STATE 1, the tutorial prints first page of text
	// GAME_STATE is changed to 2 by user clicking NEXT button
	public void runState1() {

		loginText.SetActive (false);
		nextButton.SetActive (false);
		prevButton.SetActive (false);
		playButton.SetActive (false);
		menuPage2Text.SetActive (false);
		menuPage3Text.SetActive (false);

		menuPage1Text.SetActive (true);

		if (TutorialTyperTF.textFinishLoading == 1) {
			nextButton.SetActive (true);
		}
	}

	// IN GAME_STATE 2, tutorial prints second page of text
	// GAME_STATE changed to 3 by user clicking NEXT button
	// GAME_STAE changed to 1 by user clicking PREV button
	public void runState2() {

		prevButton.SetActive (false);
		nextButton.SetActive (false);
		loginText.SetActive (false);
		playButton.SetActive (false);
		menuPage1Text.SetActive (false);
		menuPage3Text.SetActive (false);

		// Activate Page 2
		menuPage2Text.SetActive (true);

		if (TutorialTyperTF.textFinishLoading == 1) {
			nextButton.SetActive (true);
			prevButton.SetActive (true);
		}

	}

	// IN GAME_STATE 3, tutorial prints final page of text 
	// GAME_STATE changed to 4 by user clicking NEXT 

	public void runState3() {


		prevButton.SetActive (false);
		loginText.SetActive (false);
		nextButton.SetActive (false);
		menuPage1Text.SetActive (false);
		menuPage2Text.SetActive (false);
		playButton.SetActive (false);

		// Activate Page 3
		menuPage3Text.SetActive (true);

		if (TutorialTyperTF.textFinishLoading == 1) {
			Debug.Log ("TEXT FINISHED LOADING");
			prevButton.SetActive (true);
			playButton.SetActive (true);
		}

	}

}
