using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_move : MonoBehaviour{
	public float speed = 0.0f;	//移動speed
	private Enemy1 childScript;	//Enemy1オブジェクトを入れる用
	private bool isOnceRot_R;	//R回転の一回だけ処理
	private bool isOnceRot_L;	//L回転の一回だけ処理
	public float hitStoptime = 0.2f;	//HitStop間隔
	private float timeElapsed = 0.0f;	//HitStopカウント用

	void Start(){
		//下の階層のオブジェクト(Enemy1)にアタッチしているスクリプトを参照
		childScript = GetComponentInChildren<Enemy1>();
		isOnceRot_R = false;	//初期化
		isOnceRot_L = false;	//初期化
	}

	void Update(){
		//wall Rで反転
		if(childScript.isWallHit_R == true){
			if(isOnceRot_R == false){
				transform.rotation = Quaternion.Euler(0,180.0f,0);	//回転
				isOnceRot_R = true;
				isOnceRot_L = false;
			}
		}
		//wall Lで反転
		if(childScript.isWallHit_L == true){
			if(isOnceRot_L == false){
				transform.rotation = Quaternion.Euler(0,0,0);	//回転
				isOnceRot_L = true;
				isOnceRot_R = false;
			}
		}

		if(childScript.isHitStop == false){
			//移動
			transform.position += transform.right * speed * Time.deltaTime;
		}else{
			//HitStop中はtransform.position処理に行かない
			timeElapsed += Time.deltaTime;
			if(timeElapsed >= hitStoptime) {
				timeElapsed = 0.0f;
				childScript.isHitStop = false;
			}
		}
	}
}
