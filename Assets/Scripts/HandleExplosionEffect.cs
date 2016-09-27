using UnityEngine;
using System.Collections;

[AddComponentMenu("MyGame/HandleEffort")]
/// <summary>
/// Handle for sound, blast etc.
/// </summary>
public class HandleExplosionEffect : MonoBehaviour {

	#region Public obj
	//public AudioClip m_explosionAudio;
	public Transform m_explosionFX;
	#endregion

	protected AudioSource m_audio ;
	protected Transform m_transform ;
	//protected AudioSource[] m_audioList ;

	protected virtual void Start () {
		print ("handleeffort start");
		Debug.Log("I am alive!");
		this.m_transform = this.transform;
		this.m_audio = this.GetComponent<AudioSource>();
	}
//
//	void Awake()
//	{
//		print ("handleeffort Awake");
//	}

	protected void InitializeObj()
	{
		this.m_transform = this.transform;
		this.m_audio = this.GetComponent<AudioSource>();
	}
}
