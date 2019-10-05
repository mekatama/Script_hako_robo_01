using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour{
	public GameObject[] enemyObject;	//enemyのプレハブを配列で管理
	public float timeOut;				//enemyを出現させたい時間間隔
	private float timeElapsed;			//時間を仮に格納する変数
	private int enemyType;				//enemyの種類
	public GameObject enemy;
	private float x_pos;				//出現位置
	private float y_pos;				//出現位置
	private float z_pos;				//出現位置

	void Start(){
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
		enemyType = 0;		//仮の値
		int spawnPos = Random.Range(0,2);		//ランダムで出現サイドを決める
		//出現位置
		switch(spawnPos){
			case 0:
				x_pos = 4.0f;
				y_pos = 2.0f;
				z_pos = -2.0f;
				Debug.Log("右");
				break;
			case 1:
				x_pos = -4.0f;
				y_pos = 2.0f;
				z_pos = -2.0f;
				Debug.Log("左");
				break;
		}

		//enemyを生成する
		enemy = (GameObject)Instantiate(
			enemyObject[enemyType],	
			new Vector3(x_pos, y_pos, z_pos),
			transform.rotation
		);
		timeElapsed = 0.0f;			//生成時間リセット
	}
}
