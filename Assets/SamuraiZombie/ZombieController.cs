using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {
    //HP
    private float HP;
    //アニメーションするためのコンポーネントを入れる
    Animator animator;
    //playerを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;
    //ゲーム終了の判定
    public bool isEnd = false;
    //動きを減速させる係数
    private float coefficient = 0.95f;

    private GameObject enemy;

	// Use this for initialization
	void Start () {
        //HPを入れる
        this.HP = 3;
        //アニメータのコンポーネントを取得する
        animator = GetComponent<Animator>();
        //Rigidbody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

        //構え
        if(Input.GetMouseButtonDown(0)){
            GetComponent<Animator>().SetTrigger("SetUpTrigger");
        }else if (Input.GetMouseButtonUp(0)){
            //攻撃
            GetComponent<Animator>().SetTrigger("AttackTrigger");
            GetComponent<Animator>().SetTrigger("IdleTrigger");
        }
	}

    //?HPが1以下になったらisEndがtrueになるところまで確認。そこからEnemyPrefabを減衰する方法がわからない
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyTag" && this.HP > 1){
            this.HP--;
        }else if(other.gameObject.tag == "EnemyTag" && this.HP <= 1){
            this.isEnd = true;
            Debug.Log("test");
        }
    }
}
