using UnityEngine;
using System.Collections;

public class OrangPortal : MonoBehaviour {
	
	private PortalBehavior parentPortalBehavior;

	void Start(){
		parentPortalBehavior = GetComponentInParent<PortalBehavior> ();
	}

	void OnTriggerEnter(Collider c){
		parentPortalBehavior.OnOrangeCollision (c);
	}

//	void OnTriggerExit(){
//		parentPortalBehavior.transporting = false;
//	}
}
