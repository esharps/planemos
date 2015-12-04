using UnityEngine;
using System.Collections;

public class MainMenuRotate : MonoBehaviour {

    private bool started = true;//false;

    // For when the player touches the menu
    private float rotSpeed = 5.0f;
    private float lerpSpeed = 1.0f;

    private Vector3 speed;
    private Vector3 avgSpeed;

    //private bool clicked = false;
    private bool dragging = false;
    //private float[] mousePos = new float[2];

    public GameObject menuRotator;
    //public Camera mainCam;

    private bool rotateToRight = false;
    private bool rotateToLeft = false;

    void OnMouseDown()
    {
        dragging = true;       
    }

    void Update () {

        //float lerp = Mathf.PingPong(Time.time, duration) / duration;
        //rend.material.Lerp(transparent, live, lerp);

        if (started)
        {
            // Set the speed of rotation relative to the speed of mouse movement
            if (Input.GetMouseButton(0) && dragging)
            {
                speed = new Vector3(Input.GetAxis("Mouse X"), 0.0f, 0.0f);
                avgSpeed = Vector3.Lerp(avgSpeed, speed, Time.deltaTime * 5);
            }
            // Otherwise, slowly slow down rotation
            else
            {
                if (dragging)
                {
                    speed = avgSpeed;
                    //idleTime = Time.time;
                    dragging = false;
                }
                float i = Time.deltaTime * lerpSpeed;
                speed = Vector3.Lerp(speed, Vector3.zero, i);

                // Lock rotation in place if it's near one of the options when it gets to a certain speed
                if (speed.magnitude < 0.2)
                {
                    float angle = menuRotator.transform.eulerAngles.y;

                    // Move to Play
                    // Left of Play
                    if (angle < 360.0f && angle > 315.0f)
                        rotateToRight = true;
                    // Right of Play
                    else if (angle <= 45.0f && angle > 0.0f)
                        rotateToLeft = true;

                    // Move to Options
                    // Left of Options
                    else if (angle < 90.0f && angle > 45.0f)
                        rotateToRight = true;
                    // Right of Options
                    else if (angle <= 135.0f && angle > 90.0f)
                        rotateToLeft = true;

                    // Move to Quit
                    // Left of Quit
                    else if (angle < 180.0f && angle > 135.0f)
                        rotateToRight = true;
                    // Right of Quit
                    else if (angle <= 225.0f && angle > 180.0f)
                        rotateToLeft = true;

                    // Move to Credits
                    // Left of Credits
                    else if (angle < 270.0f && angle > 225.0f)
                        rotateToRight = true;
                    // Right of Credits
                    else if (angle <= 315.0 && angle > 270.0f)
                        rotateToLeft = true;

                    if (rotateToLeft)
                    {
                        menuRotator.transform.Rotate(0.0f, -0.2f, 0.0f);
                        rotateToLeft = false;
                    }
                    else if (rotateToRight)
                    {
                        menuRotator.transform.Rotate(0.0f, 0.2f, 0.0f);
                        rotateToRight = false;
                    }

                    // Lock when it gets close
                    // Play
                    if (angle > 359.7f || angle < 0.3f)
                        menuRotator.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                    // Options
                    else if (angle > 89.7f && angle < 90.3f)
                        menuRotator.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                    // Quit
                    else if (angle > 179.7f && angle < 180.3f)
                        menuRotator.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                    // Credits
                    else if (angle > 269.7f && angle < 270.3f)
                        menuRotator.transform.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
                }
            }

            transform.Rotate(0.0f, -(speed.x * rotSpeed), 0.0f);
        }

    }
}
