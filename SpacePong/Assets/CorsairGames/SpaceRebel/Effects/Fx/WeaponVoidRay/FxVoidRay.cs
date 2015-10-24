using System;
using UnityEngine;

public class FxVoidRay : MonoBehaviour {
	// === Unity ======================================================================================================
	public float Power01;
	public ParticleSystem FireStart;
	public Transform LaserCore;
	public ParticleSystem LaserWave;
	public Transform TempTransform;

	private void Awake() {
		_transform = transform;
		_laserWaveTransform = LaserWave.transform;

		_waveParticleStartSpeedOriginal = LaserWave.startSpeed;
		_waveParticleRenderer = (ParticleSystemRenderer)_laserWaveTransform.GetComponent<Renderer>();
		_waveParticleLengthOriginal = _waveParticleRenderer.lengthScale * LaserWave.startSize;
		_waveParticleLifeOriginal = LaserWave.startSpeed * LaserWave.startLifetime;
		_waveParticleMinPathOriginal = _waveParticleLifeOriginal + _waveParticleLengthOriginal;

		LaserWave.startSpeed = 0;
	}

	private void Start() {
		_localPower01 = -1;
		Power01 = 0;
	}

	private void OnDestroy() {
		if (CollisionDeathFx) {
			CollisionDeathFx = false;
		}
	}

	private void Update() {
		if (TempTransform != null) {
			HitPoint = TempTransform.position;
			_transform.rotation = Quaternion.LookRotation(Vector3.forward, HitPoint - _transform.position);
		}
		// refresh CollisionDeathFx position
		if (CollisionDeathFx) {
			_collisionDeathCtrl.MyTransform.position = HitPoint;
		}
		// look at hit point
		//_transform.rotation = Quaternion.LookRotation(Vector3.forward, HitPoint - _transform.position);
		// length adjusment
		var distToTarget = Vector3.Distance(_transform.position, HitPoint);
		LaserCore.localScale = new Vector3(distToTarget, LaserCore.localScale.y, LaserCore.localScale.z);
		float maxPath = 0;
		if (distToTarget - _waveParticleMinPathOriginal < 1f) {
			if (distToTarget >= _waveParticleLengthOriginal) {
				_waveParticleRenderer.enabled = true;
				LaserWave.startSpeed = (distToTarget - _waveParticleLengthOriginal) / LaserWave.startLifetime;
				maxPath = distToTarget - LaserWave.startSpeed * LaserWave.startLifetime - _waveParticleLengthOriginal;
			} else {
				_waveParticleRenderer.enabled = false;
			}
		} else {
			_waveParticleRenderer.enabled = true;
			LaserWave.startSpeed = _waveParticleStartSpeedOriginal;
			maxPath = distToTarget - _waveParticleLifeOriginal - _waveParticleLengthOriginal;
		}
		var localPositionOld = _laserWaveTransform.localPosition.y;
		_laserWaveTransform.localScale = new Vector3(_laserWaveTransform.localScale.x, _laserWaveTransform.localScale.y, maxPath);
		// NOTE must be (maxPath + _waveParticleLengthOriginal) * 0.5f, but with maxPath * 0.5f + _waveParticleLengthOriginal much better
		_laserWaveTransform.localPosition = new Vector3(0, maxPath * 0.5f + _waveParticleLengthOriginal, 0);
		var offset = new Vector3(0, 0, localPositionOld - _laserWaveTransform.localPosition.y);
		if (particles.Length < LaserWave.particleCount) {
			particles = new ParticleSystem.Particle[LaserWave.particleCount];
		}
		var particleCount = LaserWave.GetParticles(particles);
		for (var i = 0; i < particleCount; i++) {
			particles[i].position += offset;
		}
		LaserWave.SetParticles(particles, particleCount);

		// power adjustment
		if (Mathf.Abs(_localPower01 - Power01) > float.Epsilon) {
			_localPower01 = Power01 = Mathf.Clamp01(Power01);
			LaserCore.localScale = new Vector3(LaserCore.localScale.x, Mathf.Lerp(6f, 12f, _localPower01), LaserCore.localScale.z);
			_laserWaveTransform.localScale = new Vector3(Mathf.Lerp(1f, 2f, _localPower01), _laserWaveTransform.localScale.y, _laserWaveTransform.localScale.z);
			FireStart.startSize = Mathf.Lerp(15f, 30f, _localPower01);
			if (CollisionDeathFx) {
				_collisionDeathCtrl.SetPower01(_localPower01);
			}
		}
	}

	// === Public =====================================================================================================
	public Vector3 HitPoint { get; set; }
	ParticleSystem.Particle[] particles = new ParticleSystem.Particle[0];

	public bool CollisionDeathFx {
		get { return _collisionDeathCtrl != null; }
		set {
			if (value) {
				if (CollisionDeathFx) {
					throw new ArgumentException();
				}
				//var prefab = Game.ResourcesManager.Load<GameObject>(Constants.LevelObjects.Weapon.VoidRay.COLLISION_DEATH);
				//_collisionDeathCtrl = Tool.Builder.CreateGameObject(prefab).GetComponent<FxVoidRayCollisionDeath>();
			} else {
				if (!CollisionDeathFx) {
					throw new ArgumentException();
				}
				Destroy(_collisionDeathCtrl.gameObject);
				_collisionDeathCtrl = null;
			}
		}
	}

	public void ResetWave() {
		LaserWave.Clear();
	}

	// === Private ====================================================================================================
	private Transform _transform;
	private Transform _laserWaveTransform;
	private float _localPower01;
	private FxVoidRayCollisionDeath _collisionDeathCtrl;

	private float _waveParticleLengthOriginal;
	private float _waveParticleStartSpeedOriginal;
	private float _waveParticleLifeOriginal;
	private float _waveParticleMinPathOriginal;
	private ParticleSystemRenderer _waveParticleRenderer;
}