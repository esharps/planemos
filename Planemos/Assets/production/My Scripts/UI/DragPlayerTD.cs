using UnityEngine;
using System.Collections;

public class DragPlayerTD : MonoBehaviour {
	
	public MapContstraints mapConstraints;
	public Rigidbody playerRb;
	public LayerMask layerMask;

	private float xRange;

	private void Start(){
		xRange = mapConstraints.xRange;
	}

	private void Update()
	{
		// Make sure the user pressed the mouse down
		if (!Input.GetMouseButtonDown(0))
		{
			return;
		}
		
		var mainCamera = FindCamera();
		// We need to actually hit an object
//		var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
//		playerRb.MovePosition(new Vector3(ray.GetPoint(hit.distance).x, transform.position.y, transform.position.z));
//		

		RaycastHit hit = new RaycastHit( );

		if (
			!Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin,
		                 mainCamera.ScreenPointToRay(Input.mousePosition).direction, out hit, 100,
		                 layerMask))
		{
			return;
		}
		// We need to hit a rigidbody that is not kinematic
		if (!hit.rigidbody || hit.rigidbody.isKinematic || !hit.transform.gameObject.CompareTag("Player"))
		{
			return;
		}
		
		StartCoroutine("DragPlayerObj", hit);

		Debug.Log (transform.position.x);

	}
	
	
	private IEnumerator DragPlayerObj(RaycastHit hit)
	{
		Camera mainCamera = FindCamera();
		while (Input.GetMouseButton(0))
		{
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			float x = Mathf.Clamp(ray.GetPoint(hit.distance).x, -xRange, xRange);
			hit.rigidbody.MovePosition(new Vector3( x, transform.position.y, transform.position.z ));
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
