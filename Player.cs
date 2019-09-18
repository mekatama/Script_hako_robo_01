using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
	public float speed = 3.0f;	//移動speed

    void Start(){
    }

    // Update is called once per frame
    void Update(){
		//移動
		if(Input.GetKey("right")){
			transform.position += transform.right * speed * Time.deltaTime;
		}
		if(Input.GetKey("left")){
			transform.position -= transform.right * speed * Time.deltaTime;
		}
    }
}
