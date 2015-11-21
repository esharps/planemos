using UnityEngine;
using System.Collections;

public class TutorialTDManagerTF : MonoBehaviour {
		
	public static int GAME_STATE;
	
	//Separate Camera for UI rendering
	public GameObject uiCamera;
	
	//UI Elements
	public GameObject gravObjSingle;
	public GameObject gravObjects;

	public GameObject nextButton;
	//public GameObject prevButton;
	public GameObject tdPage1Text;
	public GameObject tdPage2Text;
	//public GameObject tdPage3Text;
	public GameObject tdSuccessText;

	public GameObject gameBall;
	
	
	// Game state should now have a value of 4 upon
	// loading scene 2 of tutorial
	void Start () {
		GAME_STATE = 4;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("GAME_STATE: " + GAME_STATE);
		switch (GAME_STATE) {
		case 4:
			runState4 ();
			break;
		case 5:
			runState5 ();
			break;
		
		case 6:
			runState6 ();
			break;
		}
		
	}

	// In GAME_STATE 4, game runs renders scores via UI
	public void runState4() {

		uiCamera.SetActive (true);
		tdPage1Text.SetActive (true);

		// Once text has finished loading, wait for player to move paddle
		if (TutorialTyperTF.textFinishLoading == 1 && PaddleControls.paddleY != 0) {


			//Indication that the player has successfully moved paddle with finger
			tdPage1Text.SetActive(false);
			tdSuccessText.SetActive(true);
			nextButton.SetActive(true);
		}
	}

	public void runState5() {

		if (ScoreManager.playerScore != 5) {

			tdSuccessText.SetActive (false);
			nextButton.SetActive (false);
			//"Let's play a quick game against the AI"
			tdPage2Text.SetActive (true);
		}

		if (TutorialTyperTF.textFinishLoading == 1) {

			gameBall.SetActive(true);
		}

		if (ScoreManager.playerScore == 5) {

			//End the game
			gameBall.SetActive(false);
			tdPage2Text.SetActive(false);
			tdSuccessText.SetActive(true);
			nextButton.SetActive(true);
		}
	}

	public void runState6() {



	}
	
	// In GAME_STATE 0, game runs AUTOMATED subroutine that simulates
	// running the tutorial as a program
	// GAME_STATE is changed to 1 by AutoTypeTF class through coroutine
	// (i.e.) state change is NOT driven by user
	/*public void runState0() {
		
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
		
		menuPage1Text.SetActive (true);
		
		loginText.SetActive (false);
		prevButton.SetActive (false);
		playButton.SetActive (false);
		menuPage2Text.SetActive (false);
		
		if (TutorialTyperTF.textFinishLoading == 1) {
			nextButton.SetActive (true);
		}
	}
	
	// IN GAME_STATE 2, tutorial prints second page of text
	// GAME_STATE changed to 3 by user clicking NEXT button
	// GAME_STAE changed to 1 by user clicking PREV button
	public void runState2() {
		
		menuPage2Text.SetActive (true);
		
		prevButton.SetActive (false);
		nextButton.SetActive (false);
		loginText.SetActive (false);
		playButton.SetActive (false);
		menuPage1Text.SetActive (false);
		menuPage3Text.SetActive (false);
		
		if (TutorialTyperTF.textFinishLoading == 1) {
			nextButton.SetActive (true);
			prevButton.SetActive (true);
		}
		
	}

		
	}*/
	
	public IEnumerator DelayLoad() {
		yield return new WaitForSeconds(1.0f);
	}

}
