using System;
using UnityEngine;

public class FxVoidRayCollisionDeath : MonoBehaviour {
    // === Unity ======================================================================================================
    public ParticleSystem DeathSmoke;
    public ParticleSystem DeathWave;

    private void Awake() {
        MyTransform = transform;
        SetPower01(1f);
    }

    // === Public =====================================================================================================
    public Transform MyTransform { get; private set; }

    public void SetPower01(float value) {
        if (value < 0 || 1f < value) {
            throw new ArgumentException(value.ToString());
        }
        DeathSmoke.startSize = DeathWave.startSize = Mathf.Lerp(15f, 30f, value);
    }
}