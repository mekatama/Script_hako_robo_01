using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour{
	Vector3 diff;
	public GameObject target;	//追従するオブジェクト
	public float followSpeed;	//追従スピード

	void Start () {
		diff = target.transform.position - transform.position;
	}
	
	void Update () {
		//カメラ追従
		transform.position = Vector3.Lerp(
			transform.position,
			target.transform.position - diff,
			Time.deltaTime * followSpeed
		);
	}
}
