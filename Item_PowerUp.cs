using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_PowerUp : MonoBehaviour{
	GameObject gameController;	//検索したオブジェクト入れる用
	public float rapidNum;		//連射アップ値

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter( Collider other) {
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		if(other.tag == "Player"){
			Debug.Log("ItemGet");
			gc.rapidFirePower += rapidNum;	//連射アップ
			Destroy(gameObject);			//Item_P削除
		}
	}
}
