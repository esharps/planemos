using UnityEngine;
using System.Collections;

public class PaddleEnglish : MonoBehaviour {

	private float lastX;
	private float lastY;
	public float XVel;
	public float YVel;

	private void Start(){
		lastX = transform.position.x;
		lastY = transform.position.y;
		XVel = 0;
		YVel = 0;
	}

	
	private void Update(){
		XVel = transform.position.x - lastX;
		YVel = transform.position.y - lastY;
		lastX = transform.position.x;
		lastY = transform.position.y;
	}
}
