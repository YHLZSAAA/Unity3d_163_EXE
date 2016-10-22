using UnityEngine;
using System.Collections;

public class GyroCtrl : MonoBehaviour {


	Gyroscope g;

	// Update is called once per frame
	void Update () {
	
		g = Input.gyro;
		g.enabled = true;
		Vector3 rot = g.rotationRateUnbiased;
		transform.rotation *= Quaternion.Euler (new Vector3(-rot.x,-rot.y,rot.z));
	}
}
