using UnityEngine;
using System.Collections.Generic;

public class Gravity : MonoBehaviour 
{	
	public float range;
	
	void FixedUpdate () 
	{
		Collider[] cols  = Physics.OverlapSphere(transform.position, range); 
//		List<Rigidbody> rbs = new List<Rigidbody>();
		
		foreach(Collider c in cols)
		{
			GameObject go = c.gameObject;
//			Rigidbody rb = c.attachedRigidbody;

			if(go.CompareTag("Ball"))
			{
				Rigidbody rb = c.attachedRigidbody;
				Vector3 offset = transform.position - go.transform.position;
				rb.AddForce( offset / offset.sqrMagnitude * GetComponent<Rigidbody>().mass);
			}
		}
	}
}