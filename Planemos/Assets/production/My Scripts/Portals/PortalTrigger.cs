using UnityEngine;
using System.Collections;

public class PortalTrigger : MonoBehaviour {

	public PortalType type;
	PortalController portalController;
	
	void Start(){
		portalController = GetComponentInParent<PortalController> ();
	}
	
	void OnTriggerEnter(Collider c){
		if(c.gameObject.CompareTag("Ball")){
			portalController.OnPortalTrigger (type, c, transform.gameObject);
		}
	}
	
	public Vector3 GetTranportPoint(){
		return transform.TransformPoint (Vector3.forward * 3);
	}

}
