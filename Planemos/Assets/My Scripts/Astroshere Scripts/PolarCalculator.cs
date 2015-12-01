using UnityEngine;
using System.Collections;

public class PolarCalculator : MonoBehaviour {

	const float EPSILON = 0.1f;

	public float	startAngle;
	public float	radius;
	public float	movementRange;
	public float	curAngle;

	float		maxAngle;
	float 		minAngle;

	void Update(){
		Vector2 polarCoord = new Vector2 ( radius, DegreesToRadians ( curAngle ) );
		transform.position = PolarToCartesian ( polarCoord );
		transform.LookAt ( Vector3.zero, Vector3.up );
	}

	public void Initialize(float r, float a, float m){
		this.radius = r;
		this.startAngle = a;
		this.movementRange = m;
		minAngle = a - m;
		maxAngle = a + m;
	}

	public void MoveToStart(){
		curAngle = startAngle;
		Vector2 polarCoord = new Vector2 ( radius, DegreesToRadians ( curAngle ) );
		transform.position = PolarToCartesian ( polarCoord );
		transform.LookAt ( Vector3.zero, Vector3.up );
	}

	public void Move(float amt){
		curAngle = Mathf.Clamp (curAngle + amt, minAngle, maxAngle);
	}
	
	Vector3 PolarToCartesian( Vector2 polar )
	{
		float x = polar.x * Mathf.Cos (polar.y);
		float z = polar.x * Mathf.Sin (polar.y);
		return new Vector3 (x, 0, z);

	}

	float DegreesToRadians( float deg ){
		return deg * Mathf.Deg2Rad;
	}


}
