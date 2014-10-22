using UnityEngine;
using System.Collections;

public class ShadowEnemy : Enemy {
	//float startY, deltaY = 1f;

	const float gapSize = 0.3f;

	new void Start () {
		base.Start();

		this.MoveTo = this.transform.position;
		//startY = this.MoveTo.y;
	}

	override protected void Move() {
		/*//High change
		if (this.transform.position.y == startY)
			this.MoveTo += Vector3.up * deltaY;
		else if (this.transform.position.y == startY + deltaY)
			this.MoveTo -= Vector3.up * deltaY;*/

		/*//Left/Right move
		Ray2D leftRay = new Ray2D(this.transform.position - Vector3.down * 0.2f, Vector3.left);
		Ray2D rightRay = new Ray2D(this.transform.position - Vector3.down * 0.2f, Vector3.right);

		RaycastHit2D left = Physics2D.Raycast(leftRay.GetPoint(this.renderer.bounds.size.x / 2 + 0.01f), leftRay.direction, gapSize);
		RaycastHit2D right = Physics2D.Raycast(rightRay.GetPoint(this.renderer.bounds.size.x / 2 + 0.01f), rightRay.direction, gapSize);

		if (left.collider != null && right.collider == null) {
			this.MoveTo += Vector3.right * 6;
		} else if (right.collider != null && left.collider == null) {
			this.MoveTo += Vector3.left * 6;
		} else if (left.collider != null && right.collider != null) {
			this.MoveTo = new Vector3(this.transform.position.x, this.MoveTo.y, this.MoveTo.z);
		}*/

		this.MoveTo = new Vector3(Random.Range(GameController.enemiesFieldX[1], GameController.enemiesFieldX[0]), this.MoveTo.y, this.MoveTo.z);
	}
}
