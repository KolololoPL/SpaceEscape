using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {
	void Update () {
		if (Mathf.Abs(this.transform.position.x) < 3)
			return;

		Vector3 position;
		if (this.transform.position.x < 0)
			position = this.transform.position + Vector3.right * 6;
		else 
			position = this.transform.position + Vector3.right * -6;

		ShipController.current.GetMove().MoveTo = position;
		this.transform.position = position;
	}
}
