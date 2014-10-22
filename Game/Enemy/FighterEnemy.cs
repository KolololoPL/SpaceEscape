using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FighterEnemy : Enemy {
	List<Vector3> movesList;
	int moveState = 0, fightersOnPosition = 0;

	void Turn() {
		moveState++;
		fightersOnPosition = 0;

		if (moveState >= movesList.Count)
			moveState = 0;

		this.MoveTo = movesList[moveState];
	}

	override protected void Move() {
		if (fightersOnPosition >= SpawnManager.current.GetEnemiesCount(Enemies.Fighter))
			Turn();
	}

	override protected void OnEnemyOnPosition(EnemyOnPositionEvent e) {
		if (e.GetEnemyType() == Enemies.Fighter)
			fightersOnPosition++;
	}

	override public Enemies GetEnemyType() {
		return Enemies.Fighter;
	}

	public void SetMovesList(List<Vector3> movesList) {
		this.movesList = movesList;
	}
}