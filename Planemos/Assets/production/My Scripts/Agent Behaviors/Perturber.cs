using UnityEngine;
using System.Collections;

public class Perturber : MonoBehaviour {

	public MapContstraints mapConstraints;
	public float rotationalVelocity;
	public float speed;

	private Vector3 eulerAngleVelocity;
	private Vector3 dir;
	private ObjectRangeOfMotion motionField;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		motionField = mapConstraints.objectMotionField;
		eulerAngleVelocity = new Vector3(
			Random.Range (-1, 1), 
			Random.Range (-1, 1), 
			Random.Range (-1, 1)
		);

		eulerAngleVelocity = eulerAngleVelocity.normalized * rotationalVelocity;

		float x = Random.Range (-1.0f, 1.0f);
		float y = Random.Range (-1.0f, 1.0f);
		float z = Random.Range (-1.0f, 1.0f);

		switch (motionField) {
		case ObjectRangeOfMotion.PLANAR:
			dir = new Vector3(x, 0, z);
			break;
		case ObjectRangeOfMotion.FULL_3D:
			dir = new Vector3(x, y, z);
			break;
		}

//		speed = Random.Range ( -5, 5 );

		rb.velocity = (dir.normalized * speed);
		rb.AddTorque(eulerAngleVelocity * rb.mass, ForceMode.Impulse);
	
	}
}
