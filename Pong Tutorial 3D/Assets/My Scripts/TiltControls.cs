using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class TiltControls : MonoBehaviour
{

	public Text debugText;
	public float sensitivity = 90f;
	public float speed = 10.0F;
	public float xBound = 12.5F;
	public float yBound = 8F;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		//Vector3 inputValue;

		/*inputValue.x = CrossPlatformInputManager.GetAxis ("Horizontal");
		inputValue.y = CrossPlatformInputManager.GetAxis ("Vertical");
		inputValue.z = 0f;

		//string x = inputValue.x.ToString ();
		//string y = inputValue.y.ToString ();
		//string z = inputValue.z.ToString ();

		*/

			

		/*Vector3 dir = Vector3.zero;
		dir.x = -Input.acceleration.y;
		dir.z = Input.acceleration.x;
		if (dir.sqrMagnitude > 1)
			dir.Normalize ();
				
		dir *= Time.deltaTime;
		transform.Translate (dir * speed);*/

		float xPos = transform.position.x + Input.acceleration.x;
		float yPos = transform.position.y + Input.acceleration.y;
		Vector3 playerPos = new Vector3 (Mathf.Clamp (xPos, -xBound, xBound), Mathf.Clamp(yPos, -yBound, yBound), transform.position.z);
		transform.position = playerPos;

		debugText.text = "" + Input.acceleration.x + ", " + Input.acceleration.y + ", " + Input.acceleration.z;

	}
}

	


