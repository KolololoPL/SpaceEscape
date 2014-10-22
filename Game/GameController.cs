using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public static GameController current;

	public static int[] enemiesFieldX = new int[2];
	public static int[] enemiesFieldY = new int[2];

	void Awake() {
		EventManager.Reset();
	}

	void Start () {
		GameController.current = this;

		// 0 - max; 1 - min
		GameController.enemiesFieldX[0] = 3;
		GameController.enemiesFieldX[1] = -3;

		GameController.enemiesFieldY[0] = 5;
		GameController.enemiesFieldY[1] = -1;
	}

	void Update () {
	
	}
}
