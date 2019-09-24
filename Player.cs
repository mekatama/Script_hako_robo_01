using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
	public float speed = 3.0f;	//移動speed
	public bool isRight;		//right flag
	public bool isleft;			//left flag

	void Start(){
		isRight = true;		//初期化
		isleft = false;		//初期化
	}

	void Update(){
		//右移動
		if(Input.GetKey("right") && isleft == false){
			isRight = true;
			Debug.Log("right");
			transform.position += transform.right * speed * Time.deltaTime;
		}else{
			isRight = false;
		}
		//左移動
		if(Input.GetKey("left") && isRight == false){
			isleft = true;
			Debug.Log("left");
			transform.position -= transform.right * speed * Time.deltaTime;
		}else{
			isleft = false;
		}
	}
}
