using UnityEngine;
using System.Collections;

public class MainMenuRotate : MonoBehaviour {

    // For when the player touches the menu
    private float rotSpeed = 0.2f;
    private float lerpSpeed = 1.0f;

    private Vector3 speed;
    private Vector3 avgSpeed;

    public GameObject menuRotator;

    private bool rotateToRight = false;
    private bool rotateToLeft = false;

    void Update () {
        // Set the speed of rotation relative to the speed of touch movement
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                speed = new Vector3(Input.GetTouch(0).deltaPosition.x, 0.0f, 0.0f);
                avgSpeed = Vector3.Lerp(avgSpeed, speed, Time.deltaTime * 5);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                speed = avgSpeed;
            }
        }
        else
        {
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

        transform.Rotate(0.0f, -(speed.x *rotSpeed), 0.0f);

    }
}
