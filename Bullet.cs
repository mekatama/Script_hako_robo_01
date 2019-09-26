using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
	public float speed = 0.0f;	//移動speed
	GameObject player;			//検索したオブジェクト入れる用

	void Start(){
		player = GameObject.FindWithTag ("Player");	//Playerタグのオブジェクトを探す
		//pって仮の変数にPlayerコンポーネントを入れる
		Player p = player.GetComponent<Player>();
		//生成時に移動方向決定
		if(p.isRight){
			speed = 1 * speed;
		}
		if(p.isLeft){
			speed = -1 * speed;
		}
	}

	void Update(){
		//移動
			transform.position += transform.right * speed * Time.deltaTime;
	}

	//他のオブジェクトとの当たり判定
	void OnTriggerEnter( Collider other) {
		if(other.tag == "Wall"){
			Destroy(gameObject);	//このGameObjectを［Hierrchy］ビューから削除する
		}
	}
}
