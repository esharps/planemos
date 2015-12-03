using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DopplerShift : MonoBehaviour {


	Queue<float> zPosQueue, timeQueue;
	public int pointSpan = 5;
	public static int redShift;
	public static int blueShift;


	// Use this for initialization
	void Start () {
		redShift = 0;
		blueShift = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (zPosQueue.Count < pointSpan || timeQueue.Count < pointSpan) {

			zPosQueue.Enqueue (BallPositionTrackerTF.ballPosZ);
			timeQueue.Enqueue (Time.time);
		} else {

			SetShift(zPosQueue, timeQueue);

			zPosQueue.Dequeue();
			timeQueue.Dequeue();
		}
	
	}

	public void SetShift(Queue<float> z, Queue<float> t) {

		float[] zArray = new float[z.Count];
		zArray = z.ToArray ();
		float[] timeArray = new float[t.Count];
		timeArray = t.ToArray ();

		float zInitial = zArray [0];
		float zFinal = zArray [zArray.Length - 1];

		float timeInitial = timeArray [0];
		timeInitial = Mathf.Round (timeInitial * 1000f) / 1000f;
		float timeFinal = timeArray [timeArray.Length - 1];
		timeFinal = Mathf.Round (timeFinal * 1000f) / 1000f;

		float zVelocity = ((zFinal - zInitial) / (timeFinal - timeInitial));

		if (zVelocity > 0) {
			blueShift = 1;
			redShift = 0;
		}
		if (zVelocity < 0) {
			blueShift = 0;
			redShift = 1;
		}

	} //End of SetShift method

} //End of DopplerShift class
