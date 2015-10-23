using UnityEngine;
using System.Collections;

public class PortalRotation : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, -1, Space.Self);
	}
}
