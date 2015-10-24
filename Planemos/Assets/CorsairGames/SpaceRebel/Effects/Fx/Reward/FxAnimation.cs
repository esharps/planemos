using UnityEngine;

public class FxAnimation : MonoBehaviour {
	// === Unity ======================================================================================================
	protected virtual void Awake() {
        CachedGameObject = gameObject;
        CachedTransform = GetComponent<Transform>();
		CachedRenderer = GetComponent<Renderer>();
	}

	// === Public =====================================================================================================
	public Transform CachedTransform { get; private set; }
	public GameObject CachedGameObject { get; private set; }
	public Renderer CachedRenderer { get; private set; }

	public virtual void Tick(FxTime time) { }
}