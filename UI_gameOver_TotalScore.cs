using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_gameOver_TotalScore : MonoBehaviour{
	private int totalScore;				//temp
	public Text totalScoreText;			//Textコンポーネント取得用

	void Start(){
		//FinishScoreがなかったら０を入れて初期化
		totalScore = PlayerPrefs.GetInt("FinishScore", 0);	//save
	}

	void Update () {
		//totalscore表示
		totalScoreText.text = "TotalScore : " + totalScore.ToString("000000" + "p");
	}
}
