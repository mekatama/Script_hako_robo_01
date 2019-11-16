using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour{
	GameObject gameController;		//検索したオブジェクト入れる用
	public GameObject[] itemObject;	//itemのプレハブを配列で管理
	private int itemType;			//enemyの種類
	public GameObject item;
	private bool isItemSpawn;		//item出現一回だけflag
	private float x_pos;			//出現位置
	private float y_pos;			//出現位置
	private float z_pos;			//出現位置

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		itemType = 0;			//itemの種類初期化
		item = null;			//初期化
		isItemSpawn = false;	//初期化
	}

	void Update(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//仮で敵の倒した数でitem出現
		if(gc.enemyDestroy == 3){
			if(isItemSpawn == false){
				ItemGo();
				isItemSpawn = true;
			}
		}else if(gc.enemyDestroy == 5){
			if(isItemSpawn == false){
				ItemGo();
				isItemSpawn = true;
			}
		}else{
			isItemSpawn = false;
		}
	}

	//item出現
	public void ItemGo(){
		itemType = 0;	//仮の値
		int spawnPosZ = Random.Range(0,2);		//ランダムで出現ラインを決める
		float spawnPosX = Random.Range(-3,3);	//ランダムでx座礁を決める
		//出現位置
		switch(spawnPosZ){
			case 0:				//line手前
				x_pos = spawnPosX;
				y_pos = 1.0f;
				z_pos = -2.0f;
				break;
			case 1:				//line奥
				x_pos = spawnPosX;
				y_pos = 1.0f;
				z_pos = 2.0f;
				break;
		}
		//itemを生成する
		item = (GameObject)Instantiate(
			itemObject[itemType],	
			new Vector3(x_pos, y_pos, z_pos),
			transform.rotation
			);
	}
}
