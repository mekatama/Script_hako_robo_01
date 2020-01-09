using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_gameOver_HighScore : MonoBehaviour{
	private int highScore;				//temp
	public Text highScoreText;			//Textコンポーネント取得用

	void Start(){
		//HighScoreがなかったら０を入れて初期化
		highScore = PlayerPrefs.GetInt("HighScore", 0); 
	}

	void Update () {
		//highscore表示
		highScoreText.text = "HighScore : " + highScore.ToString("000000" + "p");
	}
}
