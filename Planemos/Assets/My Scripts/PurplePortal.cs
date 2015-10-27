using UnityEngine;
using System.Collections;

public class PurplePortal : MonoBehaviour {
	
	private PortalBehavior parentPortalBehavior;

	void Start(){
		parentPortalBehavior = GetComponentInParent<PortalBehavior> ();
	}

	void OnTriggerEnter(Collider c){
		parentPortalBehavior.OnPurpleCollision (c);
	}

	public Vector3 GetTranportPoint(){
		return transform.TransformPoint (Vector3.forward * 3);
	}
}
