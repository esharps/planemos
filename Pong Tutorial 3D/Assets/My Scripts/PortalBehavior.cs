using UnityEngine;
using System.Collections;

public class PortalBehavior : MonoBehaviour {

	private GameObject orange;
	private GameObject purple;
	//public bool transporting;
	private bool portalsActive = true;
	private long timer = 0;

	void Start(){
		orange = transform.FindChild ("Orange").gameObject;
		purple = transform.FindChild ("Purple").gameObject;
	}


	public void OnOrangeCollision(Collider c){
		orange.GetComponent<BoxCollider> ().enabled = false;
		moveToPurple (c.gameObject);
	}

	public void OnPurpleCollision(Collider c){
		orange.GetComponent<BoxCollider> ().enabled = false;
		purple.GetComponent<BoxCollider>().enabled = false;
		moveToOrange (c.gameObject);
	}

//	public void onTriggerEnter(Collider c){
//		moveToPurple(c)
//		portalsActive = false;
//	}

	void moveToPurple(GameObject go){
		if(go.CompareTag("Ball")){
			go.transform.position = purple.transform.position;
//			purple.GetComponent<BoxCollider>().enabled = true;
		}
	}

	void moveToOrange(GameObject go){
		if(go.CompareTag("Ball")){
			go.transform.position = orange.transform.position;
//			orange.GetComponent<BoxCollider>().enabled = true;
		}
	}

	public void update(){
		timer += Time.deltaTime;
		if (timer > 1) {
			timer = 0;
			if(!portalsActive){
				activatePortals();
			}
		}
	}

	public void activatePortals(){
		for(Transform child in transform){
			child.GetComponent<BoxCollider>().enabled = true;
		}
	}
}
