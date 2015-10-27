using UnityEngine;
using System.Collections;

public class PortalBehavior : MonoBehaviour {

	//public bool transporting;
	public float delay;

	private bool portalsActive = true;
	private float timer = 0f;
	private GameObject purple;
	private GameObject orange;

	void Start(){
		orange = transform.FindChild ("Orange").gameObject;
		purple = transform.FindChild ("Purple").gameObject;
	}


	public void OnOrangeCollision(Collider c){
		if (portalsActive) {
			timer = 0;
			portalsActive = false;
			moveToPurple (c.gameObject);
		}
	}

	public void OnPurpleCollision(Collider c){
		if (portalsActive) {
			timer = 0;
			portalsActive = false;
			moveToOrange (c.gameObject);
		}
	}

	void moveToPurple(GameObject go){
		if(go.CompareTag("Ball")){
			Vector3 transport = getRandomPurple();
			go.transform.position = transport;
		}
	}

	void moveToOrange(GameObject go){
		if(go.CompareTag("Ball")){
			Vector3 transport = getRandomOrange();
			go.transform.position = transport;
		}
	}

	public void Update(){
		timer += Time.deltaTime;
		if (timer > delay) {
			timer = 0;
			if(!portalsActive)
				portalsActive = true;
		}
	}

	private Vector3 getRandomPurple(){
		int numPortals = purple.transform.childCount;
		int randPortal = Random.Range (0, numPortals);
		GameObject portal = purple.transform.GetChild (randPortal).gameObject;
		PurplePortal pp = portal.GetComponent<PurplePortal> ();
		return pp.GetTranportPoint ();
	}

	private Vector3 getRandomOrange(){
		int numPortals = orange.transform.childCount;
		int randPortal = Random.Range (0, numPortals);
		GameObject portal = orange.transform.GetChild (randPortal).gameObject;
		OrangePortal op = portal.GetComponent<OrangePortal>();
		return op.GetTranportPoint ();

	}
}
