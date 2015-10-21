using UnityEngine;

public class FxAsteroidExplosionFragment : MonoBehaviour {
    // === Unity ======================================================================================================
    private void Awake() {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();

        _lifetime = SHRINK_TIME;

        _transform.rotation = Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));

        _rigidbody.AddTorque(_transform.up * Random.Range(-IMPULSE_ROT, IMPULSE_ROT), ForceMode.Impulse);
        _rigidbody.AddTorque(_transform.right * Random.Range(-IMPULSE_ROT, IMPULSE_ROT), ForceMode.Impulse);
        _rigidbody.AddTorque(_transform.forward * Random.Range(-IMPULSE_ROT, IMPULSE_ROT), ForceMode.Impulse);

        _rigidbody.AddRelativeForce(new Vector3(Random.Range(-IMPULSE_FORCE, IMPULSE_FORCE), Random.Range(-IMPULSE_FORCE, IMPULSE_FORCE), Random.Range(-IMPULSE_FORCE, IMPULSE_FORCE)), ForceMode.Impulse);
    }

    private void Update() {
        _lifetime -= Time.deltaTime;
        if (_lifetime > 0) {
            var scaleVal = _lifetime / SHRINK_TIME;
            _transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
        } else {
            _rigidbody.velocity = _rigidbody.angularVelocity = Vector3.zero;
            enabled = false;
        }
    }

    // === Private ====================================================================================================
    private const float IMPULSE_FORCE = 100f;
    private const float IMPULSE_ROT = 100f;
    private const float SHRINK_TIME = 2.5f;
    private float _lifetime;
    private Transform _transform;
    private Rigidbody _rigidbody;
}