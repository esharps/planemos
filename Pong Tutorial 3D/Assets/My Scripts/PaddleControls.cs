using UnityEngine;
using System.Collections;

public class PaddleControls : MonoBehaviour {

	public float paddleSpeed = 1.0f;
	private Vector3 playerPos;
	
	private Vector3 targetPos;
	private Vector3 lastMousePos;
	
#if UNITY_EDITOR
	// Update is called once per frame
	void Update () {
		float xPos = transform.position.x + Input.GetAxis("Horizontal") * paddleSpeed;
		float yPos = transform.position.y + Input.GetAxis ("Vertical") * paddleSpeed;
		playerPos = new Vector3 (Mathf.Clamp (xPos, -12.5f, 12.5f), Mathf.Clamp(yPos, -10, 10), transform.position.z);
		transform.position = playerPos;
	}
	
#endif
	void OnMouseDrag(){
		float distance_to_screen = Camera.main.WorldToScreenPoint(transform.position).z;
		Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,  distance_to_screen));
		transform.position = new Vector3( pos_move.x, pos_move.y, transform.position.z );
	}
}