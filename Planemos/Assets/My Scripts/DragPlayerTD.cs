﻿using UnityEngine;
using System.Collections;

public class DragPlayerTD : MonoBehaviour {





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
		
		StartCoroutine("DragPlayerObj", hit);
	}
	
	
	private IEnumerator DragPlayerObj(RaycastHit hit)
	{
		var mainCamera = FindCamera();
		while (Input.GetMouseButton(0))
		{
			var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			hit.rigidbody.MovePosition(new Vector3(ray.GetPoint(hit.distance).x, transform.position.y, transform.position.z));
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
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
