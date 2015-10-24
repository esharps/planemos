using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BallNetworkSetup : NetworkBehaviour {
	
	// Use this for initialization
	void Start () { 
		GetComponent<SphereCollider>().enabled = true;		

		if (isServer) {
			GetComponent<BallController>().enabled = true;
		}
	}
}
