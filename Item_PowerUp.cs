using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_PowerUp : MonoBehaviour{

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter( Collider other) {
		if(other.tag == "Player"){
			Debug.Log("ItemGet");
			Destroy(gameObject);	//Item_P削除
		}
	}
}
