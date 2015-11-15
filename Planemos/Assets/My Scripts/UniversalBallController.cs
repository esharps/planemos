using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UniversalBallController : MonoBehaviour {

	public MapContstraints mapConstraints;
	public float startSpeed;
	public float startDelay = 2f;


//	private Vector3 eulerAngleVelocity;
	Rigidbody rb;
	private bool ballInPlay = false;
	private int volleyCount = 0;
	private float speed;
	private ObjectRangeOfMotion motionField;
	private AxisOfPlay axisOfPlay;
	private Vector3 english;
	private RigidbodyConstraints rbConstraints;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.maxAngularVelocity = 50;
		speed = startSpeed;
		motionField = mapConstraints.objectMotionField;
		axisOfPlay = mapConstraints.axisOfPlay;
		english = Vector3.zero;



		if(motionField == ObjectRangeOfMotion.PLANAR) {
			rbConstraints = RigidbodyConstraints.FreezePositionY;
		}

		rb.constraints = RigidbodyConstraints.FreezeAll;
	}

	void FixedUpdate(){
		rb.AddForce (english);
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

	}

	// Initializes the ball movement and rotation after the specified startDelay ( in seconds )
	IEnumerator startBall(){
		yield return new WaitForSeconds(startDelay);
		rb.constraints = rbConstraints;
		rb.velocity = getRandomVelocity();
		rb.angularVelocity = getRandomDir() * 5;
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
		float x = Random.Range ( -10.0f, 10.0f );
		float y = Random.Range ( -3.0f, 3.0f );
		float z = Random.Range ( -10.0f, 10.0f );
		Vector3 dir = Vector3.zero;

		if(axisOfPlay == AxisOfPlay.Z) {
			x = Random.Range( -3.0f, 3.0f );
		}

		switch (motionField) {
		case ObjectRangeOfMotion.PLANAR:
			dir = new Vector3(x, 0, z);
			break;
		case ObjectRangeOfMotion.FULL_3D:
			dir = new Vector3(x, y, z);
			break;
		}

		return dir.normalized;

	}

	public void ResetVelocity(){
		rb.velocity = rb.velocity.normalized * speed;
	}

	// Resets the state of the ball to begin a new volley.
	public void resetBall(){
		ballInPlay = false;
//		eulerAngleVelocity = Vector3.zero;
		rb.velocity = Vector3.zero;
		english = Vector3.zero;
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
		if (coll.gameObject.CompareTag ("Enemy") || coll.gameObject.CompareTag ("Player")) {
			PaddleEnglish pe = coll.gameObject.GetComponent<PaddleEnglish>();
			volleyCount++;
			english.x = -pe.XVel * 50;
			english.y = -pe.YVel * 50;
			rb.velocity += new Vector3(pe.XVel * 10, pe.YVel * 10, 0);
			rb.angularVelocity += new Vector3(pe.YVel * 100, pe.XVel * 100, 0);

		} else {
			english = Vector3.zero;
		}

	}
	

	void OnCollisionExit( Collision c ){
		ResetVelocity();
	}
}
