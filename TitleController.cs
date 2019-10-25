using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour {

	void Update(){
		//物理backキー
		if (Input.GetKeyUp(KeyCode.Escape)){
			Application.Quit();	//アプリ終了
		}
	}

	//Start用の制御関数
	public void ButtonClicked_Start(){
		SceneManager.LoadScene("main01");	//シーンのロード
	}
	//遊び方画面用の制御関数
	public void ButtonClicked_HowToPlay(){
		SceneManager.LoadScene("howtoplay");//シーンのロード
	}
	//タイトルに戻る用の制御関数
	public void ButtonClicked_Return(){
		SceneManager.LoadScene("title");	//シーンのロード
	}
	//アプリ終了
	public void ButtonClicked_Exit(){
		Application.Quit();
		Debug.Log("exit");	
	}
}
