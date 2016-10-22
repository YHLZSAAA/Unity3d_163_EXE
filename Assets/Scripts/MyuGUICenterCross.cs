//------------------------------------------------------------------------------
// Copyright 2016 Baofeng Mojing Inc. All rights reserved.
//------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
public class MyuGUICenterCross : MonoBehaviour
{
    private GameObject _mainCamera;
    Transform CenterPointer;
    //private UISprite _rotateSprite;
    //private UISprite _dotSprite;
    private Transform _rotateSprite;
    private Transform _dotSprite;
    private MyuGUICrossNodeBase _selectedNode;
    private float _enterTime;
    private Transform _head;
    public static MyuGUICenterCross Instance;
    private bool _haveGrab;
    public Transform target;

    public LayerMask lm;

    void Awake()
    {
        Instance = this;
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //CenterPointer = GameObject.Find("CamRoot/MojingMain/MojingVrHead/GazePointer").transform;
        _head = transform.Find("head");
        _rotateSprite = _head.Find("waitting");
        _rotateSprite.gameObject.SetActive(false);
        _dotSprite = _head.Find("click");
        _dotSprite.gameObject.SetActive(true);
        //transform.SetParent(CenterPointer);
        EnableControl(true);
        Debug.Log("MyuGUICenterCross awake");
    }

	void OnEnable()
	{
		Debug.Log("header OnEnable");
		Vector3 u = target.position;
		this.transform.position = new Vector3 (u.x, u.y, u.z + 1);

	}

	void OnDisable()
	{
		Debug.Log("header OnDisable");
	} 

    void Start()
    {
        Debug.Log("MyuGUICenterCross start");
    }

    void Update()
    {
        Debug.Log("MyuGUICenterCross Update");
        SetSelectedNode();
        if (_haveGrab)
            return;

        _rotateSprite.gameObject.SetActive(false);
        _dotSprite.gameObject.SetActive(true);
        //_rotateSprite.fillAmount = 0;
        if (_selectedNode != null && _selectedNode.Clickable)
        {
            var selectTime = Time.time - _enterTime;
            if (CheckTouch())
            {
                selectTime = float.MaxValue;
            }
            if (selectTime > _selectedNode.HoverTime)
            {
                if (selectTime - _selectedNode.HoverTime < _selectedNode.ClickTime)
                {
                    if (_selectedNode.ShowWaiting)
                    {
                        _rotateSprite.gameObject.SetActive(true);
                        _dotSprite.gameObject.SetActive(false);
                    }
                    var passedClickTime = selectTime - _selectedNode.HoverTime;
                    _rotateSprite.GetComponent<Image>().fillAmount = passedClickTime / _selectedNode.ClickTime;
                }
                else
                {
                    _selectedNode.OnClick();
                    if (_selectedNode.Grabable)
                        _haveGrab = true;
                    else
                        _selectedNode = null;
                }
            }
        }
    }

    /// <summary>
    /// 是否启用头控
    /// </summary>
    /// <param name="enable"></param>
    public void EnableControl(bool enable)
    {
        if (_head == null)
        {
            _head = transform.Find("head");
            if (_head == null)
                return;
        }
        _head.gameObject.SetActive(enable);
        if (!enable)
        {
            if (_selectedNode != null)          //disable select also
                _selectedNode.SetSelect(false);
        }
    }

    private void SetSelectedNode()
    {
        MyuGUICrossNodeBase currentNode = null;
        RaycastHit hit;
        var forward = _mainCamera.transform.forward;
        if (Physics.Raycast(transform.position, forward, out hit, 1000000,lm))
        {
            currentNode = hit.collider.gameObject.GetComponent<MyuGUICrossNodeBase>();
        }

        if (currentNode)
        {
			Debug.Log("node is not null");
            Debug.Log(currentNode.transform.position);
        }
        else
        {
            Debug.Log("node is null");
        }
       

        //if(currentNode != null)
        //	Debug.LogWarning("currentNode " + currentNode.name);

        if (currentNode != _selectedNode)
        {
            _haveGrab = false;
            if (_selectedNode != null)
            {
                _selectedNode.SetSelect(false);
            }
            _selectedNode = currentNode;
            _enterTime = Time.time;
            if (_selectedNode != null)
            {
                _selectedNode.SetSelect(true);
            }
        }

        if (currentNode != null)
        {
            //_head.position = hit.point + new Vector3(0,0,-1);
        }
    }

    private bool CheckTouch()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
            return true;
#endif
        if (Input.touchSupported && Input.touchCount > 0)
        {
            var touch = Input.touches[0];
            Debug.Log(touch.phase);
            return touch.phase == TouchPhase.Began;
        }
        return false;
    }
}
