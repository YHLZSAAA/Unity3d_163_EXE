using UnityEngine;
using System.Collections;
using System.Threading;

[AddComponentMenu("MyGame/Enemy")]
public class Enemy : HandleEffort {

	public float m_life = 10;

	public Transform m_rocket;

	//protected Transform m_transform;

	public float m_fireTimer = 1;

	protected Transform m_player;

	//explosion
	//public Transform m_explosionFX;

	void Awake()
	{
		GameObject obj = GameObject.FindGameObjectWithTag ("Player");

		if (obj != null) {
			m_player = obj.transform;
		}
	}
		
	// Use this for initialization
//	void Start () {
//		InitializeObj ();
//		//m_transform = this.transform;
//	}

	// Update is called once per frame
	void Update () {
		m_fireTimer -= Time.deltaTime;

		if (m_fireTimer <= 0) {
			m_fireTimer = 2;

			if (null != m_player) {
				Vector3 relativePos = m_player.position - m_transform.position ;

				Instantiate (m_rocket, m_transform.position, Quaternion.LookRotation (relativePos));
			}
		}
	}

	/// <summary>
	/// Add collide
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log ("collider in enemy : " + other.tag);

		if (other.tag.CompareTo("PlayerRocket") == 0) {
			//Debug.Log ("Start collider for rocket");


			Rocket rocket = other.GetComponent<Rocket> ();
			if (null != rocket) {

				m_life -= rocket.m_power;
				Debug.LogFormat ("the life of enemy is {0}", m_life);
				if (m_life <= 0) {

					//GameManager.Instance.AddSource (m_point);
					DestorySelf();
				}
			}
		}
		else if (other.tag.CompareTo("Player") ==0) {
			//Debug.Log ("start collider for player");
			m_life = 0;
			DestorySelf();
		}
	}


	void DestorySelf()
	{

		//for explosion
		Instantiate (m_explosionFX, m_transform.position, Quaternion.identity);
		m_audio.PlayOneShot(m_explosionAudio);
		//GetComponent<ParticleSystem>().Emit(1); 
		//GetComponent<ParticleSystem>().Play();
		Destroy (this.gameObject);
	}
}
