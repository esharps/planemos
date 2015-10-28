﻿using System;using UnityEngine;using System.Collections;public class TitleRotate : MonoBehaviour {    // For when the player touches the title    private float rotSpeed = 10.0f;    private float lerpSpeed = 1.0f;    private Vector3 speed;    private Vector3 avgSpeed;    private bool dragging = false;    private Vector3 targetSpeedX;    // When player's not touching the title    private float idleRotSpeed = 6.0f;    private float idleTime = 0.0f;    void OnMouseDown()    {        dragging = true;    }		void Update ()    {        if (ChangeShader.started)
        {
            if (Input.GetMouseButton(0) && dragging)
            {
                speed = new Vector3(Input.GetAxis("Mouse X"), 0.0f, 0.0f);
                avgSpeed = Vector3.Lerp(avgSpeed, speed, Time.deltaTime * 5); // What's the 5 for?
            }
            else
            {
                if (dragging)
                {
                    speed = avgSpeed;
                    idleTime = Time.time;
                    dragging = false;
                }
                float i = Time.deltaTime * lerpSpeed;
                speed = Vector3.Lerp(speed, Vector3.zero, i);
            }

            if (Time.time - idleTime > 5 || idleTime == 0.0f)
                transform.Rotate(0.0f, idleRotSpeed * Time.deltaTime, 0.0f);
            else
                transform.Rotate(0.0f, speed.x * rotSpeed, 0.0f);        }    }}