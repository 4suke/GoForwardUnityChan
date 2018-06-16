using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

    //ボールを発射させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    //unityのゲームオブジェクトを宣言
    private GameObject unity;

    //ボールの発射速度
    private float velocityX = 8;
    private float velocityY = 20;

    // ボールの速度の減衰
    private float dump = 0.8f;



    // Use this for initialization
    void Start ()
    {
        // Rigidbody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //弾発射の力をかける
        this.rigid2D.velocity = new Vector2(velocityX, velocityY);
        if (Input.GetMouseButton(0) == false)
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }




    }
}
