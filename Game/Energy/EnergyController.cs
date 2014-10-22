using UnityEngine;
using System.Collections;

public class EnergyController : MonoBehaviour {
	public static EnergyController current;

	public float rechargeSpeed = 0.01f;
	public float shootCost = 0.35f;

	const float maxScale = 14;

	Vector3 scale;
	float charge = 1;

	void Start () {
		EnergyController.current = this;
		scale = this.transform.localScale;
		EventManager.OnDead += OnDead;
	}

	void Update () {
		Recharge();
		Draw();
	}

	void Recharge() {
		if (charge < 1) {
			if (charge + rechargeSpeed > 1)
				charge = 1;
			else
				charge += rechargeSpeed;
		} else if (charge > 1) {
			if (charge - rechargeSpeed * 2 < 1)
				charge = 1;
			else
				charge -= rechargeSpeed * 2;
		}
	}

	void Draw() {
		if (charge > 1)
			scale.x = maxScale;
		else
			scale.x = maxScale * charge;

		this.transform.localScale = scale;
	}

	void OnDead(DeadEvent e) {
		charge = 0;
		Draw();
		this.enabled = false;
	}

	public float GetCharge() {
		return charge;
	}

	public void Decrease(float value) {
		if (charge - value < 0)
			charge = 0;
		else
			charge -= value;
	}

	public bool CanShoot() {
		if (charge > shootCost)
			return true;
		return false;
	}
}
