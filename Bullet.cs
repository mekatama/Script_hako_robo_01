using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
	public float speed = 3.0f;	//移動speed
	GameObject player;			//検索したオブジェクト入れる用

	void Start(){
		player = GameObject.FindWithTag ("Player");	//Playerタグのオブジェクトを探す
		//pって仮の変数にPlayerコンポーネントを入れる
		Player p = player.GetComponent<Player>();
		//移動方向決定
		if(p.isRight){
			speed = 1 * speed;
		}else{
			speed = -1 * speed;
		}
	}

	void Update(){
		//移動
			transform.position += transform.right * speed * Time.deltaTime;
	}
}
