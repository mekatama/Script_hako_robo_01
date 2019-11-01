using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_move : MonoBehaviour{
	public float speed = 0.0f;	//移動speed
	private Enemy1 childScript;	//Enemy1オブジェクトを入れる用
	private bool isOnceRot;		//回転の一回だけ処理

	void Start(){
		//下の階層のオブジェクト(Enemy1)にアタッチしているスクリプトを参照
		childScript = GetComponentInChildren<Enemy1>();
		isOnceRot = false;		//初期化
	}

	void Update(){
		//wallで反転
		if(childScript.isWallHit == true){
			if(isOnceRot == false){
				Debug.Log("rot now");
				isOnceRot =true;
			}
		}
		//移動
			transform.position += transform.right * speed * Time.deltaTime;
	}
}
