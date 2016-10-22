using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Transform track;
	public float speed;
	public float lifeTime = 2;

	private Transform m_tran;
	public LayerMask lm;

	public int ack = 200;
	// Use this for initialization
	void Start () {
	
		this.m_tran = this.transform;
		Destroy (this.gameObject,this.lifeTime);
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (Vector3.forward * speed * Time.deltaTime);

		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit, speed * Time.deltaTime,lm)) {
			Debug.Log (hit.transform.name + " 被击中了！！");
			hit.transform.GetComponent<Enemy163> ().Hurt (ack);
		}

//		transform.Translate
		this.m_tran.Translate(Vector3.forward * speed * Time.deltaTime);
		if (track && track.localScale.z < 50) {
			this.track.localScale += Vector3.forward * speed * Time.deltaTime;
		}


	}
}
