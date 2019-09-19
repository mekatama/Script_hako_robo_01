using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shot : MonoBehaviour{
	public GameObject bulletObject = null;			//弾プレハブ
	public Transform bulletStartPosition = null;	//弾の発射位置を取得する
	private float timeElapsed = 0.0f;				//弾の連射間隔カウント用
	public float timeOut;							//連射間隔の時間
//	public AudioClip audioClipShot;					//発射 SE

	void Start(){
	}

	void Update(){
		Shot();
	}

	void Shot(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
//		GameController gc = gameController.GetComponent<GameController>();
		//連射速度の判定
		timeOut = 0.4f;
		//弾の自動連射
		timeElapsed += Time.deltaTime;
		if(timeElapsed >= timeOut) {
			//SEをその場で鳴らす
//			AudioSource.PlayClipAtPoint( audioClipShot, transform.position);	//SE再生(Destroy対策用)
			//弾を生成する位置を指定
			Vector3 vecBulletPos	= bulletStartPosition.position;
			//弾を生成
			Instantiate( bulletObject, vecBulletPos, transform.rotation);
			timeElapsed = 0.0f;
		}
	}
}
