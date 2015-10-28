using UnityEngine;
using System.Collections;

public class ChangeShader : MonoBehaviour {

    static public bool started = false;
    private float runTime = 0.0f;

    private Shader hologram;
    private Shader startingUp;
    public Renderer rend;
    
	void Start () {
        rend = GetComponent <Renderer> ();
        hologram = Shader.Find("Effects/GlowAdditiveSimple");
        startingUp = Shader.Find("HOG/FxEnergyShield");
        runTime = Time.time;
	}
	
	void Update () {
        if (!started)
        {
            if (Time.time - runTime < 1)
                rend.material.shader = startingUp;
            else
                rend.material.shader = hologram;

            if (Time.time - runTime > 2)
                started = true;
        }
        else
        {
            // Reserved for flickering effect if wanted
            // But it's more of an enhancement
        }
	}
}
