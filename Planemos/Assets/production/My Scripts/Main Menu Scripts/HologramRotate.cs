using UnityEngine;
using System.Collections;

public class HologramRotate : MonoBehaviour {

    public GameObject outer;
    public GameObject inner;

    private float startTime = 0.0f;
    private float duration = 10.0f;
    private SpriteRenderer rendOuter;
    private SpriteRenderer rendInner;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        rendOuter = outer.GetComponent<SpriteRenderer>();
        rendInner = inner.GetComponent<SpriteRenderer>();    
	}
	
	// Update is called once per frame
	void Update () {
        if (MainMenuStartup.rays)
        {
            rendOuter.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(-0.1f, 1.0f, (Time.time - startTime) / duration));
            rendInner.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(-0.1f, 1.0f, (Time.time - startTime) / duration));
        }

        outer.transform.Rotate(0.0f, 0.0f, 0.2f);
        inner.transform.Rotate(0.0f, 0.0f, -0.2f);
	}
}
