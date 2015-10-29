using UnityEngine;using System.Collections;public class ChangeShader : MonoBehaviour {    static public bool started = false;    private float runTime = 0.0f;    private float lerpSpeed = 0.2f;    private float duration = 1.0f;    //private Material hologram;    //private Material startingUp;    private Shader hologram;    private Shader startingUp;    public Renderer rend;    	void Start () {        rend = GetComponent <Renderer> ();
        hologram = Shader.Find("Effects/GlowAdditiveSimple");
        //Shader h = Shader.Find("Effects/GlowAdditiveSimple");        //hologram.shader = h;

        startingUp = Shader.Find("HOG/FxEnergyShield");
        //Shader s = Shader.Find("HOG/FxEnergyShield");        //startingUp.shader = s;        //rend.material = startingUp;        runTime = Time.time;	}		void Update () {        if (!started)        {
            if (Time.time - runTime < 1)
                rend.material.shader = startingUp;
            else
                rend.material.shader = hologram;

            //lerpSpeed = Mathf.PingPong(Time.time, duration) / duration;
            //rend.material.Lerp(startingUp, hologram, lerpSpeed);

            if (Time.time - runTime > 2)                started = true;        }        else        {            // Reserved for flickering effect if wanted            // But it's more of an enhancement        }	}}