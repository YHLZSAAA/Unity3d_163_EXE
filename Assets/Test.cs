using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	public int zzz;

	// Use this for initialization
	void Start () {
		Debug.logger.logEnabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		zzz++;
		transform.position = new Vector3 (0,0,zzz)* Time.deltaTime;
		//transform.Translate(new Vector3 (0,0,zzz)* Time.deltaTime);
	}
}
