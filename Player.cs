using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
	public float speed = 3.0f;	//移動speed
	public bool isRight;		//right flag
	public bool isLeft;			//left flag

	void Start(){
		isRight = true;		//初期化
		isLeft = false;		//初期化
	}

	void Update(){
		//角度
		Transform myTransform = this.transform;
		// ワールド座標を基準に、回転を取得
		Vector3 worldAngle = myTransform.eulerAngles;

		//右移動
		if(Input.GetKey("right") && isLeft == false){
			isRight = true;
			Debug.Log("right");
			worldAngle.y = 0.0f; // ワールド座標を基準に、y軸を軸にした回転を0度に変更
			transform.position += transform.right * speed * Time.deltaTime;
		}else{
			isRight = false;
		}

		//左移動
		if(Input.GetKey("left") && isRight == false){
			isLeft = true;
			Debug.Log("left");
			worldAngle.y = 180.0f; // ワールド座標を基準に、y軸を軸にした回転を180度に変更
			transform.position += transform.right * speed * Time.deltaTime;
		}else{
			isLeft = false;
		}

		//回転角度確定
		myTransform.eulerAngles = worldAngle;
	}
}
