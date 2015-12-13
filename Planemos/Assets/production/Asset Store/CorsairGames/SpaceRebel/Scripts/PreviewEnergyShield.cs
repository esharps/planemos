using UnityEngine;

public class PreviewEnergyShield : Preview {
    // === Unity ======================================================================================================
    public FxEnergyShield Shield;

    private void Update() {
        _timeRest -= Time.deltaTime;
        if (_timeRest <= 0) {
            _timeRest += Random.value;
            Shield.SetHitPoint(Random.onUnitSphere * 52);
        }
    }

    // === Private ====================================================================================================
    private float _timeRest;
}
