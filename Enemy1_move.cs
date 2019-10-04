using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_move : MonoBehaviour{
	public float speed = 0.0f;	//移動speed

	void Update(){
		//移動
			transform.position += transform.right * speed * Time.deltaTime;
	}
}
