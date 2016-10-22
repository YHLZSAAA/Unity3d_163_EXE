//------------------------------------------------------------------------------
// Copyright 2016 Baofeng Mojing Inc. All rights reserved.
//------------------------------------------------------------------------------

using UnityEngine;
using MojingSample.CrossPlatformInput;
using UnityEngine.UI;

public class ChangeGlassesDemo : MonoBehaviour {
    public Text text;
    private Mojing sdk;
    private MojingVRHead vrhead;
    MojingVRHead.GlassesTypes newGlassesName;

    int count = 0;
	// Use this for initialization
	void Start () {
        sdk = Mojing.SDK;
        vrhead = GameObject.Find("MojingMain/MojingVrHead").GetComponent<MojingVRHead>();
	}
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("OK")||CrossPlatformInputManager.GetButtonDown("Submit") || CrossPlatformInputManager.GetButtonDown("A") || Input.GetMouseButtonDown(0))
        {
            if(count == 0)
                newGlassesName = MojingVRHead.GlassesTypes.MojingII;
            else if (count == 1)
                newGlassesName = MojingVRHead.GlassesTypes.MojingIII;
            else if (count == 2)
                newGlassesName = MojingVRHead.GlassesTypes.MojingIIIPlusB;
            else if (count == 3)
                newGlassesName = MojingVRHead.GlassesTypes.MojingIIIPlusA;
            else if (count == 4)
                newGlassesName = MojingVRHead.GlassesTypes.MojingIV;
            else if (count == 5)
                newGlassesName = MojingVRHead.GlassesTypes.MojingMovie;
            else if (count == 6)
                newGlassesName = MojingVRHead.GlassesTypes.MojingYoungD;
            else if (count == 7)
                newGlassesName = MojingVRHead.GlassesTypes.MojingV;
            else if (count == 8)
                newGlassesName = MojingVRHead.GlassesTypes.MojingRIO;
            vrhead.GetsdkGlassKey(newGlassesName);
            text.text = newGlassesName + "\n" + sdk.GlassesKey;
            count++;
            if (count > 8)
                count = 0;
        }
    }
}
