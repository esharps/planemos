using UnityEngine;
using System.Collections;

// Manages all behavior that can occur as the result
// of clicking a UI-based button object via OnClick()
public class ButtonManagerTF : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// OnClick() NEXT button in tutorial
	public void PressNext() {
		TutorialManagerTF.GAME_STATE += 1;
	}

	// OnClick() PREV button in tutorial
	public void PressPrev() {
		TutorialManagerTF.GAME_STATE -= 1;
	}
	
	// OnClick() Quit
	public void QuitGame() {
		Application.Quit ();
	}
}
