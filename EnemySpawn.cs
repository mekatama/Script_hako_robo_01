﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour{
	GameObject gameController;			//検索したオブジェクト入れる用
	public GameObject[] enemyObject;	//enemyのプレハブを配列で管理
	public float timeOut;				//enemyを出現させたい時間間隔
	private float timeElapsed;			//時間を仮に格納する変数
	private int enemyType;				//enemyの種類
	public GameObject enemy;
	private float x_pos;				//出現位置
	private float y_pos;				//出現位置
	private float z_pos;				//出現位置

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		enemyType = 0;	//enemyの種類初期化
		enemy = null;	//初期化
	}

	void Update(){
		//enemy出現
		timeElapsed += Time.deltaTime;	//経過時間の保存
		if(timeElapsed >= timeOut) {	//指定した経過時間に達したら
			EnemyGo();
		}
	}

	public void EnemyGo(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		if(gc.isEnemySpawn){
			//enemyTypeをenemyDestroyで分岐(仮の分岐条件)
			if(gc.enemyDestroy > 2){
				enemyType = 1;		//仮の値
			}else{
				enemyType = 0;		//仮の値
			}

			int spawnPos = Random.Range(0,4);		//ランダムで出現サイドを決める
			//出現位置
			switch(spawnPos){
				case 0:				//line手前右
					x_pos = 4.0f;
					y_pos = 2.0f;
					z_pos = -2.0f;
					transform.rotation = Quaternion.Euler(0,180.0f,0);	//spawn pointを回転
					break;
				case 1:				//line手前左
					x_pos = -4.0f;
					y_pos = 2.0f;
					z_pos = -2.0f;
					transform.rotation = Quaternion.Euler(0,0.0f,0);	//spawn pointを回転
					break;
				case 2:				//line奥右
					x_pos = 4.0f;
					y_pos = 2.0f;
					z_pos = 2.0f;
					transform.rotation = Quaternion.Euler(0,180.0f,0);	//spawn pointを回転
					break;
				case 3:				//line奥左
					x_pos = -4.0f;
					y_pos = 2.0f;
					z_pos = 2.0f;
					transform.rotation = Quaternion.Euler(0,0.0f,0);	//spawn pointを回転
					break;
			}

			//enemyを生成する
			enemy = (GameObject)Instantiate(
				enemyObject[enemyType],	
				new Vector3(x_pos, y_pos, z_pos),
				transform.rotation
			);
			timeElapsed = 0.0f;	//生成時間リセット
			gc.enemySpawn ++;	//現在のenemy数に加算
		}
	}
}
