using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class GraphGenerator : MonoBehaviour {

	[SerializeField]
	private int numberOfNodes = 5; 

	[SerializeField]
	private int numberOfEdges = 10; 

	Dictionary<int, Vector3> nodes = new Dictionary<int, Vector3>();


	[SerializeField]
	GameObject edge;

	[SerializeField]
	GameObject node;

	// Use this for initialization
	void Start () {
		Vector3 startinNodePosition = new Vector3 (-5, 0, 0);
		for (int i = 0; i < numberOfNodes; i++) {
			float y = Random.Range(-1f, 1f);

			float x = Mathf.Sqrt(1 - Mathf.Pow(y,2));
			Vector3 nodePosition = new Vector3 (startinNodePosition.x + x, startinNodePosition.y + y, 0.0f);
			Quaternion nodeRotation = Quaternion.identity;
			Instantiate (node, nodePosition, nodeRotation);
			nodes.Add(i, nodePosition);
			startinNodePosition = nodePosition;
		}
		foreach (KeyValuePair<int, Vector3> node in nodes) {
			Debug.Log("int value " + node.Key + " Vector value" + node.Value);
		}
		for (int i = 0; i < numberOfNodes - 1; i++) {
			Vector3 nodeOne = new Vector3(); 
			nodes.TryGetValue(i, out nodeOne);
			Vector3 nodeTwo = new Vector3(); 
			nodes.TryGetValue(i+1, out nodeTwo);
			float x = (nodeOne.x + nodeTwo.x)/2f;
			float y = (nodeOne.y + nodeTwo.y) /2f;
			float angle = Mathf.Atan2(nodeTwo.y - nodeOne.y, nodeTwo.x - nodeOne.x) * 180 / 3.14f - 90f;
			Vector3 edgePosition = new Vector3 (x, y, 0.0f);
			Quaternion edgeRotation = Quaternion.Euler(0f, 0f, angle);
			Instantiate (edge, edgePosition, edgeRotation);
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
