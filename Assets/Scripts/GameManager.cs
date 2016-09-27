using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[AddComponentMenu("MyGame/GameManager")]
public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public int m_score = 0;

	public static int m_hiscore = 0;

	protected Copperhead m_player;

	protected Enemy m_enemy;

	public AudioClip m_musicClip;

	protected AudioSource m_audio;

	//GameObject[] enemyRocketObjList;

	//bool isSuccess = false;

	void Awake()
	{
		Instance = this;

	}


	// Use this for initialization
	void Start () {

		m_audio = GetComponent<AudioSource>();

		GameObject playObj = GameObject.FindGameObjectWithTag ("Player");

		if (null != playObj) {
			m_player = playObj.GetComponent<Copperhead> ();
		}

		GameObject enemyObj = GameObject.FindGameObjectWithTag ("Enemy");
		if (null != enemyObj) {
			m_enemy = enemyObj.GetComponent<Enemy> ();
		}
	}

	// Update is called once per frame
	void Update () {

		if (!m_audio.isPlaying) {
			m_audio.clip = m_musicClip;
			//m_audio.Play ();
		}

		if (Time.timeScale > 0 && Input.GetKeyDown(KeyCode.Escape)) {
			Time.timeScale = 0;
		}

		//get the enemyrocket list
		//enemyRocketObjList = GameObject.FindGameObjectsWithTag ("EnemyRocket");

	}

	void OnGUI()
	{
		print ("ON GUI");
		if (Time.timeScale == 0) {
			if (GUI.Button(new Rect(Screen.width * 0.5f-50,Screen.height * 0.4f,100,30),"Continue")) {
				Time.timeScale = 1;
			}

			if (GUI.Button(new Rect(Screen.width * 0.5f-50,Screen.height * 0.6f,100,30),"Quit")) {
				Application.Quit ();
			}
		}

		int playerLife = 0;
		int enemyLife = 0;
		if (m_player != null) {
			playerLife = (int)m_player.m_life;
		} else 
		{
			ShowResult ("Failed");
		}

		if (m_enemy != null) {
			enemyLife = (int)m_enemy.m_life;
		} else {

			ShowResult ("Success");

		}

		GUI.skin.label.fontSize = 15;

		GUI.Label (new Rect(5,5,150,30),"Player Blood ："+ playerLife);

		GUI.Label (new Rect(5,40,150,30),"Enemy Blood ："+ enemyLife);

	}

	void ShowResult(string result)
	{
		GUI.skin.label.fontSize = 50;

		GUI.skin.label.alignment = TextAnchor.LowerCenter;
		GUI.Label (new Rect(0,Screen.height * 0.2f,Screen.width,60),result);

		GUI.skin.label.fontSize = 20;

		if (GUI.Button(new Rect(Screen.width * 0.5f - 50,Screen.height * 0.5f,100,30),"Try again")) {
			//Application.LoadLevel (Application.loadedLevelName);

			SceneManager.LoadScene ("myhomework");
		}
	}
}
