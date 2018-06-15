using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour {

    //spherePrefabを入れる
    private GameObject spherePrefab;

    //時間計測用の変数
    private float delta = 0;
    //ボールの生成間隔
    private float span = 1.0f;

    //ボールの生成位置：X, Y座標
    private float x = 0;
    private float y = 0;
    //unityのゲームオブジェクトを宣言
    private GameObject unity;
    //unityから生成アイテムの距離を宣言
    private int i = 0;

    

    
    
    // ボールの発射速度X
    float throwXVelocity = 4;
    // ボールの発射速度Y
    float throwYVelocity = 20;

    //ボールを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //unitychanのオブジェクトを取得
        unity = GameObject.Find("UnityChan2D");
        x = unity.transform.position.x;
        y = unity.transform.position.y;
        // Rigidbody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();

        if (Input.GetMouseButtonDown(0) )
        {
            //ボールを生成する
            GameObject sphere = Instantiate(spherePrefab) as GameObject;
            sphere.transform.position = new Vector2(x, y + i);
            // ボール発射の力をかける
            this.rigid2D.velocity = new Vector2(throwXVelocity, throwYVelocity);
           
        }

    }
}
