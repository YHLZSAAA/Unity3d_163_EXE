using UnityEngine;
using System.Collections;

public class activeheader : MonoBehaviour {

    public GameObject testObj;

    public float m_timer = 2.0f;
    private bool isActive = false;

    private float tempTime;
	// Use this for initialization
	void Start () {
        //GameObject header = GameObject.Find("Main Camera/HeadCtrl");
        testObj.SetActive(isActive);
        isActive = !isActive;
        tempTime = m_timer;
    }
	
	// Update is called once per frame
	void Update () {

        tempTime -= Time.deltaTime;

        if (tempTime <= 0)
        {
            tempTime = m_timer;
            testObj.SetActive(isActive);
            //m_timer = 2.0f;
            isActive = !isActive;

        }
    }
}
