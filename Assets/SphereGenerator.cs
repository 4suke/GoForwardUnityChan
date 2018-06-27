using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour {

    //spherePrefabを入れる
    public GameObject spherePrefab;

    //時間計測用の変数
    private float delta = 0;
    //ボールの生成間隔
    private float span = 1.0f;

    //ボールの上昇速度の減衰
    private float dump = 0.6f;

    //ボールの生成位置：X, Y座標
    private float x = 0;
    private float y = 0;

    

    //unityのゲームオブジェクトを宣言
    private GameObject unity;

    //ボールが打てなくなるペナルティタイム
    private int penalty = 10;

    //ペナルティの残りタイム(秒)。これが0でないときは弾が打てない。
    float m_penaltyTime;

    [SerializeField] GameObject m_penaltyTimeText;


    // Use this for initialization
    void Start()
    {
        //unitychanのオブジェクトを取得
        unity = GameObject.Find("UnityChan2D");

    }

    // Update is called once per frame
    void Update()
    {

        x = unity.transform.position.x;
        y = unity.transform.position.y;


        if (m_penaltyTime > 0)
        {
            m_penaltyTime -= Time.deltaTime;
            m_penaltyTimeText.GetComponent<UnityEngine.UI.Text>().text = m_penaltyTime.ToString();

        }
        else
        {

            if (Input.GetMouseButtonUp(0))
            {
                //ボールを生成する
                GameObject sphere = Instantiate(spherePrefab) as GameObject;
                sphere.transform.position = new Vector2(x, y);
               
            }
        }

    }

    public void AddPenaltyTime(float seconds)
    {
        this.m_penaltyTime += seconds;
    }
    //発射する力を計算
    public void ThrowForce(float powerX)
    {
        if (Input.GetMouseButton(0))
        {
            powerX += Time.deltaTime;
            Debug.Log("force");
        }
        
    }
}
