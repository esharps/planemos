using UnityEngine;
using System.Collections;

public class PolarCalculator : MonoBehaviour {
	public float startAngle;
	public float radius;
	public float movementRange;
	public bool hasRigidBody;

	private float curAngle;
	private Rigidbody rb;
	private float maxAngle;
	private float minAngle;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		hasRigidBody = (rb != null);
		curAngle = startAngle;
		minAngle = startAngle - movementRange;
		maxAngle = startAngle + movementRange;
		InitializePosition ();
	}

	public void UpdatePosition(float deltaAngle){
		curAngle = Mathf.Clamp (curAngle + deltaAngle, minAngle, maxAngle);
		Vector2 polarCoord = new Vector2 ( radius, DegreesToRadians ( curAngle ) );
		transform.position = PolarToCartesian (polarCoord);
		transform.LookAt (Vector3.zero, Vector3.up);
	}

	public void InitializePosition(){
		Vector2 polarCoord = new Vector2 ( radius, DegreesToRadians ( startAngle ) );
		transform.position = PolarToCartesian (polarCoord);
		transform.LookAt (Vector3.zero, Vector3.up);
	}

//	public Vector2 CartesianToPolar(Vector3 point)
//	{
//		Vector2 polar;
//		
//		//calc longitude
//		polar.y = Mathf.Atan2(point.x,point.z);
//		
//		//this is easier to write and read than sqrt(pow(x,2), pow(y,2))!
//		float xzLen = new Vector2(point.x,point.z).magnitude; 
//
//		//atan2 does the magic
//		polar.x = Mathf.Atan2(-point.y,xzLen);
//		
//		//convert to deg
//		polar *= Mathf.Rad2Deg;
//		
//		return polar;
//	}
	
	
	private Vector3 PolarToCartesian(Vector2 polar)
	{
		float x = polar.x * Mathf.Cos (polar.y);
		float z = polar.x * Mathf.Sin (polar.y);
		return new Vector3 (x, 0, z);

	}

	private float DegreesToRadians(float deg){
		return deg * (Mathf.PI / 180);
	}
}
