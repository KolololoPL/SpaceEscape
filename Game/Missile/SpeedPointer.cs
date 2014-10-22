using UnityEngine;
using System.Collections;

public class SpeedPointer : MonoBehaviour {
	const float maxScale = 14;
	Vector3 scale;

	void Start() {
		scale = this.transform.localScale;
	}

	void Update () {
		scale.x = maxScale * MissileController.current.Speed;
		this.transform.localScale = scale;
	}
}
