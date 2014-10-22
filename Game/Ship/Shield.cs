using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	public GameObject sample;

	void Start() {
		EventManager.OnDead += OnDead;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.CompareTag("Projectile")) {
			EnergyController.current.Decrease(EnergyController.current.shootCost);
			Destroy(col.gameObject);
		} else if (col.gameObject.CompareTag("Asteroid"))
			EnergyController.current.Decrease(1);
	}

	void OnDead(DeadEvent e) {
		if (sample != null)
			Instantiate(sample, this.transform.position, Quaternion.identity);
		this.gameObject.SetActive(false);
	}
}
