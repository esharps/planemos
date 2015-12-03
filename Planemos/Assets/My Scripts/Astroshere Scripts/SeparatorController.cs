using UnityEngine;
using System.Collections;

public class SeparatorController : MonoBehaviour {

	public GameObject associatedSeparator;

	public void RemoveSeparator(){
		Object.Destroy(associatedSeparator);
	}
}
