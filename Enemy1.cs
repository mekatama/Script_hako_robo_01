using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour{
	GameObject gameController;			//検索したオブジェクト入れる用
	public int enemyHp;		//EnemyのHP
	public int enemyScore;	//enemyの点数
	private bool isDeth;	//死亡flag

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerを探す
		isDeth = false;		//初期化
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter( Collider other) {
		if(other.tag == "Bullet"){
			//ダメージ処理
			if(enemyHp > 0){
				enemyHp = enemyHp - 1;	//攻撃力をHPから引く
				if(enemyHp <= 0){
					enemyHp = 0;
				}
			}
			//死亡判定
			if(enemyHp == 0){
				if(isDeth == false){
					//gcって仮の変数にGameControllerのコンポーネントを入れる
					GameController gc = gameController.GetComponent<GameController>();
					gc.totalScore += enemyScore;	//スコア加算
					Destroy(gameObject);			//このGameObjectを削除
					isDeth = true;
				}
			}
		}
	}
}
