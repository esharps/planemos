using System;
using System.Collections;
using UnityEngine;

public class DragPlayer : MonoBehaviour
{
//    const float k_Spring = 500.0f;
//    const float k_Damper = 10.0f;
//    const float k_Drag = 100.0f;
//    const float k_AngularDrag = 100.0f;
//    const float k_Distance = 0.2f;
//    const bool k_AttachToCenterOfMass = false;
//
//    private SpringJoint m_SpringJoint;


    private void Update()
    {
        // Make sure the user pressed the mouse down
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        var mainCamera = FindCamera();

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

//        if (!m_SpringJoint)
//        {
//            var go = new GameObject("Rigidbody dragger");
//            Rigidbody body = go.AddComponent<Rigidbody>();
//            m_SpringJoint = go.AddComponent<SpringJoint>();
//            body.isKinematic = false;
//        }
//
//        m_SpringJoint.GetComponent<Rigidbody>().MovePosition(hit.point);
//        m_SpringJoint.anchor = Vector3.zero;
//
//        m_SpringJoint.spring = k_Spring;
//        m_SpringJoint.damper = k_Damper;
//        m_SpringJoint.maxDistance = k_Distance;
//        m_SpringJoint.connectedBody = hit.rigidbody;

        StartCoroutine("DragPlayerObj", hit);
    }


    private IEnumerator DragPlayerObj(RaycastHit hit)
    {
//        var oldDrag = m_SpringJoint.connectedBody.drag;
//        var oldAngularDrag = m_SpringJoint.connectedBody.angularDrag;
//        m_SpringJoint.connectedBody.drag = k_Drag;
//        m_SpringJoint.connectedBody.angularDrag = k_AngularDrag;
        var mainCamera = FindCamera();
        while (Input.GetMouseButton(0))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            hit.rigidbody.MovePosition(ray.GetPoint(hit.distance));
            yield return null;
        }
//        if (m_SpringJoint.connectedBody)
//        {
//            m_SpringJoint.connectedBody.drag = oldDrag;
//            m_SpringJoint.connectedBody.angularDrag = oldAngularDrag;
//            m_SpringJoint.connectedBody = null;
//        }
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
