//------------------------------------------------------------------------------
// Copyright 2016 Baofeng Mojing Inc. All rights reserved.
//------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MyuGUICrossNodeBase : MonoBehaviour
{
    [HideInInspector]
    public float HoverTime = 1f;
    public float ClickTime = 1.5f;
    public bool Clickable = true;
    public bool Grabable = true;
    public bool ShowWaiting = true;
    public Text text;
    private string ButtonName;
    public virtual void SetSelect(bool bFlag)
    {
        ButtonName = name;
        if (bFlag)
        {
            text.text = ButtonName + " Cross Enter";
        }
        else
        {
            text.text = ButtonName + " Cross Exit";
        }
    }

    //需要研究Onclick是固定写法吗，应该是和button组件关联的
    public virtual void OnClick()
    {
        Debug.Log(name + " click!!!");
        ButtonName = name;
        //text.text = ButtonName + " OnClick";
        if (ButtonName == "ImageForEnd")
        {
            //Application.LoadLevel("HeadControllerDemo");
            //SceneManager.LoadScene (1);
            Application.Quit();

        }
        else if (ButtonName == "ImageForStart")
        {
            StartCoroutine(WaitAndPrint());
        }


    }

    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(0);
    }
}
