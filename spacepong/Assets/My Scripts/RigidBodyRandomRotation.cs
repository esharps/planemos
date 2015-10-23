using UnityEngine;
using System.Collections;

public class RigidBodyRandomRotation : MonoBehaviour {
	private Rigidbody thisRigidBody;
	public Vector3 eulerAngleVelocity;
	// Use this for initialization
	void Start () {
		thisRigidBody = GetComponent<Rigidbody> ();
		eulerAngleVelocity = new Vector3(
			Random.Range (-10, 10), 
			Random.Range (-10, 10), 
			Random.Range (-10, 10)
			);
	}

	void FixedUpdate () {
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		thisRigidBody.MoveRotation(thisRigidBody.rotation * deltaRotation);
	}
}
