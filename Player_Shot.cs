using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shot : MonoBehaviour{
	GameObject gameController;						//検索したオブジェクト入れる用
	public GameObject bulletObject = null;			//弾プレハブ
	public GameObject bomObject = null;				//ボムプレハブ
	public Transform bulletStartPosition = null;	//弾の発射位置を取得する
	private float timeElapsed = 0.0f;				//弾の連射間隔カウント用
	public float timeOut;							//連射間隔の時間
//	public AudioClip audioClipShot;					//発射 SE

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
	}

	void Update(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//shot発射判定
		if(gc.isShot){
			Shot();
		}
	}

	//通常弾発射
	void Shot(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//連射速度の判定
		timeOut = gc.rapidFirePower;	//現在の連射力を取得
		//弾の自動連射
		timeElapsed += Time.deltaTime;
		if(timeElapsed >= timeOut) {
			//SEをその場で鳴らす
//			AudioSource.PlayClipAtPoint( audioClipShot, transform.position);	//SE再生(Destroy対策用)
			//弾を生成する位置を指定
			Vector3 vecBulletPos = bulletStartPosition.position;
			//弾を生成
			Instantiate( bulletObject, vecBulletPos, transform.rotation);
			timeElapsed = 0.0f;
		}
	}

	//BOM発射
	public void Bom(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		if(gc.isBom){
			//SEをその場で鳴らす
	//		AudioSource.PlayClipAtPoint( audioClipShot, transform.position);	//SE再生(Destroy対策用)
			//弾を生成する位置を指定
			Vector3 vecBulletPos = bulletStartPosition.position;
			//弾を生成
			Instantiate( bomObject, vecBulletPos, transform.rotation);
			//残弾減らす
			gc.bomNum --;
		}
	}
}
