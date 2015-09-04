using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float speed = 30;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
	}
	
	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.name == "Player1Paddle") {

			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
			Vector2 dir = new Vector2(1, y).normalized;

			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}

		if (col.gameObject.name == "Player2Paddle") {
			
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
			Vector2 dir = new Vector2(-1, y).normalized;
			
			GetComponent<Rigidbody2D>().velocity = dir * speed;

		}
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
		return (ballPos.y - racketPos.y) / racketHeight;
	}


}
