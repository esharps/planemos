using UnityEngine;
using System.Collections;

public class PortalBehavior : MonoBehaviour {

	private GameObject orange;
	private GameObject purple;
	//public bool transporting;
	public bool portalsActive = true;
	public float timer = 0f;

	void Start(){
		orange = transform.FindChild ("Orange").gameObject;
		purple = transform.FindChild ("Purple").gameObject;
	}


	public void OnOrangeCollision(Collider c){
		orange.GetComponent<BoxCollider> ().enabled = false;		
		purple.GetComponent<BoxCollider>().enabled = false;
		portalsActive = false;
		timer = 0;
		moveToPurple (c.gameObject);
	}

	public void OnPurpleCollision(Collider c){
		orange.GetComponent<BoxCollider> ().enabled = false;
		purple.GetComponent<BoxCollider>().enabled = false;
		timer = 0;
		portalsActive = false;
		moveToOrange (c.gameObject);
	}

	void moveToPurple(GameObject go){
		if(go.CompareTag("Ball")){
			go.transform.position = purple.transform.position;
		}
	}

	void moveToOrange(GameObject go){
		if(go.CompareTag("Ball")){
			go.transform.position = orange.transform.position;
		}
	}

	public void Update(){
		timer += Time.deltaTime;
		if (timer > 1) {
			timer = 0;
			if(!portalsActive)
				portalsActive = true;
		}
		orange.GetComponent<BoxCollider>().enabled = portalsActive;
		purple.GetComponent<BoxCollider>().enabled = portalsActive;
	}
}
