using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {
	public static MissileController current;

	const float start = -1.75f, end = 1.75f, velocity = 0.03f;
	float speed = 0.6f;

	void Start() {
		MissileController.current = this;
	}

	void Update () {
		Move();
	}

	//Move ico
	void Move() {
		if (this.transform.position.x >= end) {
			Event e = new DeadEvent(this.gameObject);
			EventManager.Call(e);
			
			this.enabled = false;
		} else if (this.transform.position.x >= start) {
			float moveX = (speed - EnergyController.current.GetCharge()) * velocity;
			if (this.transform.position.x + moveX > end)
				moveX = end - this.transform.position.x;
			else if (this.transform.position.x + moveX < start)
				moveX = start - this.transform.position.x;
			
			Vector3 newPosition = this.transform.position;
			newPosition.x += moveX;
			
			this.transform.position = newPosition;
		}
	}

	public float Speed {
		get {
			return speed;
		}

		set {
			if (value > 1)
				speed = 1;
			else if (value < 0)
				speed = 0;
			else
				speed = value;
		}
	}
}
