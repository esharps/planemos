using UnityEngine;

public class FxVoidRayOld : MonoBehaviour {
    // === Unity ======================================================================================================
    public float Power01;
    public ParticleSystem RaysMain;
    public ParticleSystem RaysAddit;
    public ParticleSystem SpaceToEnergy;
    public ParticleSystem EnergyToRay;
    public Transform _targetTransform;
    public GameObject CollisionPrefab;

    private void Awake() {
        _transform = transform;
        _raysMainTransform = RaysMain.transform;
        _raysAdditTransform = RaysAddit.transform;
        SetTarget(_targetTransform);
    }

    private void Start() {
        if (_targetTransform == null) {
            Debug.LogError("Target is null");
            enabled = false;
        }
        Power01 = 0;
        DoUpdate();
    }

    private void OnDestroy() {
        if (_collisionDeathCtrl != null) {
            Destroy(_collisionDeathCtrl.gameObject);
        }
    }

    private void Update() {
        if (_targetTransform == null) {
            return;
        }
        _transform.rotation = Quaternion.LookRotation(Vector3.forward, _targetTransform.position - _transform.position);
        var distToTarget = Vector3.Distance(_transform.position, _targetTransform.position);
        RaysMain.startLifetime = (distToTarget - 90f) / 200f;
        _raysAdditTransform.localPosition = new Vector3(0, distToTarget * 0.5f - 100f, 0);
        _raysAdditTransform.localScale = new Vector3(_raysAdditTransform.localScale.x, _raysAdditTransform.localScale.y, distToTarget * 0.5f);

        if (_localPower01 < Power01) {
            DoUpdate();
        }
    }

    // === Public =====================================================================================================
    public void SetTarget(Transform targetTransform) {
        _targetTransform = targetTransform;
        if (_collisionDeathCtrl == null) {
            //var prefab = Game.ResourcesManager.Load<GameObject>(Constants.PathInRes.FX.PATH + "FX_VoidRay_CollisionDeath");
            //_collisionDeathCtrl = Tool.Builder.CreateGameObject(prefab).GetComponent<FxVoidRayCollisionDeath>();
            _collisionDeathCtrl = ((GameObject)Instantiate(CollisionPrefab, _targetTransform.position, Quaternion.identity)).GetComponent<FxVoidRayCollisionDeath>();
        }
        _collisionDeathCtrl.transform.parent = targetTransform;
        _collisionDeathCtrl.transform.localPosition = Vector3.up * 20f;
        _collisionDeathCtrl.SetPower01(_localPower01);
    }

    // === Private ====================================================================================================
    private Transform _transform;
    private float _localPower01;
    private Transform _raysMainTransform;
    private Transform _raysAdditTransform;
    private FxVoidRayCollisionDeath _collisionDeathCtrl;

    private void DoUpdate() {
        Power01 = Mathf.Clamp01(Power01);
        _localPower01 = Power01;

        var scale = new Vector3(Mathf.Lerp(0.4f, 1f, _localPower01), 1f, 1f);
        _raysMainTransform.localScale = scale;
        //_raysAdditTransform.localScale = scale;
        _raysAdditTransform.localScale = new Vector3(scale.x, _raysAdditTransform.localScale.y, _raysAdditTransform.localScale.z);
        RaysMain.emissionRate = RaysAddit.emissionRate = Mathf.Lerp(5f, 15f, _localPower01);

        var energyCount = Mathf.Lerp(20f, 50f, _localPower01);
        EnergyToRay.transform.localScale = scale;
        EnergyToRay.emissionRate = energyCount;

        SpaceToEnergy.transform.localScale = scale;
        SpaceToEnergy.emissionRate = energyCount * 2f;

        _collisionDeathCtrl.SetPower01(_localPower01);
    }
}