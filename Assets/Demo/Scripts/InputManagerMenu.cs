//------------------------------------------------------------------------------
// Copyright 2016 Baofeng Mojing Inc. All rights reserved.
//------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MojingSample.CrossPlatformInput;

public class InputManagerMenu : MonoBehaviour
{

    public MenuController menu_controller;
    public GlassesList glass_controller;

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonLongPressed("OK")|| CrossPlatformInputManager.GetButtonLongPressed("A"))
        {
            Debug.Log("OK-----Long GetButtonDown");
        }

        if (CrossPlatformInputManager.GetButtonDown("OK"))
        {
            Debug.Log("OK-----GetButtonDown");
        }
        if (CrossPlatformInputManager.GetButton("OK"))
        {
            Debug.Log("OK-----GetButton");
        }
        else if (CrossPlatformInputManager.GetButtonUp("OK") || CrossPlatformInputManager.GetButtonUp("A"))
        {
            Debug.Log("OK-----GetButtonUp");
            if (menu_controller != null && glass_controller != null)
            {
                if (GlassesList.List_Show)//镜片选择的二级菜单
                    glass_controller.PressCurrent();
                else//场景选择的一级菜单
                    menu_controller.PressCurrent();
            }
        }

        if (CrossPlatformInputManager.GetButtonDown("C"))
        {
            Debug.Log("C-----GetButtonDown");
        }
        if (CrossPlatformInputManager.GetButton("C"))
        {
            Debug.Log("C-----GetButton");
        }
        else if (CrossPlatformInputManager.GetButtonUp("C")|| CrossPlatformInputManager.GetButtonUp("B"))
        {
#if UNITY_IOS
		    MojingSDK.Unity_StopTracker();
#endif
#if UNITY_5_2 || (!UNITY_IOS)
            Application.Quit();
#else
            MojingSDK.Unity_AppExit(0);
#endif
        }

        if (CrossPlatformInputManager.GetButtonDown("MENU"))
        {
            Debug.Log("MENU-----GetButtonDown");
        }
        if (CrossPlatformInputManager.GetButton("MENU"))
        {
            Debug.Log("MENU-----GetButton");
        }
        else if (CrossPlatformInputManager.GetButtonUp("MENU")|| CrossPlatformInputManager.GetButtonUp("X"))
        {
            Debug.Log("MENU-----GetButtonUp");
        }

        if (CrossPlatformInputManager.GetButton("UP"))
        {
            Debug.Log("UP-----GetButton");
        }
        else if (CrossPlatformInputManager.GetButtonUp("UP"))
        {
            if (menu_controller != null && glass_controller != null)
            {
                if ( GlassesList.List_Show)
                    glass_controller.HoverPrev();
                else
                    menu_controller.HoverPrev();
            }
        }

        if (CrossPlatformInputManager.GetButton("DOWN"))
        {
            Debug.Log("DOWN-----GetButton");
        }
        else if (CrossPlatformInputManager.GetButtonUp("DOWN"))
        {
            Debug.Log("DOWN-----GetButtonUp");
            if (menu_controller != null && glass_controller != null)
            {
                if (GlassesList.List_Show)
                    glass_controller.HoverNext();
                else
                    menu_controller.HoverNext();
            }
        }

        if (CrossPlatformInputManager.GetButton("LEFT"))
        {
            Debug.Log("LEFT-----GetButton");
        }
        else if (CrossPlatformInputManager.GetButtonUp("LEFT"))
        {
            if (menu_controller != null && glass_controller != null)
            {
                if (!GlassesList.List_Show)
                    menu_controller.HoverLeft();
            }
        }

        if (CrossPlatformInputManager.GetButton("RIGHT"))
        {
            Debug.Log("RIGHT-----GetButton");
        }
        else if (CrossPlatformInputManager.GetButtonUp("RIGHT"))
        {
            if (menu_controller != null && glass_controller != null)
            {
                if (!GlassesList.List_Show)
                    menu_controller.HoverRight();
            }
        }

        if (CrossPlatformInputManager.GetButton("CENTER"))
        {
        }
        else if (CrossPlatformInputManager.GetButtonUp("CENTER"))
        {
        }
    }
}