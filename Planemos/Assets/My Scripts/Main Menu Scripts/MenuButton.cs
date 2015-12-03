﻿using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

    public float fadeSpeed = 0.05f;
    public float rotMin = 0.0f;
    public float rotMax = 0.0f;

    public GameObject menuRotator;

    private CanvasGroup c;
    
	void Start () {
        c = this.GetComponent<CanvasGroup>();
        c.alpha = 0.0f;
	}

    public void PlaySelected() {
        if (c.alpha >= 0.8)
            Application.LoadLevel("Testing Menu");
    }

    public void OptionsSelected() {
        if (c.alpha >= 0.8)
            ;
    }

    public void CreditsSelected() {
        if (c.alpha >= 0.8)
            ;
    }

    public void QuitSelected() {
        if (c.alpha >= 0.8)
            Application.Quit();
    }

    void Update () {
        if (GameObject.Find("Menu Options Rotator(Clone)") != null)
            //Debug.Log("Found object");
            menuRotator = GameObject.Find("Menu Options Rotator(Clone)");

        //Debug.Log(menuRotator.transform.eulerAngles.y > rotMin);
        if (MainMenuStartup.icons)
        {
            if (menuRotator.transform.eulerAngles.y > rotMin &&
            menuRotator.transform.eulerAngles.y < rotMax)
            {
                c.alpha += fadeSpeed;
            }
            else
            {

                c.alpha -= fadeSpeed;
            }

            if (c.alpha < 0.8)
                c.blocksRaycasts = false;
            else
                c.blocksRaycasts = true;
        }       
            
	}
}