using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UniversalBallController : MonoBehaviour {

	public MapContstraints mapConstraints;
	public float startSpeed;
	public float startDelay = 2f;


	private Vector3 eulerAngleVelocity;
	Rigidbody rb;
	private bool ballInPlay = false;
	private int volleyCount = 0;
	private float speed;
	private ObjectRangeOfMotion motionField;
	private AxisOfPlay axisOfPlay;
	private RigidbodyConstraints rbConstraints;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		speed = startSpeed;
		motionField = mapConstraints.objectMotionField;
		axisOfPlay = mapConstraints.axisOfPlay;



		if(motionField == ObjectRangeOfMotion.PLANAR) {
			rbConstraints = RigidbodyConstraints.FreezePositionY;
		}

		rb.constraints = RigidbodyConstraints.FreezeAll;
	}

	void FixedUpdate(){
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		rb.MoveRotation(rb.rotation * deltaRotation);
	}

	// Update is called once per frame
	void Update () {
		if (!ballInPlay) {
			ballInPlay = true;
			StartCoroutine(startBall());
		}

		else {
			if( volleyCount > 2 ){
				volleyCount = 0;
				speed *= 1.1f;
			}
		}
	}

	void LateUpdate(){
		rb.velocity = rb.velocity.normalized * speed;
	}

	// Initializes the ball movement and rotation after the specified startDelay ( in seconds )
	IEnumerator startBall(){
		yield return new WaitForSeconds(startDelay);
		rb.constraints = rbConstraints;
		eulerAngleVelocity = new Vector3(
			Random.Range (-200, 200),
			Random.Range (-200, 200),
			Random.Range (-200, 200)
			);

		rb.velocity = getRandomVelocity();
	}

	// Returns a velocity vector in a random direction
	// based on the getRandomDir() function. Velocity
	// magnitude will be the current ball speed.
	Vector3 getRandomVelocity(){
		Vector3 dir = getRandomDir();
		Vector3 vel = dir * speed;
		return vel;
	}

	// Returns a normalized vector pointing in a random direction
	// Will favor direction along the axis of play, as well as
	// return a vector in the expected plane of motion (for 2D gameplay)
	Vector3 getRandomDir(){
		float x = Random.Range ( -1.0f, 1.0f );
		float y = Random.Range ( -1.0f, 1.0f );
		float z = Random.Range ( -1.0f, 1.0f );
		Vector3 dir = Vector3.zero;

		if(axisOfPlay == AxisOfPlay.Z) {
			x = Random.Range( -0.5f, 0.5f );
		}

		switch (motionField) {
		case ObjectRangeOfMotion.PLANAR:
			dir = new Vector3(x, 0, y);
			break;
		case ObjectRangeOfMotion.FULL_3D:
			dir = new Vector3(x, y, z);
			break;
		}

		return dir.normalized;

	}

	// Resets the state of the ball to begin a new volley.
	public void resetBall(){
		ballInPlay = false;
		eulerAngleVelocity = Vector3.zero;
		rb.velocity = Vector3.zero;
		transform.position = Vector3.zero;
		speed = startSpeed;
		volleyCount = 0;
		rb.constraints = RigidbodyConstraints.FreezeAll;
	}

	// Returns true if the ball's velocity vector points toward the given position
	public bool isMovingToward(Vector3 pos){
		Vector3 ballToPos = pos - transform.position;
		return Vector3.Dot(rb.velocity, ballToPos) > 0;
	}

	void OnCollisionEnter( Collision coll ){

		// Increment the volley count if the ball collides with a paddle.
		if(coll.gameObject.CompareTag ("Enemy") || coll.gameObject.CompareTag("Player"))
			volleyCount++;

	}
}
