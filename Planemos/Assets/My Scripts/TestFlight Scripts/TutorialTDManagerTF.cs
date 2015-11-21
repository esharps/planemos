using UnityEngine;
using System.Collections;

public class TutorialTDManagerTF : MonoBehaviour {
		
	public static int GAME_STATE;
	
	//Separate Camera for UI rendering
	public GameObject uiCamera;
	public GameObject lowerConsole;
	public GameObject mainConsole;
	//UI Elements
	public GameObject planemoObj;
	public GameObject gravObjects;
	public GameObject quitButton;

	public GameObject nextButton;
	//public GameObject prevButton;
	public GameObject tdPage1Text;
	public GameObject tdPage2Text;
	public GameObject tdPage3Text;
	public GameObject tdPage4Text;
	public GameObject tdPage5Text;
	public GameObject tdPage6Text;
	public GameObject tdSuccessText;
	public GameObject finalMessage;

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
		case 7:
			runState7 ();
			break;
		case 8:
			runState8 ();
			break;
		case 9:
			runState9 ();
			break;
		case 10:
			runState10 ();
			break;
		}
		
	}

	// In GAME_STATE 4, game runs renders scores via UI
	public void runState4() {

		uiCamera.SetActive (true);
		quitButton.SetActive (true);
		tdPage1Text.SetActive (true);

		// Once text has finished loading, wait for player to move paddle
		if (TutorialTyperTF.textFinishLoading == 1 && PaddleControls.paddleY != 0) {


			//Indication that the player has successfully moved paddle with finger
			tdPage1Text.SetActive(false);
			tdSuccessText.SetActive(true);
			nextButton.SetActive(true);
		}
	}

	// In GAMES_STATE 5, game organizes a typical pong match minus space objects
	public void runState5() {

		if (ScoreManager.playerScore != 1) {

			tdSuccessText.SetActive (false);
			nextButton.SetActive (false);

			//"Let's play a quick game against the AI"
			tdPage2Text.SetActive (true);
		}

		if (TutorialTyperTF.textFinishLoading == 1) {

			gameBall.SetActive(true);
		}

		// Score == 5
		if (ScoreManager.playerScore == 5) {

			//End the game
			gameBall.SetActive (false);
			tdPage2Text.SetActive(false);
			tdSuccessText.SetActive(true);
			nextButton.SetActive(true);
		}
	}

	// In GAME_STATE 6, player is introduced to planemos
	public void runState6() {

		tdSuccessText.SetActive (false);
		tdPage3Text.SetActive(true);
		nextButton.SetActive(false);
		tdPage4Text.SetActive (false);

		if (TutorialTyperTF.textFinishLoading == 1) {
			planemoObj.SetActive(true);
		}

		nextButton.SetActive (true);

	}

	// GAME_STATE 7, player plays a match against AI with Earth planemo active
	public void runState7() {

		tdPage3Text.SetActive (false);
		tdPage4Text.SetActive (true);

		if (TutorialTyperTF.textFinishLoading == 1) {

			gameBall.SetActive(true);

		}

		// Score = 10
		if (ScoreManager.playerScore == 10) {

			gameBall.SetActive(false);
			tdPage4Text.SetActive(false);
			tdSuccessText.SetActive(true);
			nextButton.SetActive(true);
		}
	}

	// GAME_STATE 8, player is introduced to all gravitational objects
	public void runState8 () {

		tdPage4Text.SetActive (false);
		tdSuccessText.SetActive (false);
		tdPage5Text.SetActive (true);
		nextButton.SetActive (false);
		//planemoObj.SetActive (false);

		if (TutorialTyperTF.textFinishLoading == 1) {
			gravObjects.SetActive (true);
		}

		nextButton.SetActive (true);
	}


	public void runState9() {
		nextButton.SetActive (false);
		tdPage5Text.SetActive (false);
		tdPage6Text.SetActive (true);

		if (TutorialTyperTF.textFinishLoading == 1) {
			gameBall.SetActive(true);
		}

		// <= 18
		if (ScoreManager.playerScore >= 18) {

			tdPage6Text.SetActive(false);
			tdSuccessText.SetActive (true);
			nextButton.SetActive (true);
		}

	}

	public void runState10() {
		nextButton.SetActive (false);
		lowerConsole.SetActive (false);
		mainConsole.SetActive (true);
		finalMessage.SetActive (true);

	}



}
