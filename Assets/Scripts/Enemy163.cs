using UnityEngine;
using System.Collections;

public class Enemy163 : MonoBehaviour {

	public int speed = 100;
	public string name;
	public int ack;

	public Transform player;

	public float step = 0.5f;
	public int health = 100;
	public GameObject ptc;

	// Use this for initialization
	void Start () {
	
		this.player = Player.PlayerTrans;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.forward =  Vector3.RotateTowards (transform.forward, player.position - transform.position, step* Time.deltaTime, 0);
		//Debug.DrawRay(transform.position, transform.forward, Color.red);
		Move (speed);
	}

	private void Move(float sss)
	{
		transform.Translate (new Vector3 (0, 0, sss) * Time.deltaTime);
	}

	void OnTriggerEnter(Collider collider)
	{
		Player player = collider.GetComponent<Player> ();
		if (player) {
			player.Hurt (10);
		
		}
	}

	public void Hurt(int v)
	{
		if (v > 0) {
			health -= v;
			if (health <= 0) {
				Death ();
			}
		}
	}

	private void Death()
	{
		Instantiate (ptc, transform.position, transform.rotation);
		Destroy (this.gameObject);
	}
}
