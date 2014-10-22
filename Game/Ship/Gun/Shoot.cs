using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	void Start () {
		EventManager.OnShoot += OnShoot;
	}
	
	void OnShoot (ShootEvent e) {
		if (EnergyController.current.CanShoot()) {
			Instantiate(e.GetProjectile(), this.transform.position, Quaternion.identity);
			EnergyController.current.Decrease(EnergyController.current.shootCost);
		}
	}
}
