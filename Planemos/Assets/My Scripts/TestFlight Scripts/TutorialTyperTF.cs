using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Subroutine that simulates text being loaded into memory
 * and displayed to a computer screen
 * @author emsharp
 */
public class TutorialTyperTF : MonoBehaviour {
	
	public float letterPause = 0.05f;
	public AudioClip startSound;

	// Read in characters of tutorial text first
	Text tutorialGameText;
	string textString;

	// Use this for initialization
	void Start () {
		tutorialGameText = GetComponent<Text> ();
		textString = tutorialGameText.text;
		Debug.Log ("HIT");
		tutorialGameText.text = "";
		StartCoroutine (TypeTutorialText ());

	}

	void Update() {

		//if (TutorialManagerTF.GAME_STATE == 1) {
		//	StartCoroutine(TypeTutorialText ());
		//}

		if (TutorialManagerTF.GAME_STATE == 2) {


		}

	}


	// Subroutine that simulates using computer terminal to "run" tutorial
	IEnumerator TypeTutorialText () {

		/*TODO Play startSound once indicating new page */

		foreach (char letter in textString.ToCharArray()) {
			tutorialGameText.text += letter;

			/*if(typeSound) {
				AudioClip.
			}*/
			yield return new WaitForSeconds(letterPause);
		}

	
		yield return new WaitForSeconds(1.0f);
		TutorialManagerTF.GAME_STATE = 1;
	}
	
}
