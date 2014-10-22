using UnityEngine;
using System.Collections;

public class Bum : MonoBehaviour {
	void AnimationEnded() {
			Destroy(this.gameObject);
	}
}
