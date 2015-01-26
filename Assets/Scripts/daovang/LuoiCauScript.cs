using UnityEngine;
using System.Collections;

public class LuoiCauScript : MonoBehaviour {
	public float speed;
	public float speedMin;
	public float speedBegin;
	public Vector2 velocity;
	public float maxX;
	public float minX;
	public float minY;
	public float maxY;
	public Transform target;
	Vector3 prePosition;

	public int type;

	public bool isUpSpeed;
	public float timeUpSpeed;
	// Use this for initialization
	void Start () {
		isUpSpeed = false;
		prePosition = transform.localPosition;

//		this.StartCoroutine("TimeUpSpeed");
	}

	public IEnumerator TimeUpSpeed ()
	{
		while(true){
			if(isUpSpeed)
			{
				timeUpSpeed = timeUpSpeed - 1;
				if(timeUpSpeed <= 0)
					isUpSpeed = false;
			}
			yield return new WaitForSeconds (1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		checkKeoCauXong();
//		if(CGameManager.Instance.gameState == EnumStateGame.Play) 
		{
			checkTouchScene();

			checkMoveOutCameraView();
		}
	}
	void FixedUpdate() {
//		if(CGameManager.Instance.gameState == EnumStateGame.Play) 
		{
			if(GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.ThaCau || 
			   GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.KeoCau)
				rigidbody2D.velocity = velocity * speed;
		}
	}

//	void OnTriggerEnter2D(Collider2D other) {
//		//		Debug.Log("enter");
//		if(other.gameObject.name.CompareTo("dau") == 0) {
//			GameObject fish = other.gameObject.transform.parent.gameObject;
//			fish.GetComponent<CFishScript>().fishAction = EnumFishAction.CanCau;
//			if(!isUpSpeed) {
//				if(speed > fish.GetComponent<CFishScript>().reduceSpeed) {
//					speed = speed - fish.GetComponent<CFishScript>().reduceSpeed;
//					if(speed < speedMin) 
//						speed = speedMin;
//				}
//			}
//
//			if(GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.ThaCau) {
//				GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction = TypeAction.KeoCau;
//				velocity = -velocity;
//			}
//		}
//
//	}
	
	void OnTriggerExit2D(Collider2D other) {
//		Debug.Log("exit");
//		if(other.gameObject.name == "luoiCau") {
//			isBorder = false;
//		}
	}

	bool checkPositionOutBound() {
		return  gameObject.renderer.isVisible ;
	}

	void checkTouchScene() {
		bool istouch = Input.GetMouseButtonDown(0);
		if(istouch && GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.Nghi)
		{
			GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction = TypeAction.ThaCau;
			velocity = new Vector2(transform.position.x - target.position.x, 
			                       transform.position.y - target.position.y);
			velocity.Normalize();
			speed = speedBegin;
		}
	}
	//kiem tra khi luoi cau ra ngoai tam nhin cua camera
	void checkMoveOutCameraView() {
		if(GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.ThaCau) {
			if(!checkPositionOutBound()) {
				GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction = TypeAction.KeoCau;
				velocity = -velocity;
			}
		}
	}

	//kiem tra khi luoi ca keo len mat nuoc
	void checkKeoCauXong() {
		if(transform.localPosition.y > maxY && GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.KeoCau) {
			Debug.Log("keo cau xong");
			rigidbody2D.velocity = Vector2.zero;
			GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction = TypeAction.Nghi;
			transform.localPosition = prePosition;
		}
	}
}
