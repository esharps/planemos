using UnityEngine;
using System.Collections;

public class CamRotator : MonoBehaviour
{

    private bool clicked = false;
    //private bool dragging = false;
    private float[] mousePos = new float[2];
	private float detectTime = 0.0f;
    private bool toOptions = false;

    public Camera cam;

    void Update()
    {
		Debug.Log (detectTime);
        if (toOptions)
            cam.transform.Rotate(0.0f, 2.0f, 0.0f, Space.World);

		if (Input.GetMouseButtonDown (0)) {
			if (!clicked) {
				clicked = true;
				detectTime = Time.time;
			}
		} else if (Input.GetMouseButtonUp (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit) &&
			    Time.time - detectTime < 3) {

				if (!toOptions)
					toOptions = true;
				else if (toOptions)
					toOptions = false;
			}

			clicked = false;
		}
    }
}
