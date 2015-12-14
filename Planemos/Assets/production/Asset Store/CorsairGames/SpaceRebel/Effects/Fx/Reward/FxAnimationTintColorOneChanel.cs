using System;

public enum RGBA { R, G, B, A }

public class FxAnimationTintColorOneChanel : FxAnimationCurve {
	// === Unity =======================================================================================================
	public RGBA Chanel = RGBA.A;

	// === Public ======================================================================================================
	public override void Tick(FxTime time) {
		base.Tick(time);

		var value = Curve.Evaluate(time.Lifetime01);
		var color = GetComponent<UnityEngine.Renderer>().material.GetColor("_TintColor");
		switch (Chanel) {
			case RGBA.R:
				color.r = value;
				break;
			case RGBA.G:
				color.g = value;
				break;
			case RGBA.B:
				color.b = value;
				break;
			case RGBA.A:
				color.a = value;
				break;
			default:
				throw new Exception("wtf");
		}
		GetComponent<UnityEngine.Renderer>().material.SetColor("_TintColor", color);
	}
}