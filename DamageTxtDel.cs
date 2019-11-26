using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTxtDel : MonoBehaviour{
	void Start () {
		Destroy(gameObject,1.0f);	//1秒後にオブジェクトの削除
	}
}
