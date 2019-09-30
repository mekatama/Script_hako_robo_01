using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
	GameObject gameController;			//検索したオブジェクト入れる用
	public float speed = 3.0f;	//移動speed
	public bool isRight;		//right flag
	public bool isLeft;			//left flag
	private bool isOnceRight;	//一回だけflag
	private bool isOnceLeft;	//一回だけflag

	void Start(){
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		isRight = true;		//初期化
		isLeft = false;		//初期化
		isOnceRight = false;//初期化
		isOnceLeft = false;	//初期化
	}

	void Update(){
		//角度
		Transform myTransform = this.transform;
		// ワールド座標を基準に、回転を取得
		Vector3 worldAngle = myTransform.eulerAngles;

		//右移動
		if(Input.GetKey("right") && isLeft == false){
			isRight = true;
			isOnceLeft = false;		//リセット
//			Debug.Log("right");
			worldAngle.y = 0.0f; // ワールド座標を基準に、y軸を軸にした回転を0度に変更
			transform.position += transform.right * speed * Time.deltaTime;
			//shot判定
			if(isOnceRight == false){
				noShot();
				isOnceRight = true;		//一回だけon
			}
		}else{
			isRight = false;
		}

		//左移動
		if(Input.GetKey("left") && isRight == false){
			isLeft = true;
			isOnceRight = false;		//リセット
//			Debug.Log("left");
			worldAngle.y = 180.0f; // ワールド座標を基準に、y軸を軸にした回転を180度に変更
			transform.position += transform.right * speed * Time.deltaTime;
			//shot判定
			if(isOnceLeft == false){
				noShot();
				isOnceLeft = true;		//一回だけon
			}
		}else{
			isLeft = false;
		}

		//回転角度確定
		myTransform.eulerAngles = worldAngle;
	}

	void noShot(){
		Debug.Log("noshot");
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		gc.isShot = false;		//shot不可にする
	}

}
