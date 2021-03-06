﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour{
	GameObject gameController;	//検索したオブジェクト入れる用
	public float speed = 3.0f;	//移動speed
	public bool isRight;		//right flag
	public bool isLeft;			//left flag
	private bool isOnceRight;	//一回だけflag
	private bool isOnceLeft;	//一回だけflag
	private bool isOtherLine;	//別ラインに移動したかどうかflag

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		isRight = true;		//初期化
		isLeft = false;		//初期化
		isOnceRight = false;//初期化
		isOnceLeft = false;	//初期化
		isOtherLine = false;//初期化
	}

	void Update(){
		//角度
		Transform myTransform = this.transform;
		// ワールド座標を基準に、回転を取得
		Vector3 worldAngle = myTransform.eulerAngles;

		//ライン上移動
		if(Input.GetKey("up") && isOtherLine == false){
			this.transform.position += new Vector3(0, 0, 4);	//z移動
			isOtherLine = true;
		}
		//ライン下移動
		if(Input.GetKey("down") && isOtherLine == true){
			this.transform.position += new Vector3(0, 0, -4);	//z移動
			isOtherLine = false;
		}

		//右移動
		if(Input.GetKey("right") && isLeft == false){
			isRight = true;
			isOnceLeft = false;		//リセット
			worldAngle.y = 0.0f; // ワールド座標を基準に、y軸を軸にした回転を0度に変更
			transform.position += transform.right * speed * Time.deltaTime;
			//shot判定
			if(isOnceRight == false){
				noShot();
				isOnceRight = true;		//一回だけon
			}
		}else{
			isRight = false;
		}

		//左移動
		if(Input.GetKey("left") && isRight == false){
			isLeft = true;
			isOnceRight = false;		//リセット
			worldAngle.y = 180.0f; // ワールド座標を基準に、y軸を軸にした回転を180度に変更
			transform.position += transform.right * speed * Time.deltaTime;
			//shot判定
			if(isOnceLeft == false){
				noShot();
				isOnceLeft = true;		//一回だけon
			}
		}else{
			isLeft = false;
		}

		//回転角度確定
		myTransform.eulerAngles = worldAngle;
	}

	void noShot(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		gc.isShot = false;		//shot不可にする
	}
}
