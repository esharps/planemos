using UnityEngine;
using System.Collections;

public class PortalBehavior : MonoBehaviour {

	private GameObject orange;
	private GameObject purple;
	public bool transporting;

	void Start(){
		orange = transform.FindChild ("Orange").gameObject;
		purple = transform.FindChild ("Purple").gameObject;
	}
	public void OnOrangeCollision(Collider c){
		purple.GetComponent<BoxCollider>().enabled = false;
		moveToPurple (c.gameObject);
	}

	public void OnPurpleCollision(Collider c){
		orange.GetComponent<BoxCollider> ().enabled = false;
		moveToOrange (c.gameObject);
	}

	void moveToPurple(GameObject go){
		if(go.CompareTag("Ball")){
			go.transform.position = purple.transform.position;
			purple.GetComponent<BoxCollider>().enabled = true;
		}
	}

	void moveToOrange(GameObject go){
		if(go.CompareTag("Ball")){
			go.transform.position = orange.transform.position;
			orange.GetComponent<BoxCollider>().enabled = true;
		}
	}
}
