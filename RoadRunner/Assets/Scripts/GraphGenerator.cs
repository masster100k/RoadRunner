using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class GraphGenerator : MonoBehaviour {

	[SerializeField]
	private int numberOfNodes = 5; 

	[SerializeField]
	private int numberOfEdges = 10; 

	Dictionary<int, Vector3> nodes = new Dictionary<int, Vector3>();
	Dictionary<string, GameObject> edges = new Dictionary<string, GameObject>();

	[SerializeField]
	GameObject edgePlain;

	[SerializeField]
	GameObject edgeSelected;

	[SerializeField]
	GameObject edgeCorrect;


	[SerializeField]
	GameObject node;

	// Use this for initialization
	void Start () {
		OnSelectedEdge.onEdgeSelect += updateEdge;
		createRandomGraph ();


	}

	void createBoxGraph() {

		Vector3 nodePositionUL = new Vector3 (0f, 0f, 0.0f);
		Quaternion nodeRotationUL = Quaternion.identity;
		Instantiate (node, nodePositionUL, nodeRotationUL);
		nodes.Add (0, nodePositionUL);

		Vector3 nodePositionUR = new Vector3 (0f, -1f, 0.0f);
		Quaternion nodeRotationUR = Quaternion.identity;
		Instantiate (node, nodePositionUR, nodeRotationUR);
		nodes.Add (1, nodePositionUR);

		Vector3 nodePositionLL = new Vector3 (-1f, 0f, 0.0f);
		Quaternion nodeRotationLL = Quaternion.identity;
		Instantiate (node, nodePositionLL, nodeRotationLL);
		nodes.Add (2, nodePositionLL);

		Vector3 nodePositionLR = new Vector3 (-1f, -1f, 0.0f);
		Quaternion nodeRotationLR = Quaternion.identity;
		Instantiate (node, nodePositionLR, nodeRotationLR);
		nodes.Add (3, nodePositionLR);

		drawEdges (nodes);

			}

	void createRandomGraph ()
	{
		Vector3 startinNodePosition = new Vector3 (-5, 0, 0);
		for (int i = 0; i < numberOfNodes; i++) {
			float y = Random.Range (-1f, 1f);
			float x = Mathf.Sqrt (1 - Mathf.Pow (y, 2));
			Vector3 nodePosition = new Vector3 (startinNodePosition.x + x, startinNodePosition.y + y, 0.0f);
			Quaternion nodeRotation = Quaternion.identity;
			Instantiate (node, nodePosition, nodeRotation);
			nodes.Add (i, nodePosition);
			startinNodePosition = nodePosition;
		}
		drawEdges (nodes);
	}

	void drawEdges (Dictionary<int, Vector3> nodes)
	{

		for (int i = 0; i < nodes.Count - 1; i++) {
			Vector3 nodeOne = new Vector3 ();
			nodes.TryGetValue (i, out nodeOne);
			Vector3 nodeTwo = new Vector3 ();
			nodes.TryGetValue (i + 1, out nodeTwo);
			float x = (nodeOne.x + nodeTwo.x) / 2f;
			float y = (nodeOne.y + nodeTwo.y) / 2f;
			float angle = Mathf.Atan2 (nodeTwo.y - nodeOne.y, nodeTwo.x - nodeOne.x) * 180 / 3.14f - 90f;
			Vector3 edgePosition = new Vector3 (x, y, 0.0f);
			Quaternion edgeRotation = Quaternion.Euler (0f, 0f, angle);
			GameObject edgeToAdd = (GameObject)Instantiate (edgePlain, edgePosition, edgeRotation);
			edgeToAdd.name = "" + i;
			edges.Add (edgeToAdd.name, edgeToAdd);
		}
	}

	public void updateEdge(string name) {
		Debug.Log ("edge name " + name);
		GameObject edgeFetched = edges [name];
		Destroy (edgeFetched);
		edges.Remove (name);

		if (name.Contains ("s")) {
			GameObject edgeSelectedToAdd = (GameObject)Instantiate (edgePlain, edgeFetched.transform.position, edgeFetched.transform.rotation);
			name = name.Substring(0,1);
			edgeSelectedToAdd.name = name;
			edges.Add (name, edgeSelectedToAdd);
		} else {
			GameObject edgeSelectedToAdd = (GameObject)Instantiate (edgeSelected, edgeFetched.transform.position, edgeFetched.transform.rotation);
			name = name + "s";
			edgeSelectedToAdd.name = name;
			edges.Add (name, edgeSelectedToAdd);
		}



	}

	void OnEnable() {
		
		OnSelectedEdge.onEdgeSelect += updateEdge;
	}

	void OnDisable() {
		
		OnSelectedEdge.onEdgeSelect -= updateEdge;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
