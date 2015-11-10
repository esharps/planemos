using UnityEngine;
using System.Collections;

public class CamRotator : MonoBehaviour
{

    private bool clicked = false;
    //private bool dragging = false;
    private float[] mousePos = new float[2];

    private bool toOptions = false;

    public Camera cam;

    void OnMouseDown()
    {
        if (!clicked)
        {
            mousePos[0] = Input.mousePosition.x;
            mousePos[1] = Input.mousePosition.y;
            clicked = true;
        }
        //else if (clicked && Input.mousePosition.x != mousePos[0] &&
        //    Input.mousePosition.y != mousePos[1])
        //{
        //    dragging = true;
        //}
    }

    void OnMouseUp()
    {
        if (Input.mousePosition.x == mousePos[0] &&
            Input.mousePosition.y == mousePos[1])
        {            
            toOptions = true;
        }

        clicked = false;
    }

    void OnClick()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (toOptions)
            cam.transform.Rotate(0.0f, 2.0f, -1.0f);

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(toOptions);
                if (!toOptions)
                    toOptions = true;
                else if (toOptions)
                    toOptions = false;
            }
        }
    }
}
