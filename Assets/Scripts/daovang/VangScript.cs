using UnityEngine;
using System.Collections;

public class VangScript : MonoBehaviour {
	public bool isMoveFollow = false;
	public float maxY;
	public int score;
	public float speed;
	// Use this for initialization
	void Start () {
		isMoveFollow = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		moveFllowTarget(GameObject.Find("luoiCau").transform);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "luoiCau") {
			isMoveFollow = true;
			GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction = TypeAction.KeoCau;
			GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().velocity = -GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().velocity;
			GameObject.Find("luoiCau").GetComponent<LuoiCauScript>().speed -= this.speed;
		}
	}

	void moveFllowTarget(Transform target) {
		if(isMoveFollow) 
		{
				Quaternion tg = Quaternion.Euler(target.parent.transform.rotation.x, 
				                                 target.parent.transform.rotation.y, 
				                                 90 + target.parent.transform.rotation.z);
//				transform.rotation = Quaternion.Slerp(transform.rotation, tg, 0.5f);
				transform.position = new Vector3(target.position.x, 
				                                 target.position.y - gameObject.GetComponent<Collider2D>().collider2D.bounds.size.y / 2, 
				                                 transform.position.z);	
			if(GameObject.Find("dayCau").GetComponent<DayCauScript>().typeAction == TypeAction.Nghi) {
				GameObject.Find("GamePlay").GetComponent<GamePlayScript>().score += this.score;
				Destroy(gameObject);
			}
		}
	}
}
