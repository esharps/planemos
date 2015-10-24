using UnityEngine;

public class FxAnimationCurveScale : FxAnimationCurve {
    // === Unity ======================================================================================================
    public bool X = true;
    public bool Y = true;
    public bool Z = true;
    public float ValueScale = 1f;

    protected override void Awake() {
        base.Awake();

        _localScaleOriginal = CachedTransform.localScale;
    }

    // === Public ======================================================================================================
    public override void Tick(FxTime time) {
        base.Tick(time);

        var scale = _localScaleOriginal;
        var value = Curve.Evaluate(time.Lifetime01) * ValueScale;
        scale.x = X ? scale.x + value : CachedTransform.localScale.x;
        scale.y = Y ? scale.y + value : CachedTransform.localScale.y;
        scale.z = Z ? scale.z + value : CachedTransform.localScale.z;
        CachedTransform.localScale = scale;
    }

    // === Private ====================================================================================================
    private Vector3 _localScaleOriginal;
}