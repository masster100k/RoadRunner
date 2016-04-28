using UnityEngine;
using System.Collections;

public class OnSelectedEdge : MonoBehaviour {

	public delegate void ClickAction(string edgeName);
	public static event ClickAction onEdgeSelect;

	void OnMouseDown() {
		Debug.Log ("inside mouse down");
		if(onEdgeSelect != null) {
			onEdgeSelect(this.gameObject.name);
		}
	}

}
