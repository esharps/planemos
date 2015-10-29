using UnityEngine;
using System.Collections;

public class MainMenuRotate : MonoBehaviour {

    private bool started = true;//false;

    // For when the player touches the menu
    private float rotSpeed = 10.0f;
    private float lerpSpeed = 1.0f;

    private Vector3 speed;
    private Vector3 avgSpeed;
    private bool dragging = false;

    public GameObject menuRotator;
    public ParticleSystem selector;

    //public Material transparent;
    //public Material live;
    //public Renderer rend;
    //private float duration = 2.0f;

    //// When player's not touching the title
    //private float idleRotSpeed = 6.0f;
    //private float idleTime = 0.0f;

    //void Start()
    //{
    //    rend = GetComponent<Renderer>();
    //    rend.material = transparent;
    //}

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
                    // Lock onto Play
                    if (menuRotator.transform.rotation.y < 45.0f && menuRotator.transform.rotation.y > 0.0f)
                        menuRotator.transform.Rotate(0.0f, -0.2f, 0.0f);
                }
            }

            

            //if (Time.time - idleTime > 5 || idleTime == 0.0f)
            //    transform.Rotate(0.0f, -(idleRotSpeed * Time.deltaTime), 0.0f);
            //else
                transform.Rotate(0.0f, -(speed.x * rotSpeed), 0.0f);
        }

    }
}
