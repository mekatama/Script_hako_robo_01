using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bom : MonoBehaviour{
	GameObject gameController;	//検索したオブジェクト入れる用

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter( Collider other) {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		if(other.tag == "Player"){
			gc.bomNum ++;			//ボム残弾+1
			Destroy(gameObject);	//Item_Bom削除
		}
	}
}
