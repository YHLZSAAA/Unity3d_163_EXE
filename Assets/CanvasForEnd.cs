using UnityEngine;
using System.Collections;

public class CanvasForEnd : MonoBehaviour {

	public Transform target;
	// Use this for initialization
	void Start () {
	
	}

	void OnEnable()
	{
		Vector3 u = target.position;
		this.transform.position = new Vector3 (u.x, u.y, u.z + 2);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
