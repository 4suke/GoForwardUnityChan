using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SphereController : MonoBehaviour {

    //ボールを発射させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    //unityのゲームオブジェクトを宣言
    private GameObject unity;
    private GameObject Particle;
    private GameObject ScoreManeger;
    private GameObject Hitting;

    //ボールの発射速度
    private float powerX = 5;
    private float powerY = 15;

    // ボールの速度の減衰
    private float dump = 0.8f;

    



    // Use this for initialization
    void Start ()
    {
        
        // Rigidbody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.AddForce(new Vector2(powerX, powerY), ForceMode2D.Impulse);

        this.ScoreManeger = GameObject.Find("ScoreManeger");
        this.Particle = GameObject.Find("ParticleGenerator");
        this.Hitting = GameObject.Find("Hit");
    }

    // Update is called once per frame
    void Update ()
    {
        // クリックをやめたら上方向への速度を減速する
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                /*
                this.rigid2D.velocity *= this.dump;
                */
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "block")
        {

            Particle.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            //接触したオブジェクトを破棄
            Destroy(other.gameObject);
            Destroy(gameObject);
           



            ScoreManeger.GetComponent<ScoreManeger>().Addscore(10);
            Particle.GetComponent<ParticleGenerator>().Particle();
            Hitting.GetComponent<Hit>().HitSound();
        }
        else if(other.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }


    }
}
