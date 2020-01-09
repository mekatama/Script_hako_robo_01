using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{
	private float timeElapsed = 0.0f;	//noShot間隔カウント用
	public float timeOut;				//noShot間隔の時間
	public bool isShot;					//shot flag
	public int totalScore;				//score
	public int finishScore;				//gemeover時のscore
	public int highScore = 0;			//high score
	public int isNewRecord;				//high score更新制御用intで代用
	public int attackPower;				//攻撃力
	public float rapidFirePower;		//連射力
	public int enemySpawn;				//enemyの現在の出現数
	public int enemySpawnMax;			//enemyのMAX出現数
	public bool isGameOver;				//GameOver flag
	public bool isEnemySpawn;			//enemy spawn flag
	public int enemyDestroy;			//enemy破壊数
	public bool isBom;					//Bom発射 flag
	public int bomNum;					//Bom数
	public int bomRate;					//Bom得点倍率

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
		//Losdする HighScoreがなかったら０を入れて初期化
		highScore = PlayerPrefs.GetInt("HighScore", 0); 
		//Losdする FinishScoreがなかったら０を入れて初期化
//		finishScore = PlayerPrefs.GetInt("FinishScore", 0); 
		//NewRecord flag用 0 = false
		PlayerPrefs.SetInt("NewRecord", 0);

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
				Play();			//ステート移動
				break;
			case State.Play:
				//GameOver判定予定
				if(isGameOver){
					GameOver();	//ステート移動
				}
				break;
			case State.GameOver:
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
		//gemeover時のscoreを保存
		finishScore = totalScore;
		PlayerPrefs.SetInt("FinishScore", finishScore);		//save
		//HighScore判定
		if(totalScore > highScore){
			highScore = totalScore;
			isNewRecord = 1;								//newrecord flag on
			PlayerPrefs.SetInt("HighScore", highScore);		//save
			PlayerPrefs.SetInt("NewRecord", isNewRecord);	//save
			Debug.Log("HighScore=" + highScore);
		}
	
		//gemeover画面に移動
		SceneManager.LoadScene("gameover");	//シーンのロード
		state = State.GameOver;
	}

	//タイトルに戻る用の制御関数
	public void ButtonClicked_Return(){
		SceneManager.LoadScene("title");	//シーンのロード
	}
}
