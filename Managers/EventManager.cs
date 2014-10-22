using UnityEngine;
using System.Collections;

public enum Events {Generic = 0, ShootEvent = 1 << 0, DeadEvent = 1 << 1, EnemyDestroyEvent = 1 << 2, EnemyOnPositionEvent = 1 << 3}

public static class EventManager {
	public delegate void Shoot(ShootEvent e);
	public static event Shoot OnShoot;

	public delegate void Dead (DeadEvent e);
	public static event Dead OnDead;

	public delegate void EnemyDestroy (EnemyDestroyEvent e);
	public static event EnemyDestroy OnEnemyDestroy;

	public delegate void EnemyOnPosition (EnemyOnPositionEvent e);
	public static event EnemyOnPosition OnEnemyOnPosition;

	public static void Call(Event e) {
		if (e.GetEventType() == Events.ShootEvent) {
			if (OnShoot != null)
				OnShoot((ShootEvent) e);
		} else if (e.GetEventType() == Events.DeadEvent) {
			if (OnDead != null)
				OnDead((DeadEvent) e);
		} else if (e.GetEventType() == Events.EnemyDestroyEvent) {
			if (OnEnemyDestroy != null)
				OnEnemyDestroy((EnemyDestroyEvent) e);
		} else if (e.GetEventType() == Events.EnemyOnPositionEvent) {
			if (OnEnemyOnPosition != null)
				OnEnemyOnPosition((EnemyOnPositionEvent) e);
		}
	}

	public static void Reset() {
		OnShoot = null;
		OnDead = null;
		OnEnemyDestroy = null;
		OnEnemyOnPosition = null;

		//Used in: GameController;
	}
}

public class ShootEvent : Event{
	GameObject projectile;

	public ShootEvent(GameObject caller, GameObject projectile) : base(caller) {
		this.projectile = projectile;
	}

	public GameObject GetProjectile() {
		return projectile;
	}

	public override Events GetEventType() {
		return Events.ShootEvent;
	}
}

public class DeadEvent : Event {
	public DeadEvent(GameObject caller) : base(caller) {
	}

	public override Events GetEventType() {
		return Events.DeadEvent;
	}
}

public class EnemyDestroyEvent : Event {
	Enemy enemyClass;

	public EnemyDestroyEvent (GameObject caller, Enemy enemyClass) : base (caller) {
		this.enemyClass = enemyClass;
	}

	public Enemy GetEnemyClass() {
		return enemyClass;
	}

	public override Events GetEventType() {
		return Events.EnemyDestroyEvent;
	}
}

public class EnemyOnPositionEvent : Event {
	Enemies type;

	public EnemyOnPositionEvent(GameObject caller, Enemies type) : base(caller) {
		this.type = type;
	}

	public Enemies GetEnemyType() {
		return type;
	}

	public override Events GetEventType() {
		return Events.EnemyOnPositionEvent;
	}
}

public class Event {
	GameObject caller;

	public Event(GameObject caller) {
		this.caller = caller;
	}

	public GameObject GetCaller() {
		return this.caller;
	}

	public virtual Events GetEventType() {
		return Events.Generic;
	}
}