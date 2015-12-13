using UnityEngine;

public class AutoDestruction : MonoBehaviour {
	// === Unity ======================================================================================================
	public float Lifetime = 2f;

	private void Update() {
		Lifetime -= Time.deltaTime;
		if (Lifetime <= 0) {
			Destroy(gameObject);
		}
	}
}