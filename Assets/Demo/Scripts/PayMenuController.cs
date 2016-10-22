﻿//------------------------------------------------------------------------------
// Copyright 2016 Baofeng Mojing Inc. All rights reserved.
//------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;//引用UI命名空间

public class PayMenuController : MonoBehaviour {
	
	public GameObject[] Button_Object;
	private int buttonCurIndex = -1;
	
	// Use this for initialization
	void Start () {
        HoverNext ();
	}
	
	public void HoverNext() {
		buttonCurIndex++;
		buttonCurIndex = buttonCurIndex % Button_Object.Length;
		
		for (int i = 0; i < Button_Object.Length; i++) {
			if(i != buttonCurIndex) {
				Button_Object[i].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
				Button_Object[i].GetComponent<RectTransform>().sizeDelta = new Vector2 (400,80);
			}
			else {
				Button_Object[i].GetComponent<Image>().color = new Color(0.5f, 1.0f, 0.5f);
				Button_Object[i].GetComponent<RectTransform>().sizeDelta = new Vector2 (410,90);
			}
		}
	}
	
	public void HoverPrev() {
		buttonCurIndex--;
		if (buttonCurIndex < 0)
			buttonCurIndex = Button_Object.Length - 1;
		
		for (int i = 0; i < Button_Object.Length; i++) {
			if(i != buttonCurIndex) {
				Button_Object[i].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
				Button_Object[i].GetComponent<RectTransform>().sizeDelta = new Vector2 (400, 80);
			}
			else {
				Button_Object[i].GetComponent<Image>().color = new Color(0.5f, 1.0f, 0.5f);
				Button_Object[i].GetComponent<RectTransform>().sizeDelta = new Vector2 (410, 90);
			}
			
		}
	}

	public void PressCurrent() {
		switch (buttonCurIndex) {
		    case 0:
                MojingLoginPay.SingleLogin();
			break;
            case 1:
                MojingLoginPay.DoubleLogin();
            break;
            case 2:
                MojingLoginPay.syncMjAppLoginState();
            break;
            case 3:
                MojingLoginPay.Register();
            break;
            case 4:
                MojingLoginPay.SinglePay();
            break;
            case 5:
                MojingLoginPay.DoublePay1();
            break;
            case 6:
                MojingLoginPay.DoublePay2();
                break;
            case 7:
                MojingLoginPay.GetBalance();
            break;
        }
	}
}
