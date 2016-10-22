using UnityEngine;
using System.Collections;

public class CamRoot : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	
	}

	void Update () {
		//Debug.Log ("CamRoot update： ");
	}
	// LateUpdate is called after update
	void LateUpdate () {
	
		//Debug.Log ("CamRoot Late update： ");
		if (target) {
			this.transform.position = target.position;
		}
	}
}
