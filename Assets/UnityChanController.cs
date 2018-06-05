using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    Animator animator;
    //地面の位置
    private float groundLevel = 3.0f;
	// Use this for initialization
	void Start ()
    {
        //アニメーターのコンポーネントを取得する
        this.animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        //走るアニメーションを再生するためにAnimatorのパラメータを調節する
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("IsGround", isGround);
	}
}
