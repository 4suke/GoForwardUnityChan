using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -0.15f;

    //消滅位置
    private float deadLine = -20;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        //キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        /*
        //地面かブロックと接触してなければ音量を0にする
        if(OnCollisonEnter()S = )
        GetComponent<AudioSource>().volume = 0;
        */

        //画面外に出たら破棄する
        if(transform.position.x <this.deadLine)
        {
            Destroy(gameObject);
        }

		
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "block" || other.gameObject.tag == "ground")
        {
             
            GetComponent<AudioSource>().Play();
        }


    }
}
