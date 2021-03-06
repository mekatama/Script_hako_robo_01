﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour{
	GameObject gameController;			//検索したオブジェクト入れる用
	public GameObject item_Bom;			//Enemyから出現させるアイテム
	public GameObject scoreTxt;			//Enemyから出現させるscore txt
	public GameObject score;
	public GameObject particle;			//爆発Particle
	public int enemyHp;		//EnemyのHP
	public int enemyScore;	//enemyの点数
	private bool isDeth;	//死亡flag
	public bool isWallHit_R;//wall hit flag
	public bool isWallHit_L;//wall hit flag
	public bool isHitStop;	//hit stop flag
	public AudioClip audioClipDamage;	//Damage SE
	public AudioClip audioClipDead;		//Dead SE

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerを探す
		isDeth = false;		//初期化
		isWallHit_R = false;//初期化
		isWallHit_L = false;//初期化
		score = null;		//初期化
		isHitStop = false;	//初期化
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter( Collider other) {
		if(other.tag == "Bullet"){
			//ダメージ処理
			if(enemyHp > 0){
				//gcって仮の変数にGameControllerのコンポーネントを入れる
				GameController gc = gameController.GetComponent<GameController>();
				//SEをその場で鳴らす
				AudioSource.PlayClipAtPoint( audioClipDamage, transform.position);	//SE再生
				enemyHp = enemyHp - gc.attackPower;	//攻撃力をHPから引く
				if(enemyHp <= 0){
					enemyHp = 0;
				}
				isHitStop = true;
			}
			//死亡判定
			if(enemyHp == 0){
				if(isDeth == false){
					//gcって仮の変数にGameControllerのコンポーネントを入れる
					GameController gc = gameController.GetComponent<GameController>();
					gc.totalScore += enemyScore;	//スコア加算
					gc.enemySpawn --;				//現在のenemy数を減らす
					gc.enemyDestroy ++;				//enemy破壊数加算
					//爆発effect
					Instantiate (particle, transform.position, transform.rotation);
					//SEをその場で鳴らす
					AudioSource.PlayClipAtPoint( audioClipDead, transform.position);	//SE再生
					//BOM出現
					Instantiate (	item_Bom, 
									new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),
									transform.rotation);
					//scoreを生成する
					score = (GameObject)Instantiate(
						scoreTxt,
						transform.position,
						transform.rotation
					);
					//生成したscoreに得点を渡す
					score.GetComponent<TextMesh>().text = enemyScore.ToString("0000");
//					Debug.Log("name : " + score.GetComponent<TextMesh>().text);

					Destroy(gameObject);			//このGameObjectを削除
					isDeth = true;
				}
			}
		}
		if(other.tag == "Bom"){
			if(isDeth == false){
				//gcって仮の変数にGameControllerのコンポーネントを入れる
				GameController gc = gameController.GetComponent<GameController>();
				gc.totalScore += enemyScore * gc.bomRate;	//スコア加算(bomRateかける)
				gc.enemySpawn --;							//現在のenemy数を減らす
				gc.enemyDestroy ++;							//enemy破壊数加算

				//scoreを生成する
				score = (GameObject)Instantiate(
					scoreTxt,
					transform.position,
					transform.rotation
				);
				//生成したscoreに得点を渡す
				score.GetComponent<TextMesh>().text = enemyScore.ToString("0000") + "×" + gc.bomRate;

				Destroy(gameObject);			//このGameObjectを削除
				isDeth = true;
			}
		}
		if(other.tag == "Wall_R"){
			isWallHit_R = true;
			isWallHit_L = false;
		}
		if(other.tag == "Wall_L"){
			isWallHit_R = false;
			isWallHit_L = true;
		}
	}
}
