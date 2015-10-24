using UnityEngine;

public class PreviewManager : MonoBehaviour {
    // === Unity ======================================================================================================
    //public int DebugDist;
    public GameObject[] Prefabs;

    private void Awake() {
        Application.targetFrameRate = 60;
        _transform = GetComponent<Transform>();
        //DebugDist = (int)_transform.position.magnitude;
    }

    private void Start() {
        InstantiatePreview();
        RefreshCamDistsance();
    }

    private void Update() {
        _transform.RotateAround(Vector3.zero, Vector3.up, CAMERA_ROTATION_SPEED * Time.deltaTime);
        //_transform.position = _transform.position.normalized * DebugDist;
    }

    private void OnGUI() {
        GUI.color = Color.green;
        if (GUI.Button(new Rect(0, Screen.height * 0.5f, 100, 100), "Prev")) {
            DestroyPreview();
            if (--_prefabIndex == -1) {
                _prefabIndex = Prefabs.Length - 1;
            }
            InstantiatePreview();
            RefreshCamDistsance();
        }
        if (GUI.Button(new Rect(Screen.width - 100, Screen.height * 0.5f, 100, 100), "Next")) {
            DestroyPreview();
            if (++_prefabIndex == Prefabs.Length) {
                _prefabIndex = 0;
            }
            InstantiatePreview();
            RefreshCamDistsance();
        }
        if (_previewGameObject == null) {
            InstantiatePreview();
        }
        GUI.Label(new Rect((Screen.width - 300) * 0.5f, 0, 300, 100), (_prefabIndex + 1) + "/" + Prefabs.Length + " - " + _previewGameObject.name);
    }

    // === Private ====================================================================================================
    private Transform _transform;
    private int _prefabIndex;
    private int CAMERA_ROTATION_SPEED = 20;
    private GameObject _previewGameObject;

    private void RefreshCamDistsance() {
        var camDist = _previewGameObject.GetComponent<Preview>().CameraDistance;
        //DebugDist = camDist;
        _transform.position = _transform.position.normalized * camDist;
    }

    private void InstantiatePreview() {
        var prefab = Prefabs[_prefabIndex];
        _previewGameObject = (GameObject)Instantiate(prefab);
        _previewGameObject.name = prefab.name;
    }

    private void DestroyPreview() {
        if (_previewGameObject != null) {
            Destroy(_previewGameObject);
            _previewGameObject = null;
        }
    }
}
