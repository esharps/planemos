using UnityEngine;
using System.Collections.Generic;

public class Gravity : MonoBehaviour 
{	
	public float range;
	public float force;
	
	void FixedUpdate () 
	{
		Collider[] cols  = Physics.OverlapSphere(transform.position, range); 
		
		foreach(Collider c in cols)
		{
			GameObject go = c.gameObject;

			if(go.CompareTag("Ball"))
			{
				Rigidbody rb = c.attachedRigidbody;
				Vector3 offset = transform.position - go.transform.position;
				rb.AddForce( offset / offset.sqrMagnitude * force);
			}
		}
	}
}