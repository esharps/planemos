using UnityEngine;
using System.Collections;

public class MainMenuStartup : MonoBehaviour {

    private float runTime = 0.0f;

    private bool lit = false;
    public static bool rays = false;
    private bool title = false;
    public static bool icons = false;

    public Transform hologram_light;
	public Transform light_rays;
	public Transform planemos;
	public Transform menu_icons;

	void Start ()
    {
		Time.timeScale = 1;
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
        else if (!title && diff > 2.5)
        {
            Instantiate(planemos);
            title = true;
        }
        else if (!icons && diff > 5.5)
        {
            Instantiate(menu_icons);
            icons = true;
        }
	    
	}
}
