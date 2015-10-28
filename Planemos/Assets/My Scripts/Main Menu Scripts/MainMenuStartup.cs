﻿using UnityEngine;
using System.Collections;

public class MainMenuStartup : MonoBehaviour {

    private float runTime = 0.0f;

    private bool lit = false;
    private bool rays = false;
    private bool dust = false;
    private bool title = false;

    public Transform hologram_light;
    public Transform light_rays;
    public Transform light_dust;
    public Transform planemos;

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
        else if (!dust && diff > 2.5)
        {
            Instantiate(light_dust);
            dust = true;
        }
        else if (!title && diff > 3.5)
        {
            Instantiate(planemos);
            title = true;
        }
	    
	}
}
