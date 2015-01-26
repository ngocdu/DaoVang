using UnityEngine;
using System.Collections;

public class ThuyenScript : MonoBehaviour {
	public float speedAcceleration = 30.0F;
	public float speedMax = 100.0F;
	public float speed = 20.0F;
	
	public float smooth = 2.0F;
	public float tiltAngle = 60.0F;
	public float maxX;
	public float minX;
	public Vector3 dir;
	public bool isBorder = false;
	public bool ableMove = true;
	// Use this for initialization
	void Start () {

	}
	void Update () {
		if(ableMove)
			move();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}
	void move()
	{
		dir.x = Input.acceleration.x;
		
		dir *= Time.fixedDeltaTime;
		
		float tiltAroundZ = Input.acceleration.z * tiltAngle;
		float tiltAroundX = Input.acceleration.x * tiltAngle;
		Quaternion target = Quaternion.Euler(tiltAroundX * 2, 90, 0 );
		//		if(transform.position.x < maxX && transform.position.x > minX)
		transform.Translate(dir * speedAcceleration);
		
		
		if(this.transform.position.x <= minX){
			this.transform.position = new Vector3(minX,transform.position.y,transform.position.z);
		}
		if(this.transform.position.x >=  maxX){
			this.transform.position = new Vector3(maxX,transform.position.y,transform.position.z);
		}

	}

//	void OnTriggerEnter2D(Collider2D other) {
//		Debug.Log("enter");
//		if(other.gameObject.tag == "border") {
//			isBorder = true;
//		}
//	}
//
//	void OnTriggerExit2D(Collider2D other) {
//		Debug.Log("exit");
//		if(other.gameObject.tag == "border") {
//			isBorder = false;
//		}
//	}
}
