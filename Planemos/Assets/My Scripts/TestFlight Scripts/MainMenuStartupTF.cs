using UnityEngine;
using System.Collections;

public class MainMenuStartupTF : MonoBehaviour {

	public static int menuFinished = 0;

    private float runTime = 0.0f;

    private bool lit = false;
    public static bool rays = false;
    //private bool dust = false;    
    private bool title = false;
    private bool icons = false;

    public Transform hologram_light;
    public Transform light_rays;
    //public Transform light_dust;
    public Transform planemos;
    public Transform menu_icons;

	void Start ()
    {
        runTime = Time.time;
	}
	
	void Update ()
    {
        float diff = Time.time - runTime;
        if (!lit && diff > 1)
        {
            Instantiate(hologram_light);
            lit = true;
        }
        else if (!rays && diff > 1.5)
        {
            Instantiate(light_rays);
            rays = true;
        }
        //else if (!dust && diff > 2.5)
        //{
        //    Instantiate(light_dust);
        //    dust = true;
        //}
        else if (!title && diff > 2.5)
        {
            Instantiate(planemos);
            title = true;
        }
        else if (!icons && diff > 5.5)
        {
            Instantiate(menu_icons);
            icons = true;

			menuFinished = 1;

			//Ready to run terminal login sequence
			TutorialManagerTF.GAME_STATE = 0;
			Debug.Log ("Hologram finished loading.");
        }
	    
	}
}
