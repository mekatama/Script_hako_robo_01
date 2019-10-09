using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{
	private float timeElapsed = 0.0f;	//noShot間隔カウント用
	public float timeOut;				//noShot間隔の時間
	public bool isShot;					//shotflag
	public int totalScore;				//score
	public int attackPower;				//攻撃力

	void Start(){
		isShot = true;	//初期化
	}

	void Update(){
		Debug.Log("score:" + totalScore);
		//isShotの判定 playが方向転換時に判定して発射を制御
		if(isShot == false){
			timeOut = 0.5f;
			//カウントダウン
			timeElapsed += Time.deltaTime;
			if(timeElapsed >= timeOut) {
				isShot = true;		//shot許可
//				Debug.Log("shot : " + isShot);
				timeElapsed = 0.0f;
			}
		}
	}
}
