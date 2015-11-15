using UnityEngine;
using System.Collections;

public class PortalController: MonoBehaviour {

	const bool ACTIVE = true;
	const bool INACTIVE = false;
	const float ACTIVATION_DELAY = 0.5f;

	public float spawnDelay;
	public GameObject purples;
	public GameObject oranges;

	bool portalsActive = true;
	float activationTimer;
	float spawnTimer;

	void Start(){
		activationTimer = 0.0f;
		spawnTimer = 0.0f;
	}

	void Update(){
		spawnTimer += Time.deltaTime;
		activationTimer += Time.deltaTime;

		if ( activationTimer > ACTIVATION_DELAY ) {
			activationTimer = 0;
			if(!portalsActive)
				portalsActive = true;
		}

		if( spawnTimer > spawnDelay ){
			spawnTimer = 0;
			spawnPair();
		}
	}
	
	void spawnPair()
	{
		GameObject inactiveOrange = getRandomPortal (PortalType.ORANGE, INACTIVE);
		GameObject inactivePurple = getRandomPortal (PortalType.PURPLE, INACTIVE);

		if (inactiveOrange == null || inactivePurple == null)
			return;

		inactiveOrange.SetActive (ACTIVE);
		inactivePurple.SetActive (ACTIVE);
	}

	void randomVelocityChange(Rigidbody rb){
		if(rb == null)
			return;

		float rand = Random.Range(0.0f, 1.0f);
		if(rand > .5){
			Vector3 currentBallVelocity = rb.velocity;
			rb.velocity = new Vector3 (currentBallVelocity.x, currentBallVelocity.y, -currentBallVelocity.z);
		}
	}

	public void OnPortalTrigger(PortalType type, Component c, GameObject origin )
	{
		if (type == null || c == null) {
			return;
		}

		if (portalsActive && c.gameObject.CompareTag ("Ball")) {
			GameObject ball = c.gameObject;
			GameObject otherPortal = null;
			activationTimer = 0;
			portalsActive = false;
			switch (type) {

			case PortalType.PURPLE:
				otherPortal = getRandomPortal (PortalType.ORANGE, ACTIVE);
				break;

			case PortalType.ORANGE:
				otherPortal = getRandomPortal (PortalType.PURPLE, ACTIVE);
				break;
			}

			if(otherPortal == null)
				return;

			Vector3 destination = otherPortal.GetComponent<PortalTrigger> ().GetTranportPoint ();
			transport (ball, destination);
			otherPortal.SetActive(false);
			origin.SetActive(false);
			ball.GetComponent<UniversalBallController>().ResetVelocity();
		}
	}

	GameObject getRandomPortal(PortalType type, bool activeStatus)
	{
		ArrayList matches = new ArrayList ();
		Transform portals = (type == PortalType.ORANGE) ? oranges.transform : purples.transform;

		foreach (Transform child in portals) {
			if (child.gameObject.activeSelf == activeStatus)
				matches.Add (child.gameObject);
		}

		if (matches.Count == 0)
			return null;

		int index = Random.Range (0, matches.Count);
		return (GameObject) matches[ index ];
	}

	void transport(GameObject obj, Vector3 dest){
		obj.transform.position = dest;
		randomVelocityChange(obj.GetComponent<Rigidbody>());
	}
}
