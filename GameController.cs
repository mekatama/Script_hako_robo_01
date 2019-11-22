using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{
	private float timeElapsed = 0.0f;	//noShot間隔カウント用
	public float timeOut;				//noShot間隔の時間
	public bool isShot;					//shot flag
	public int totalScore;				//score
	public int attackPower;				//攻撃力
	public float rapidFirePower;		//連射力
	public int enemySpawn;				//enemyの現在の出現数
	public int enemySpawnMax;			//enemyのMAX出現数
	public bool isGameOver;				//GameOver flag
	public bool isEnemySpawn;			//enemy spawn flag
	public int enemyDestroy;			//enemy破壊数
	public bool isBom;					//Bom発射 flag
	public int bomNum;					//Bom数

	//ゲームステート(※随時追加)
	enum State{
		GameStart,	//開始演出
		Play,		//InGame中
		GameOver,	//ゲームオーバー
	}
	State state;

	void Start(){
		isShot = true;		//初期化
		isEnemySpawn = true;//初期化
		bomNum = 1;			//初期値
		GameStart();		//初期ステート
	}

	void Update(){
		//isShotの判定 playが方向転換時に判定して発射を制御
		if(isShot == false){
			timeOut = 0.5f;
			//カウントダウン
			timeElapsed += Time.deltaTime;
			if(timeElapsed >= timeOut) {
				isShot = true;		//shot許可
				timeElapsed = 0.0f;
			}
		}

		//enemyの出現制御
		if(enemySpawn > enemySpawnMax){
			isEnemySpawn = false;	//enemy出現停止
		}else{
			isEnemySpawn = true;	//enemy出現許可
		}

		//BOM残弾で制御
		if(bomNum > 0){
			isBom = true;
		}else{
			isBom = false;
		}
	}

	void LateUpdate () {
		//ステートの制御
		switch(state){
			case State.GameStart:
//				Debug.Log("game start");
				Play();			//ステート移動
				break;
			case State.Play:
//				Debug.Log("play");
				//GameOver判定予定
				if(isGameOver){
					GameOver();	//ステート移動
				}
				break;
			case State.GameOver:
//				Debug.Log("GameOver");
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
	
		//とりあえずタイトル画面に移動
//		SceneManager.LoadScene("title");	//シーンのロード
		state = State.GameOver;
	}

	//タイトルに戻る用の制御関数
	public void ButtonClicked_Return(){
		SceneManager.LoadScene("title");	//シーンのロード
	}
}
