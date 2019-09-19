using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
	public float speed = 3.0f;	//移動speed

	void Start(){
	}

	void Update(){
		//移動
		transform.position += transform.right * speed * Time.deltaTime;
	}
}
