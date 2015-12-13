using UnityEngine;
using System.Collections;

public class CamRotator : MonoBehaviour
{

    private bool clicked = false;
    //private bool dragging = false;
//    private float[] mousePos = new float[2]; //Jon, to git rid of compiler warnings
	private float detectTime = 0.0f;
    private bool toOptions = false;

    public Camera cam;

    void Update()
    {
		//Debug.Log (detectTime);
        if (toOptions && cam.transform.eulerAngles.y < 90)
            cam.transform.Rotate(0.0f, 1.0f, 0.0f, Space.World);

		if (Input.GetMouseButtonDown (0)) {
			if (!clicked) {
				detectTime = Time.time;
				clicked = true;
			}
		} else if (Input.GetMouseButtonUp (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			Debug.Log (Time.time - detectTime);
			if (Physics.Raycast (ray, out hit) &&
			    Time.time - detectTime < 1.5) {

				if (!toOptions)
					toOptions = true;
				else if (toOptions)
					toOptions = false;
			}

			clicked = false;
		}
    }
}
