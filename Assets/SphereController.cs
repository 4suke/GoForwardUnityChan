using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SphereController : MonoBehaviour {

    //ボールを発射させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    //unityのゲームオブジェクトを宣言
    private GameObject unity;

    private GameObject ScoreManeger;

    //ボールの発射速度
    private float powerX = 15;
    private float powerY = 15;

    // ボールの速度の減衰
    private float dump = 0.8f;

    /*
    //スコアを表示するテキスト
    private GameObject scoreText;

    //得点
    private int score = 0;
    */



    // Use this for initialization
    void Start ()
    {
        
        // Rigidbody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.AddForce(new Vector2(powerX, powerY), ForceMode2D.Impulse);

        this.ScoreManeger = GameObject.Find("ScoreManeger");
        /*
        //シーン中のscoreTextオブジェクトを取得（追加）
        this.scoreText = GameObject.Find("Score");
        */
    }

    // Update is called once per frame
    void Update ()
    {
        /*
        //弾発射の力をかける
        this.rigid2D.velocity = new Vector2(velocityX, velocityY);
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
        */



    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "block")
        {
            //パーティクルを再生
            GetComponent<ParticleSystem>().Play();

            //接触したオブジェクトを破棄
            Destroy(other.gameObject);
            Destroy(gameObject);

            

            ScoreManeger.GetComponent<ScoreManeger>().Addscore(10);
        }
        else if(other.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }


    }
}
