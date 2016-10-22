using UnityEngine;
using System.Collections;

public class testactive : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Debug.Log("start");
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Update");
    }

    void Awake()
    {
        Debug.Log("Awake");

    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
    }
}
