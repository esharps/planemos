using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	public float paddleSpped = 1.0f;
	private Vector3 playerPos = new Vector3(20, 0, 0);

	public Transform slidingPaddle;
	private Vector3 targetPos;

#if UNITY_EDITOR
	// Update is called once per frame
	void Update () {

		float yPos = transform.position.y + Input.GetAxis("Vertical") * paddleSpped;
		playerPos = new Vector3 (20, Mathf.Clamp (yPos, -9, 9), 0);
		transform.position = playerPos;
	}
#endif
	/**void Start() {
		targetPos = slidingPaddle.position;
	}

	void Update() {
		slidingPaddle.position = Vector3.Lerp (slidingPaddle.position, targetPos, Time.deltaTime * 7);
	}

	void OnTouchStay(Vector3 point) {
		targetPos = new Vector3 (targetPos.x, point.y, targetPos.z);
	}**/
}
