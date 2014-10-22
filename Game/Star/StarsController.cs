using UnityEngine;
using System.Collections;

public class StarsController : MonoBehaviour {
	public ParticleSystem forground, background;

	const float forSpeed = 1, backSpeed = 0.5f;

	void Update () {
		float speed;

		speed = forSpeed + EnergyController.current.GetCharge();
		forground.startSpeed = speed;

		speed = backSpeed + EnergyController.current.GetCharge() / 2;
		background.startSpeed = speed;
	}
}
