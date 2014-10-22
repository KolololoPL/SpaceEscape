using UnityEngine;
using System.Collections;

public class PointsController : MonoBehaviour {
	public static PointsController current;

	TextMesh textMesh;
	float points;

	void Start() {
		PointsController.current = this;
		textMesh = this.GetComponent<TextMesh>();
		EventManager.OnDead += OnDead;
	}

	void Update() {
		Add();
		Show();
	}

	void Add() {
		points += EnergyController.current.GetCharge() * Time.deltaTime * 10;
	}

	void Show() {
		textMesh.text = ((int) points).ToString();
	}

	void OnDead(DeadEvent e) {
		this.enabled = false;
	}

	public float GetPoints() {
		return points;
	}
}
