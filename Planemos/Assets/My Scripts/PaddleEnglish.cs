using UnityEngine;
using System.Collections;

public class PaddleEnglish : MonoBehaviour {

	private float lastX;
	public float XVel;

	private void Start(){
		lastX = transform.position.x;
		XVel = 0;
	}

	
	private void FixedUpdate(){
		XVel = transform.position.x - lastX;
		lastX = transform.position.x;
	}
}
