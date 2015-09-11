using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	public float paddleSpped = 1.0f;

	private Vector3 playerPos = new Vector3(20, 0, 0);

	
	// Update is called once per frame
	void Update () {

		float yPos = transform.position.y + Input.GetAxis("Vertical") * paddleSpped;
		playerPos = new Vector3 (20, Mathf.Clamp (yPos, -9, 9), 0);
		transform.position = playerPos;
	}
}
