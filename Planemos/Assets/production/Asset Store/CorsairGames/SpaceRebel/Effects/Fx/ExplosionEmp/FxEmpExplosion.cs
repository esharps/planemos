using UnityEngine;
using System.Collections;

public class FxEmpExplosion : MonoBehaviour
{
    public float Radius = 5f;
    static Vector2 _scroll = new Vector2 (5f, -3f);

    IEnumerator Start ()
    {
        var render = GetComponentInChildren<MeshRenderer> ();
        if (render == null) {
            Destroy (gameObject);
            yield break;
        }

        // Cache for optimization.
        var trans = transform;
        var endScale = Vector3.one * Radius * 2f;
        var mtrl = render.material;

        var scaleOutTime = Radius * 0.2f;
        var t = 0f;
        while (t < 1f) {
            trans.localScale = Vector3.Lerp (Vector3.zero, endScale, t);
            t += Time.deltaTime / scaleOutTime;
            mtrl.SetFloat ("_TimeSlider", t);
            mtrl.mainTextureOffset += _scroll * Time.deltaTime;
            yield return new WaitForEndOfFrame ();
        }
        Destroy (gameObject);
    }
}
