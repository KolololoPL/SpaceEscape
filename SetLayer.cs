using UnityEngine;
using System.Collections;

public class SetLayer : MonoBehaviour {
	public string layerName;
	public int orderNumber;

	void Start () {
		this.renderer.sortingLayerName = layerName;
		this.renderer.sortingOrder = orderNumber;
	}
}
