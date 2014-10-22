using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float speed = 9;

	void Update () {
		this.transform.position += this.transform.up * Speed;
	}

	void OnCollisionExit2D (Collision2D col) {
		Destroy(this.gameObject);
	}

	float Speed {
		get {
			float relSpeed = speed * Time.deltaTime;
			return relSpeed;
		}
	}
}
