using UnityEngine;

public class FxPlasmaCtrl : MonoBehaviour {
	// === Unity ======================================================================================================
	public ParticleSystem CoreBall;
	public ParticleSystem CoreElecticSparks;
	public ParticleSystem Overcharging;
	public ParticleSystem SpaceEnergy;
	public ParticleSystem ChargingWave;

	private void Start() {
		charchingTime = ChargingWave.startDelay;
		loopTime = CoreBall.duration;
		_coreBallTransform = CoreBall.transform;
		_coreElecticSparksTransform = CoreElecticSparks.transform;
	}

	private void Update() {
		/*
		// OLD
		localtime += Time.deltaTime;
		var chargingTime01 = Mathf.InverseLerp(0, charchingTime, localtime);

		CoreBall.startSize = Mathf.Lerp(35, 70, chargingTime01);
		_coreBallTransform.localScale = Vector3.one * Mathf.Lerp(1f, 3f, chargingTime01);

		CoreElecticSparks.startSize = Mathf.Lerp(7, 15, chargingTime01);
		_coreElecticSparksTransform.localScale = Vector3.one * Mathf.Lerp(1f, 3f, chargingTime01);

		if (localtime > loopTime) {
			localtime -= loopTime;
		}*/

		// NEW: loop is disabled. After all children were played destroy GO
		localtime += Time.deltaTime;
		if (localtime <= loopTime) {
			var chargingTime01 = Mathf.InverseLerp(0, charchingTime, localtime);

			CoreBall.startSize = Mathf.Lerp(35, 70, chargingTime01);
			_coreBallTransform.localScale = Vector3.one * Mathf.Lerp(1f, 3f, chargingTime01);

			CoreElecticSparks.startSize = Mathf.Lerp(7, 15, chargingTime01);
			_coreElecticSparksTransform.localScale = Vector3.one * Mathf.Lerp(1f, 3f, chargingTime01);

			localtime -= loopTime;
		} else if (!GetComponent<ParticleSystem>().IsAlive(true)) {
			Destroy(gameObject);
		}
	}

	// === Public =====================================================================================================
	public float ChargingDuration { get { return CoreBall.duration; } }

	public void StopCharging() {
		Overcharging.enableEmission = SpaceEnergy.enableEmission = ChargingWave.enableEmission = false;
		Destroy(this);
	}

	// === Private ====================================================================================================
	private float localtime;
	private float loopTime;
	private float charchingTime;
	private Transform _coreBallTransform;
	private Transform _coreElecticSparksTransform;
}
