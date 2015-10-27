using UnityEngine;
using System.Collections;

public class OrangePortal : MonoBehaviour {
	
	private PortalBehavior parentPortalBehavior;

	void Start(){
		parentPortalBehavior = GetComponentInParent<PortalBehavior> ();
	}

	void OnTriggerEnter(Collider c){
		parentPortalBehavior.OnOrangeCollision (c);
	}

	public Vector3 GetTranportPoint(){
		return transform.TransformPoint (Vector3.forward * 3);
	}
}
