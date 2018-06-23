using UnityEngine;
using System.Collections;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator animator;

    //Unityちゃんを移動させるコンポーネントを入れる（追加）
    Rigidbody2D rigid2D;

    // 地面の位置
    private float groundLevel = -3.0f;

    // ジャンプの速度の減衰（追加）
    private float dump = 0.6f;

    // ジャンプの速度（追加）
    float jumpVelocity = 30;

    //ゲームオーバになる位置
    private float deadLine = -20.5f;



    // Use this for initialization
    void Start()
    {
        // アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        // Rigidbody2Dのコンポーネントを取得する（追加）
        this.rigid2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        // 走るアニメーションを再生するために、Animatorのパラメータを調節する
        this.animator.SetFloat("Horizontal", 1);

        // 着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);


        //ジャンプ状態の時にはボリュームを0にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        // 着地状態でクリックされた場合
        if (Input.GetMouseButtonDown(1) && isGround)
        {
            // 上方向の力をかける（追加）
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        // クリックをやめたら上方向への速度を減速する（追加）
        if (Input.GetMouseButton(1) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
        //デッドラインをぉ江田場青ゲームオーバにする
        if (transform.position.x < this.deadLine)
        {
            //UIControllerのGameOver関数を呼び出して画面上に「GemeOver」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //ユニティちゃんを破棄する
            Destroy(gameObject);
        }
    }
}
