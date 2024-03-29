﻿using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseCanvas;
	public GameObject ScoreCanvas;
	bool paused = false;

	// Use this for initialization
	void Start () {
		PauseCanvas.SetActive (false);
		ScoreCanvas.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (paused) {
			PauseCanvas.SetActive (true);
			ScoreCanvas.SetActive (false);
			Time.timeScale = 0;
		} else {
			PauseCanvas.SetActive(false);
			ScoreCanvas.SetActive(true);
			Time.timeScale = 1;
		}
	}

	public void ReturnToMainiPad(){
		Application.LoadLevel("Main Menu iPad Master");
	}

	public void ReturnToMainiPhone(){
		Application.LoadLevel ("Main Menu iPhone Master");
	}

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void Continue(){
		paused = false;
	}

	public void Pause(){
		paused = true;
	}

	public void Quit(){
		Application.Quit ();
	}
}
