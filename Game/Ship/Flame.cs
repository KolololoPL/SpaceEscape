using UnityEngine;
using System.Collections;

public class Flame : MonoBehaviour {
	void Update () {
		float scale = 0.5f + EnergyController.current.GetCharge() / 2;
		this.transform.localScale = new Vector3(scale, scale, 1);
	}
}
