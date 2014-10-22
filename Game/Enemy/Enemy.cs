using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject teleport;
	protected void Start() {
		//Teleport efect
		Instantiate(teleport, this.transform.position, Quaternion.identity);

		//Time to first shoot
		timeToShoot = Random.Range(0f, 2f);

		//Set up first position
		MoveTo = this.transform.position;

		//Executed when enemy is on its position
		EventManager.OnEnemyOnPosition += OnEnemyOnPosition;

	}

	protected Vector3 moveTo;
	void Update () {
		//Move object in direction to its new position
		Vector3 move = moveTo - this.transform.position;
		if (move.magnitude > Speed)
			move = move.normalized * Speed;
		this.transform.position += move;

		//Move roles execution
		Move();

		//Random shoot
		Shoot();

		//Subscribe EnemyOnPositionEvent
		Subscribe();
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.CompareTag("Projectile"))
			Destroy(col.gameObject);
		Destroy();
	}

	void OnDestroy() {
		EnemyDestroyEvent e = new EnemyDestroyEvent(this.gameObject, this);
		EventManager.Call(e);

		EventManager.OnEnemyOnPosition -= OnEnemyOnPosition;
	}

	bool isMoving = true;
	void Subscribe() {
		if (this.MoveTo.Equals(this.transform.position) && isMoving) {
			Event e = new EnemyOnPositionEvent(this.gameObject, GetEnemyType());
			EventManager.Call(e);
			
			isMoving = false;
		} else if (!this.MoveTo.Equals(this.transform.position) && !isMoving) {
			isMoving = true;
		}
	}

	public float speed;
	float Speed {
		get {
			float relSpeed = speed * Time.deltaTime;
			return relSpeed;
		}
	}

	public GameObject laser;

	float timeToShoot = 3, time = 0;
	const float startTimeToShoot = 0.5f, rangeTimeToShoot = 1.5f;
	virtual protected void Shoot() {
		if (timeToShoot - time <= 0) {
			Instantiate(laser, this.transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
			timeToShoot = startTimeToShoot + Random.Range(0f, rangeTimeToShoot);
			time = 0;
		} else 
			time += Time.deltaTime;
	}

	virtual protected void Move() {
	}

	virtual protected void OnEnemyOnPosition(EnemyOnPositionEvent e) {
	}

	virtual public Enemies GetEnemyType() {
		return Enemies.Generic;
	}

	public GameObject bum;
	public void Destroy() {
		Instantiate(bum, this.transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}

	public void Revoke() {
		Instantiate(teleport, this.transform.position, Quaternion.identity);
		Destroy(this.gameObject);
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
