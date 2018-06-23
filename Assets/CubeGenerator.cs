using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    //キューブのprefab
    public GameObject cubePrefab;

    
     //キューブ2のprefab
     public GameObject cube2Prefab;
     

    //時間計測用の変数
    private float delta = 0;

    //キューブの生成間隔
    private float span = 0.5f;

    //キューブの生成位置：X座標
    private float genPosX = 34;

    //キューブの生成位置オフセット
    private float offsetY = 0.3f;

    //キューブの縦方向の間隔
    private float spaceY = 6.9f;

    //キューブの生成位置オフセット
    private float offsetX = 0.2f;

    //キューブの横方向の間隔
    private float spaceX= 0.4f;

    //キューブの生成個数の上限
    private int maxBlockNum = 6;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.delta += Time.deltaTime;
        
        //span秒以上の時間が経過したかを調べる
        if(this.delta > this.span)
        {
            this.delta = 0;
            //生成するキューブ数をランダムに決める
            int n = Random.Range(2, maxBlockNum + 1);

            //指定した数だけキューブを作成する
            for (int i = 0; i < n; i++) 
            {
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(0, 10);
                if (num <= 8)
                {
                    //キューブの作成
                    GameObject go = Instantiate(cubePrefab) as GameObject;
                    go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
                }
                else
                {
                    //キューブ2の作成
                    GameObject go = Instantiate(cube2Prefab) as GameObject;
                    go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
                }
            }
            //次のキューブまでの生成時間を決める
            this.span = this.offsetX + this.spaceX * n;

        }

	}
}
