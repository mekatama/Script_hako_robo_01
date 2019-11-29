using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTxtDel : MonoBehaviour{

	void Start () {
		//強制的にy軸０度にして、テキストの反転を防ぐ
		transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 1, 0));
		Destroy(gameObject,1.0f);	//1秒後にオブジェクトの削除
	}

	void Update(){
	}
}
