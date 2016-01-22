using System;
using System.Collections;
using UnityEngine;

public class DragPlayer : MonoBehaviour
{
	public MapContstraints  mapConstraints;
	float                   xRange;
	float                   yRange;

	void Start(){
		xRange = mapConstraints.xRange;
		yRange = mapConstraints.yRange;
	}

    private void Update()
    {
        // Make sure the user pressed the mouse down
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        Camera mainCamera = FindCamera();

        // We need to actually hit an object
        RaycastHit hit = new RaycastHit();
        if (
            !Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin,
                             mainCamera.ScreenPointToRay(Input.mousePosition).direction, out hit, 100,
                             Physics.DefaultRaycastLayers))
        {
            return;
        }
        // We need to hit a rigidbody that is not kinematic
        if (!hit.rigidbody || hit.rigidbody.isKinematic || hit.transform.gameObject.tag != "Player")
        {
            return;
        }

        StartCoroutine("DragPlayerObj", hit);
    }


    private IEnumerator DragPlayerObj(RaycastHit hit)
    {
        Camera mainCamera = FindCamera();
        while (Input.GetMouseButton(0))
        {
            Ray     ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			float   x   = Mathf.Clamp ( ray.GetPoint(hit.distance).x, -xRange, xRange );
			float   y   = Mathf.Clamp ( ray.GetPoint(hit.distance).y, -yRange, yRange );

			hit.rigidbody.MovePosition(new Vector3(x, y, transform.position.z));
            yield return null;
        }
    }


    private Camera FindCamera()
    {
        if (GetComponent<Camera>())
        {
            return GetComponent<Camera>();
        }
        return Camera.main;
    }
}
