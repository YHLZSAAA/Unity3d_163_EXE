using UnityEngine;
using System.Collections;
using MojingSample.CrossPlatformInput;
using UnityEngine.SceneManagement;
using System.Threading;

public class Player : MonoBehaviour {

	public float speed;
	public float rotSpeed = 60;
	public int health = 300;
	public Transform cam;
	private Vector3 velocity = Vector3.zero;
	public GameObject bullet;
	public Transform muzzleL,muzzleR;
	public float myShootRate = 0.2f;

	public AudioSource myas;
	public AudioClip audioClip;

	/// <summary>
	/// 针对瞄准镜和框体，设置跟随主机的坐标位置
	/// </summary>
	public Camera camUI;
	public Transform aimUI;
	public GameObject ptc;
	public GameObject model;
	private Collider coll;

	public GameObject myuGUICrossNodeBase;

    public GameObject myuGUICenterCross;

    private float myShootTime;

	static public Transform PlayerTrans;



	// Use this for initialization
	void Start () {

        //myuGUICrossNodeBase.SetActive (false);
        //myuGUICenterCross.SetActive(false);
        PlayerTrans = this.transform;

        this.coll = this.GetComponent<BoxCollider>();
	}

    void OnEnable()
    {

    }
	// Update is called once per frame
	void Update () {

        if (!model.activeSelf)
        {
            return;

        }

		transform.forward = Vector3.SmoothDamp (transform.forward, cam.forward, ref velocity, rotSpeed);
		transform.Translate (Vector3.forward * speed * Time.deltaTime);


		if (myShootTime < myShootRate) {
			myShootTime += Time.deltaTime;
		}


		//if (Input.GetButton("Fire1"))//|| Input.GetKey(KeyCode.Space)) {
		if (model.activeSelf && (Input.GetMouseButton(0) || CrossPlatformInputManager.GetButton("OK") ))
		{
			if (myShootTime >= myShootRate) {
				Instantiate (bullet, muzzleL.position, muzzleL.rotation);
				Instantiate (bullet, muzzleR.position, muzzleR.rotation);
				if (myas) {
					myas.PlayOneShot(this.audioClip);
				}
				myShootTime -= myShootRate;
			}

		}

		if (aimUI) {
			Vector3 u = camUI.WorldToScreenPoint (transform.position + transform.forward * 9999);

			aimUI.localPosition = new Vector3 (u.x- Screen.width * 0.5f, u.y - Screen.height * 0.5f, 0);
			
		}


	}
		
	public void Hurt(int v)
	{
		if (v > 0) {
			health -= v;
			if (health <= 0) {
				Death ();
			}
		}
	}

	private void Death()
	{
		Debug.Log ("I am dead");
		Instantiate (ptc, transform.position, transform.rotation);
        //gameObject.SetActive (false);//禁用player对象
        //Destroy(this.gameObject);  //Destory的话，整个画面就不动了，因为有些依赖主角的方法和属性就找不到了，比如敌机的转向等等
        if (model)
        { //禁用player对象
            this.model.SetActive(false);
            //Debug.Log(model.activeSelf);
        }
        //this.gameObject.SetActive(false); //如果直接设置当前的gameObject,则在重新加载的时候会提示Coroutine couldn't be started because the the game object 'Copperhead' is inactive!

        //当主角不在了，则取消其碰撞属性
        coll.enabled = false;

        ShowHandlePanel();
        //StartCoroutine (WaitAndPrint ());
		//Thread.Sleep(5000);
		//SceneManager.LoadScene(0);
	}

    private void ShowHandlePanel()
    {
        if (myuGUICenterCross)
        {
            Debug.Log("headre position " + myuGUICenterCross.transform.position);
            //endHandle.transform.position = this.aimUI.transform.position;

            myuGUICenterCross.SetActive(true);
        }

        if (myuGUICrossNodeBase)
        {
            //endHandle.transform.position = this.aimUI.transform.position;
            Debug.Log("Panel position " + myuGUICrossNodeBase.transform.position);
			//myuGUICenterCross.transform.parent = null;
            myuGUICrossNodeBase.SetActive(true);
        }

		if (aimUI) {
			aimUI.gameObject.SetActive (false);


		}
    }

	IEnumerator WaitAndPrint() {
		yield return new WaitForSeconds(2.0f);

        //SceneManager.LoadScene(0);



        
        //SceneManager.LoadScene (0);
    }
}
