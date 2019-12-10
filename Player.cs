using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
	GameObject gameController;			//検索したオブジェクト入れる用
	public int playerHp;				//playerのHP
	private bool isDeth;				//死亡flag
	public AudioClip audioClipDamage;	//Damage SE
	public AudioClip audioClipDead;		//Dead SE

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		isDeth = false;		//初期化
	}
	//他のオブジェクトとの当たり判定
	void OnTriggerEnter( Collider other) {
		if(other.tag == "Enemy"){
			//ダメージ処理
			if(playerHp > 0){
				//SEをその場で鳴らす
				AudioSource.PlayClipAtPoint( audioClipDamage, transform.position);	//SE再生
				playerHp = playerHp - 1;	//HPから1引く
				Debug.Log("PlayerHP:" + playerHp);
				Destroy(other.gameObject);	//接触したenemyを削除
				if(playerHp <= 0){
					playerHp = 0;
				}
			}
			//死亡判定
			if(playerHp == 0){
				//gcって仮の変数にGameControllerのコンポーネントを入れる
				GameController gc = gameController.GetComponent<GameController>();
				if(isDeth == false){
					//SEをその場で鳴らす
					AudioSource.PlayClipAtPoint( audioClipDead, transform.position);	//SE再生
					gc.isGameOver = true;
					isDeth = true;
					Destroy(gameObject);	//このGameObjectを削除
				}
			}
		}
	}
}
