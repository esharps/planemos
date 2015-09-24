using UnityEngine;
using System.Collections;

public class PlayerPaddle : MonoBehaviour {

	public float paddleSpped = 1.0f;
	private Vector3 playerPos = new Vector3(20, 0, 0);

	public Transform slidingPaddle;
	private Vector3 targetPos;
	private Vector3 lastMousePos;

#if UNITY_EDITOR
	// Update is called once per frame
	void Update () {
		float yPos = transform.position.y + Input.GetAxis("Horizontal") * paddleSpped;
		playerPos = new Vector3 (20, Mathf.Clamp (yPos, -12.5f, 12.5f), 0);
		transform.position = playerPos;
	}

//	void OnMouseDown(){
//		Vector3 mousePos = Input.mousePosition;
//		mousePos.z = 0;
//		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
//		if(Input.GetMouseButtonDown(0)){
//			lastMousePos = worldMousePos;
//		}
//	}
//

	
#endif

	void OnMouseDrag(){
		
		float distance_to_screen = Camera.main.WorldToScreenPoint(transform.position).z;
		Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
		transform.position = new Vector3( transform.position.x, pos_move.y, transform.position.z );
		//		Vector3 mousePos = Input.mousePosition;
		//		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
		//		playerPos = new Vector3 (20, Mathf.Clamp (worldMousePos.y, -12.5f, 12.5f), 0);
		//		transform.position = playerPos;
		////		lastMousePos = worldMousePos;
	}

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