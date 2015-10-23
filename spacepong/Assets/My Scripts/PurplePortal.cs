using UnityEngine;
using System.Collections;

public class PurplePortal : MonoBehaviour {
	
	private PortalBehavior parentPortalBehavior;

	void Start(){
		parentPortalBehavior = GetComponentInParent<PortalBehavior> ();
	}

	void OnTriggerEnter(Collider c){
//		if (!parentPortalBehavior.transporting) {
//			parentPortalBehavior.transporting = true;
		parentPortalBehavior.OnPurpleCollision (c);
//		}
	}

//	void OnTriggerExit(){
//		parentPortalBehavior.transporting = false;
//	}

}
