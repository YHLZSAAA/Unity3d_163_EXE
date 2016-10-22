using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject enemy;
	public float rateTime = 1.0f;
	public GameObject player;


	private float mytime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		mytime += Time.deltaTime;
		if (mytime > rateTime && player.activeSelf) {
			//Debug.Log ("from level manager ");
			Vector3 r = Random.onUnitSphere * 50;
			Instantiate (enemy, player.transform.position + r, enemy.transform.rotation);
			mytime -= rateTime;
		}
	}

	void OnGUI()
	{
		//print ("ON GUI");
		//GUI.Label (new Rect(5,5,150,30),"Player Blood ："+ 555);
	}
}
