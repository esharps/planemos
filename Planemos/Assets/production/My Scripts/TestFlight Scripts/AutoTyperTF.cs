using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Subroutine that simulates real-time typing on a keyboard
 * This AutoTyper is specifically designed for simulating user
 * login and then running the TestFlight tutorial program
 * @author emsharp
 */
public class AutoTyperTF : MonoBehaviour {


	public float coroutTimeDelay = 6.0f;
	public float letterPause = 0.2f;
	public float cursorPause = 0.4f;
	public AudioClip typeSound;

	// Read in characters of tutorial text first
	Text inGameText;
	public string commandStr = "./test_tutorial cat";
	public string userIDStr = "iOS-Device: ~ testFlyer$ ";


	// Use this for initialization
	void Start () {
		inGameText = GetComponent<Text> ();
		StartCoroutine (TypeRunText ());
		//inGameText.text = "";
	}

	// Subroutine that simulates using computer terminal to "run" tutorial
	IEnumerator TypeRunText () {

		// Wait for hologram to finish rendering before typing starts 
		yield return new WaitForSeconds (coroutTimeDelay);

		// Want to simuluate cursor blinking before typing
		for (int i = 0; i < 5; i++) {

			if(i%2 == 0) 
				inGameText.text = userIDStr;
			else
				inGameText.text = userIDStr + "|";
			yield return new WaitForSeconds(cursorPause);
		}

		foreach (char letter in commandStr.ToCharArray()) {
			inGameText.text += letter;

			/*if(typeSound) {
				AudioClip.
			}*/
			yield return new WaitForSeconds(letterPause);
		}

		// Cursor blinking while tutorial file "loads"
		string endStr = inGameText.text;

		for (int i = 0; i < 6; i++) {
			
			if(i%2 == 0) 
				inGameText.text = endStr + "|";
			else
				inGameText.text = endStr;
			yield return new WaitForSeconds(cursorPause);
		}

		inGameText.text = "";

		yield return new WaitForSeconds(1.0f);
		TutorialManagerTF.GAME_STATE = 1;
	}
	
}
