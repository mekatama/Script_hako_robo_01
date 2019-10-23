using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{
	private float timeElapsed = 0.0f;	//noShot間隔カウント用
	public float timeOut;				//noShot間隔の時間
	public bool isShot;					//shot flag
	public int totalScore;				//score
	public int attackPower;				//攻撃力
	public bool isGameOver;				//GameOver flag

	//ゲームステート(※随時追加)
	enum State{
		GameStart,	//開始演出
		Play,		//InGame中
		GameOver,	//ゲームオーバー
	}
	State state;

	void Start(){
		isShot = true;	//初期化
		GameStart();	//初期ステート		
	}

	void Update(){
//		Debug.Log("score:" + totalScore);
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

	void LateUpdate () {
		//ステートの制御
		switch(state){
			case State.GameStart:
				Debug.Log("game start");
				Play();			//ステート移動
				break;
			case State.Play:
				Debug.Log("play");
				//GameOver判定予定
				if(isGameOver){
					GameOver();	//ステート移動
				}
				break;
			case State.GameOver:
				Debug.Log("GameOver");
				break;
		}
	}

	void GameStart(){
		state = State.GameStart;
	}
	void Play(){
		state = State.Play;
	}
	void GameOver(){
		//HighScore判定予定
		state = State.GameOver;
	}
}
