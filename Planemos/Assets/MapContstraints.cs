using UnityEngine;
using System.Collections;

public class MapContstraints : MonoBehaviour {

	public enum MotionType{ XY_PLANAR = 0, XZ_PLANAR, FULL_3D }
	public enum AxisOfPlay{ X = 0, Y, Z, OPEN }
	
	public MotionType motionType;
	public AxisOfPlay axisOfPlay;

	public MotionType GetMotionType(){
		return motionType;
	}

	public void SetMotionType(MotionType motionType){
		this.motionType = motionType;
	}

	public AxisOfPlay GetAxisOfPlay(){
		return axisOfPlay;
	}

	public void SetAxisOfPlay(AxisOfPlay axisOfPlay){
		this.axisOfPlay = axisOfPlay;
	}
}
