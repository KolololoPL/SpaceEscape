using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public float speed;
	
	Vector3 moveTo;
	float yPosition;

	void Start () {
		moveTo = this.transform.position;
		yPosition = this.transform.position.y - 0.5f;
	}

	void Update () {
		MoveLoop();
		HeighEnergy();
	}

	void MoveLoop() {
		Vector3 move = moveTo - this.transform.position;
		if (move.magnitude > Speed)
			move = move.normalized * Speed;
		this.transform.position += move;
	}

	void HeighEnergy() {
		moveTo.y = yPosition + EnergyController.current.GetCharge() / 2;
	}

	float Speed {
		get {
			float relSpeed = speed * Time.deltaTime;
			return relSpeed;
		}
	}

	public void MoveShip (float axis) {
		Vector3 move = new Vector3(axis * Speed, 0, 0);
		moveTo += move;
	}

	public Vector3 MoveTo {
		get {
			return moveTo;
		}

		set {
			moveTo = value;
		}
	}
}
