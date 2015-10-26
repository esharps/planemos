using UnityEngine;
using System.Collections;

public class PaddleControls : MonoBehaviour {

	public float paddleSpeed = 1.0f;
	public float xBound;
	public float yBound;
	private Vector3 playerPos;
	private Vector3 targetPos;
	private Vector3 lastMousePos;
	private Rigidbody thisRb;


	void Start(){
		thisRb = GetComponent<Rigidbody> ();
	}
	

	// Update is called once per frame
	void Update () {
		float xPos;
		float yPos;
		#if UNITY_EDITOR
		xPos = transform.position.x + Input.GetAxis("Horizontal") * paddleSpeed;
		yPos = transform.position.y + Input.GetAxis ("Vertical") * paddleSpeed;
//		playerPos = new Vector3 (Mathf.Clamp (xPos, -xBound, xBound), Mathf.Clamp(yPos, -yBound, yBound), transform.position.z);
		playerPos = new Vector3 (xPos, yPos, transform.position.z);
		thisRb.MovePosition (playerPos);
		//		transform.position = playerPos;
		#endif

//		float distance_to_screen = Camera.main.WorldToScreenPoint (transform.position).z;
//		Vector3 pos_move = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
//		playerPos = new Vector3 (xPos, yPos, transform.position.z);
//		thisRb.MovePosition( playerPos );

	}

//	void OnMouseDrag(){
//		float distance_to_screen = Camera.main.WorldToScreenPoint (transform.position).z;
//		playerPos = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
//		transform.position = new Vector3 (Mathf.Clamp(pos_move.x, -xBound, xBound), Mathf.Clamp(pos_move.y, -yBound, yBound), transform.position.z);
//		thisRb.MovePosition (new Vector3 (Mathf.Clamp (pos_move.x, -xBound, xBound), Mathf.Clamp (pos_move.y, -yBound, yBound), transform.position.z));
//	}

}