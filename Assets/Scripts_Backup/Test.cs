using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	public int zzz;

	// Use this for initialization
	void Start () {
		Debug.logger.logEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Cube update");
		zzz++;
		transform.position = new Vector3 (0,0,zzz)* Time.deltaTime;
		//transform.Translate(new Vector3 (0,0,zzz)* Time.deltaTime);
	}

	void LastUpdate()
	{
		Debug.Log ("cube last update");
	}
}
