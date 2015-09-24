using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
//			GameObject.Find("Main Camera").SetActive(false);
			GetComponent<PlayerPaddle>().enabled = true;
			GetComponent<BoxCollider>().enabled = true;
		}
	}
}
