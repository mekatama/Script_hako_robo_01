using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

	//Start用の制御関数
	public void ButtonClicked_Start(){
		SceneManager.LoadScene("main01");	//シーンのロード
	}
}
