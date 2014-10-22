using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour {
	public static ShipController current;

	public GameObject projectile;

	Move shipMove;

	void Start () {
		ShipController.current = this;
		shipMove = this.gameObject.GetComponent<Move>();
	}
	
	void Update () {
		//Keyboard input
		float axis = Input.GetAxisRaw("Horizontal");
		shipMove.MoveShip(axis);

		if (Input.GetButtonDown("Fire")) {
			Event e = new ShootEvent(this.gameObject, projectile);
			EventManager.Call(e);
		}
	}

	public Move GetMove() {
		return shipMove;
	}
}
