using System;
using UnityEngine;

public class FxTime : MonoBehaviour {
	// === Unity ======================================================================================================
	public bool Loop;
	// LoopCycle => true 0->0.2->0.5-0.7->1->0->0.2 ...; false 0->0.2->0.5-0.7->1->0.7->0.5
	public bool LoopCycle;
	// in seconds
	public float Lifetime;
	public bool IncrementAtStart;

	private void Start() {
		_anims = GetComponentsInChildren<FxAnimation>();
		if (_anims.Length == 0) {
			throw new Exception("no animation");
		}

		SetLifetime(Lifetime);
	}

	private void Update() {
		RefreshTimeVariables();
		RefreshAnimations();
	}

	// === Public =====================================================================================================
    public float LifetimeRest;
    public float Lifetime01;

	public void SetLifetime(float value) {
		if (value < 0f) {
			throw new Exception("lifetime must be grater than zero " + Lifetime);
		}
		Lifetime = value;

		_incrementerMode = IncrementAtStart;
		if (_incrementerMode) {
			LifetimeRest = 0f;
			Lifetime01 = 0f;
		} else {
			LifetimeRest = Lifetime;
			Lifetime01 = 1f;
		}
	}

	// === Private ====================================================================================================
	private FxAnimation[] _anims;
	private bool _incrementerMode;

	private void RefreshTimeVariables() {
		var deltaTime = Time.deltaTime;
		if (_incrementerMode) {
			LifetimeRest += deltaTime;
			if (LifetimeRest >= Lifetime) {
				if (Loop) {
					var lifetimeDelta = LifetimeRest - Lifetime;
					if (LoopCycle) {
						LifetimeRest = lifetimeDelta;
					} else {
						_incrementerMode = !_incrementerMode;
						LifetimeRest = Lifetime - lifetimeDelta;
					}
					Lifetime01 = LifetimeRest / Lifetime;
				} else {
					LifetimeRest = Lifetime;
					Lifetime01 = 1f;
				}
			} else {
				Lifetime01 = LifetimeRest / Lifetime;
			}
		} else {
			LifetimeRest -= deltaTime;
			if (LifetimeRest <= 0f) {
				if (Loop) {
					var lifetimeDelta = -LifetimeRest;
					if (LoopCycle) {
						LifetimeRest = Lifetime - lifetimeDelta;
					} else {
						_incrementerMode = !_incrementerMode;
						LifetimeRest = lifetimeDelta;
					}
					Lifetime01 = LifetimeRest / Lifetime;
				} else {
					LifetimeRest = 0f;
					Lifetime01 = 0f;
				}
			} else {
				Lifetime01 = LifetimeRest / Lifetime;
			}
		}
	}

	private void RefreshAnimations() {
		for (var i = 0; i < _anims.Length; i++) {
			_anims[i].Tick(this);
		}
	}
}