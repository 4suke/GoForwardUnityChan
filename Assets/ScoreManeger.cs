using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine. UI;

public class ScoreManeger : MonoBehaviour
{

    //スコアを表示するテキスト
    private GameObject scoreText;

    //得点
    private int score = 0;

    // Use this for initialization
    void Start()
    {

        //シーン中のScoreオブジェクトを取得
        this.scoreText = GameObject.Find("Score");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Addscore(int value)
    {
        // スコアを加算
        this.score += value;

        //ScoreText獲得した点数を表示
        this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
    }
   
}
