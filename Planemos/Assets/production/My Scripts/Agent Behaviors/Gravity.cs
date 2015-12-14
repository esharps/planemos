using UnityEngine;
using System.Collections.Generic;

public class Gravity : MonoBehaviour
{
	public GameObject ball;
	public float range;
	public float multiplier;

	void FixedUpdate ()
	{
		Vector3 offset = transform.position - ball.transform.position;
		if( offset.magnitude <= range )
		{
			Rigidbody rb = ball.GetComponent<Rigidbody>();
			rb.AddForce( offset / offset.sqrMagnitude * GetComponent<Rigidbody>().mass * multiplier);
		}
	}
}