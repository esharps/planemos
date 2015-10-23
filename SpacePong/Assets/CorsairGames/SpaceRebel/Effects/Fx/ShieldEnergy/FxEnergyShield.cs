using UnityEngine;

public class FxEnergyShield : MonoBehaviour {
	// === Unity ======================================================================================================
	public float GrowSpeed = 0.5f;
	public Transform HitPointTransform;

	private void Awake() {
		_shieldMaterial = GetComponent<Renderer>().material;
		_shieldMaterial.SetFloat("_Magnitude", transform.localScale.x * transform.localScale.x * 0.4f);
	}

	private void Update() {
		if (_grow) {
			_rimPower01 += Time.deltaTime * GrowSpeed;
			if (_rimPower01 >= 1f) {
				_rimPower01 = 1f;
				_grow = false;
			}
			_shieldMaterial.SetFloat("_RimPower01", _rimPower01);
		} else if (_rimPower01 > 0) {
			_rimPower01 -= Time.deltaTime * GrowSpeed;
			if (_rimPower01 < 0) {
				_rimPower01 = 0;
			}
			_shieldMaterial.SetFloat("_RimPower01", _rimPower01);
		} else {
			enabled = false;
			_shieldMaterial.SetFloat("_RimPower01", 0);
		}
		_shieldMaterial.SetVector("_HitPoint", HitPointTransform.position);
	}

	// === Public =====================================================================================================
	public void SetHitPoint(Vector3 worldPosition) {
		HitPointTransform.position = worldPosition;
		_grow = true;
		_rimPower01 = 0;
		_shieldMaterial.SetVector("_HitPoint", worldPosition);
		_shieldMaterial.SetFloat("_RimPower01", _rimPower01);
		enabled = true;
	}

	// === Private ====================================================================================================
	private float _rimPower01;
	private bool _grow;
	private Material _shieldMaterial;
}