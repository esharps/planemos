using UnityEngine;
using System.Collections;


// Manages all behavior that can occur as the result
// of clicking a UI-based button object via OnClick()
public class ButtonManagerTF : MonoBehaviour {

	// OnClick() NEXT button in tutorial
	public void PressNext() {
		TutorialManagerTF.GAME_STATE += 1;
		Debug.Log ("GAME_STATE:" + TutorialManagerTF.GAME_STATE);
	}

	// OnClick() PREV button in tutorial
	public void PressPrev() {
		TutorialManagerTF.GAME_STATE -= 1;
	}
	
	// OnClick() Quit
	public void QuitGame() {

		//NOTE: QUIT only works after project is built and run
		Application.Quit ();
	}

	public void Load2dSceneTF() {

		// In tutorial, top-down section at index 1 in build
		Application.LoadLevel (1);
	}
}
