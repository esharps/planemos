using UnityEngine;
using System.Collections;

public class SlideablePaddleIOS : MonoBehaviour {
	
	public Transform slidingPaddle;
	private Vector3 targetPos;

	void Start() {
		targetPos = slidingPaddle.position;
	}
	
	void Update() {
		slidingPaddle.position = Vector3.Lerp (slidingPaddle.position, targetPos, Time.deltaTime * 7);
	}
	
	void OnTouchStay(Vector3 point) {
		targetPos = new Vector3 (targetPos.x, point.y, targetPos.z);
	}
}
