using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/Player")]
public class Copperhead : HandleExplosionEffect {

	//protected Transform m_transform;

	#region Publish Object
	public float m_speed = 10;
	public float rotspeed = 10;
	public float m_life = 3;
	public Transform enemyTrans;

	public AudioClip m_shootClip;
	//public Transform m_explosionFX;

	/// <summary>
	///Rocket object
	/// </summary>
	public Transform m_rocket;

	#endregion

	//protected AudioSource m_audio;

	#region Contral Camera
	Transform m_camTransform;
	Vector3 m_camRot;

	#endregion

	float m_rocketRate = 0;

	// Use this for initialization
	protected override void Start () {

		base.Start();

		//Get the main camera
		m_camTransform = Camera.main.transform;
		//Control to show log or not
		Debug.logger.logEnabled = true;

	}

	void FixedUpdate()
	{
		print ("Hello FixedUpdate");
	}
	// Update is called once per frame
	void Update () {
		Debug.Log ("Hello me ： " );


		this.m_transform.Translate(new Vector3(0,0,0.5f)*Time.deltaTime);
		this.ControlFlyBehaviour ();
		this.ControlCamrea ();
		//this.m_transform.Rotate (new Vector3 (0,rotspeed ,0)* Time.deltaTime);

		//Contral the interval time of rocket, fire every o.1 second

		m_rocketRate -= Time.deltaTime;

		if (m_rocketRate <= 0) {
			m_rocketRate = 0.1f;
			//fire with space or mouse left
			if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
				//print ("rocket");
				Instantiate (m_rocket,m_transform.position,m_transform.rotation);

				//shoot music
				m_audio.PlayOneShot(m_shootClip);


			}
		}

		if (null != this.enemyTrans) {
			this.enemyTrans.LookAt (this.m_transform);

		}
	}


	void OnTriggerEnter(Collider other)
	{

		if (other.tag.CompareTo("PlayerRocket") != 0) {
			m_life -= 1;
			//print ("rocket hit player");
			if (m_life <= 0) 
			{
				
				//for explosion
				Instantiate (m_explosionFX, m_transform.position, Quaternion.identity);
				//m_audio.PlayOneShot(m_explosionAudio);

				Destroy (this.gameObject);
			}
		}
	}

	#region MyFunction

	void ControlFlyBehaviour()
	{
		float movev = 0;//for vertical move
		float moveh = 0;//for horizontal move

		//Up move
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			movev += m_speed * Time.deltaTime;
		}//Down move
		else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
			movev -= m_speed * Time.deltaTime;
		}//left move
		else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			moveh -= m_speed * Time.deltaTime;
		}//right move
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			moveh += m_speed * Time.deltaTime;
		}

		this.m_transform.Translate(new Vector3(moveh,movev,0));

	}

	void ControlCamrea()
	{
		Vector3 pos =  m_camTransform.position;
		pos.z = m_transform.position.z -5;
		m_camTransform.position = pos;
	}
	#endregion



}
