using UnityEngine;
using System.Collections;

public class SoldierEnemy : Enemy {
	void Turn() {
		float x, y;
		if (this.transform.position.x == GameController.enemiesFieldX[1]) {
			y = GameController.enemiesFieldY[0];
			x = Random.Range(GameController.enemiesFieldX[1] + 0.5f, GameController.enemiesFieldX[0] - 0.5f);
		} else if (this.transform.position.y == GameController.enemiesFieldY[0]) {
			x = GameController.enemiesFieldX[0];
			y = Random.Range(GameController.enemiesFieldY[1] + 0.5f, GameController.enemiesFieldY[0] - 0.5f);
		} else if (this.transform.position.x == GameController.enemiesFieldX[0]) {
			y = GameController.enemiesFieldY[1];
			x = Random.Range(GameController.enemiesFieldX[1] + 0.5f, GameController.enemiesFieldX[0] - 0.5f);
		} else {
			x = GameController.enemiesFieldX[1];
			y = Random.Range(GameController.enemiesFieldY[1] + 0.5f, GameController.enemiesFieldY[0] - 0.5f);
		}

		Vector3 move = new Vector3(x, y, 0);
		this.MoveTo = move;
	}

	override protected void OnEnemyOnPosition (EnemyOnPositionEvent e) {
		if (e.GetCaller().Equals(this.gameObject)) 
			Turn();
	}

	override public Enemies GetEnemyType() {
		return Enemies.Soldier;
	}
}
