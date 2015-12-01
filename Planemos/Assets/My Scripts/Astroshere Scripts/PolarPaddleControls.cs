using UnityEngine;
using System.Collections;

public class PolarPaddleControls : MonoBehaviour {

	public float paddleSpeed;
	PolarCalculator polarCalc;

	// Use this for initialization
	void Start () {
		polarCalc = GetComponent<PolarCalculator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaAngle = Input.GetAxis ("Horizontal") * paddleSpeed;
		polarCalc.Move (deltaAngle);
	}
}
