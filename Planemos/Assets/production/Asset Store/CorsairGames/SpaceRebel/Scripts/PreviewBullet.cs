using System;
using UnityEngine;

public class PreviewBullet : Preview {
    // == Unity =======================================================================================================
    [Serializable]
    public struct Bullet {
        public GameObject BodyPrefab;
        public GameObject DeathPrefab;
        public GameObject TrailPrefab;
    }

    public Bullet[] Bullets;
    public float TrailAutoDestructionTime = 2f;
    public float BoomLifetime = 1;

    protected virtual void Awake() {
        _startX = (Bullets.Length - 1) * -0.5f * INSTANTIATE_STEP;
        _transform = GetComponent<Transform>();
        _instTransformArray = new Transform[Bullets.Length];
        _trailTransformArray = new Transform[Bullets.Length];
        SetBulletBodyMode();
    }

    private void Update() {
        _lifetimeRest -= Time.deltaTime;
        if (_lifetimeRest > 0) {
            if (!_boom) {
                for (var i = 0; i < _instTransformArray.Length; i++) {
                    var pos = _instTransformArray[i].position;
                    pos.z += _bulletSpeed * Time.deltaTime;
                    _instTransformArray[i].position = pos;
                }
            }
        } else {
            if (_boom) {
                ClearArray();
                SetBulletBodyMode();
            } else {
                ClearArray();
                SetBulletBoomMode();
            }
        }
    }

    // === Protected ==================================================================================================

    protected virtual void SetBulletBodyMode() {
        _boom = false;
        _lifetimeRest = BULLET_LIFETIME;
        for (var i = 0; i < _instTransformArray.Length; i++) {
            var pos = new Vector3(_startX + INSTANTIATE_STEP * i, 0, START_Z);
            _instTransformArray[i] = ((GameObject)Instantiate(Bullets[i].BodyPrefab, pos, Quaternion.identity)).GetComponent<Transform>();
            _instTransformArray[i].SetParent(_transform);
            if (Bullets[i].TrailPrefab != null) {
                _trailTransformArray[i] = ((GameObject)Instantiate(Bullets[i].TrailPrefab, pos, Quaternion.identity)).GetComponent<Transform>();
                _trailTransformArray[i].SetParent(_instTransformArray[i]);
            }
        }
    }

    protected virtual void SetBulletBoomMode() {
        _boom = true;
        _lifetimeRest = BoomLifetime;
        for (var i = 0; i < _instTransformArray.Length; i++) {
            if (Bullets[i].DeathPrefab != null) {
                var pos = new Vector3(_startX + INSTANTIATE_STEP * i, 0, FINISH_Z);
                _instTransformArray[i] = ((GameObject)Instantiate(Bullets[i].DeathPrefab, pos, Quaternion.identity)).GetComponent<Transform>();
                _instTransformArray[i].SetParent(_transform);
            }
        }
    }

    // === Private ====================================================================================================
    private Transform[] _instTransformArray;
    private Transform[] _trailTransformArray;
    private Transform _transform;
    private float _lifetimeRest;
    private bool _boom;
    private const int BULLET_LIFETIME = 1;
    private readonly float _bulletSpeed = (FINISH_Z - START_Z) / (float)BULLET_LIFETIME;
    private const int INSTANTIATE_STEP = 10;
    private float _startX;
    private const int START_Z = -40;
    private const int FINISH_Z = 40;

    private void ClearArray() {
        for (var i = 0; i < _instTransformArray.Length; i++) {
            if (_trailTransformArray[i] != null) {
                _trailTransformArray[i].SetParent(_transform);
                _trailTransformArray[i].gameObject.AddComponent<AutoDestruction>().Lifetime = TrailAutoDestructionTime;
                _trailTransformArray[i] = null;
            }
            if (_instTransformArray[i] != null) {
                Destroy(_instTransformArray[i].gameObject);
            }
        }
    }
}
