using UnityEngine;
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
        if (c.alpha >= 0.8) {

			//iPhone 5
			if (Screen.currentResolution.ToString ().Contains ("1136"))
				Application.LoadLevel ("Gameplay Menu iPhone Master");
			//iPhone 6
			else if (Screen.currentResolution.ToString ().Contains ("1334"))
				Application.LoadLevel ("Gameplay Menu iPhone Master");
		
			//iPhone 6S
			else if (Screen.currentResolution.ToString ().Contains ("2208"))
				Application.LoadLevel ("Gameplay Menu iPhone Master");
		
			//iPad Mini
			else if (Screen.currentResolution.ToString ().Contains ("1024"))
				Application.LoadLevel ("Gameplay Menu iPad Master");
		
			//iPad Air
			else if (Screen.currentResolution.ToString ().Contains ("2048"))
				Application.LoadLevel ("Gameplay Menu iPad Master");
			else
				Application.LoadLevel ("Gameplay Menu iPad Master");
           
			// Application.LoadLevel("GameplayMenu");
		}
    }

    public void OptionsSelected() {
		// Jon, to get rid of compiler warnings
//        if (c.alpha >= 0.8)
//            ;
    }

    public void CreditsSelected() {
	// Jon, to get rid of compiler warnings
//        if (c.alpha >= 0.8)
//            ;
    }

    public void QuitSelected() {
        if (c.alpha >= 0.8)
            Application.Quit();
    }

    void Update () {
        if (GameObject.Find("Menu Options Rotator(Clone)") != null)
            menuRotator = GameObject.Find("Menu Options Rotator(Clone)");

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
