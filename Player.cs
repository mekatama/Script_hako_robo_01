using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
	public float speed = 3.0f;	//移動speed
	public bool isRight;		//向きflag

	void Start(){
		isRight = true;		//初期化
	}

	void Update(){
		//移動
		if(Input.GetKey("right")){
			isRight = true;
			transform.position += transform.right * speed * Time.deltaTime;
		}
		if(Input.GetKey("left")){
			transform.position -= transform.right * speed * Time.deltaTime;
			isRight = false;
		}
	}
}
