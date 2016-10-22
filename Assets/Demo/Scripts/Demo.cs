//------------------------------------------------------------------------------
// Copyright 2016 Baofeng Mojing Inc. All rights reserved.
// 
// Author: Xu Xiang
//------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Demo : MonoBehaviour {

    public Text TimeWarpText;
    public GameObject Tips;

    public void ShowScene360Photo()
    {
        Application.LoadLevel("360PhotoDemo");
        MojingSDK.SetCenterLine(10, new Color(1.0f, 0.0f, 0.0f, 1.0f));
    }

    public void ShowStereoImage()
    {
        Application.LoadLevel("StereoImage");
        MojingSDK.SetCenterLine(4, new Color(0.0f, 0.0f, 1.0f, 1.0f));
    }

	public void Mojing1stC()
	{
        Application.LoadLevel("Mojing1stC");
        MojingSDK.SetCenterLine(6, new Color(0.0f, 1.0f, 0.0f, 0.5f));
    }
	
	public void Mojing3rdC()
	{
        Application.LoadLevel("Mojing3rdC");
	}
    public void ShowMenu()
    {
        Application.LoadLevel("Menu");

    }

    public void ReportDemo()
    {
        Application.LoadLevel("MojingReport");
    }
    public void LoginPayDemo()
    {
#if UNITY_IOS || UNITY_EDITOR
        if(Tips!=null)
            Tips.SetActive(true);
        return;
#endif
        Application.LoadLevel("MojingLoginPay");
    }

    public void EnableTimeWarp()
    {
        if (!Mojing.SDK.VRModeEnabled)
            return;

        ConfigItem.TW_STATE = !ConfigItem.TW_STATE;
        Debug.Log("TimeWarp " + ConfigItem.TW_STATE.ToString());

        MojingSDK.Unity_SetEnableTimeWarp(ConfigItem.TW_STATE);
        Mojing.SDK.bWaitForMojingWord = true;
        if (ConfigItem.TW_STATE && TimeWarpText!=null)
        {
            TimeWarpText.text = "关闭 TimeWarp";
        }
        else if(!ConfigItem.TW_STATE && TimeWarpText != null)
        {
            TimeWarpText.text = "打开 TimeWarp";
            if (SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Metal && !MojingSDK.Unity_IsGlassesNeedDistortionByName(Mojing.SDK.GlassesKey) && !ConfigItem.TW_STATE)
            {
                MojingSDK.Unity_DestroyMetalLayer();
            }
        }
    }

    public void DepthOfField()
    {
//#if UNITY_IOS 
//        Tips.SetActive(true);
//        return;
//#endif
        Application.LoadLevel("ViewLock");
    }

    //展开||关闭 镜片选择二级菜单
    public void OpenGlassMenu()
    {
        //UIListController.show_flag = !UIListController.show_flag;
        //UIListController.show_change = true;
        GlassesList.List_Show = !GlassesList.List_Show;
    }

    //通过glassName获取glasskey
    static string GetGlassKeyByName(string glassName)
    {
        for (int i = 0; i < Mojing.glassesNameList.Count; i++)
        {
            if (Mojing.glassesNameList[i] == glassName)
                return Mojing.glassesKeyList[i];
        }
        return "";
    }

    //展开二级菜单后，选择更换glasses
    public void ChangeGlass(string glassName)
    {
        OpenGlassMenu();
        string sNewKey = GetGlassKeyByName(glassName);

        if (MojingSDK.cur_GlassKey != sNewKey)
        {
            MojingSDK.cur_GlassKey = sNewKey;
            Mojing sdk = Mojing.SDK;
            sdk.GlassesKey = MojingSDK.cur_GlassKey;
        }
        Debug.Log("GlassesName:" + glassName + ", GlassesKey:" + MojingSDK.cur_GlassKey);
    }

  public void ToggleVRMode() {
          Mojing.SDK.VRModeEnabled = !Mojing.SDK.VRModeEnabled;
  }

  public void Start()
  {
      getParameter.EvnOnGetParameter += getParameter_EvnOnGetParameter;
  }

  void OnDestroy()
  {
      getParameter.EvnOnGetParameter -= getParameter_EvnOnGetParameter;
  }

  void getParameter_EvnOnGetParameter(string strName)
  {
      ChangeGlass(strName);
  }
}
