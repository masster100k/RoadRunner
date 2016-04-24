using UnityEngine;
using System.Collections;

public class OnClickRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetMouseButtonDown (0)) {
//			Application.LoadLevel (Application.loadedLevel);
//		}
	
	}

	public void restart(){
		Debug.Log ("reset");
		// this object was clicked - do something
		Application.LoadLevel (Application.loadedLevel);
	}   
}
