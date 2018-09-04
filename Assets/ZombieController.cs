using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {
    //HP
    private int HP;
    //アニメーションするためのコンポーネントを入れる
    Animator animator;
    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;
    //地面の位置
    private float groundLevel = -3.0f;
    //ジャンプの速度の減衰
    private float dump = 0.8f;
    //ジャンプの速度
    float jumpVelocity = 20;
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
        this.animator = GetComponent<Animator>();
        //Rigidbody2Dのコンポーネントを取得する
        this.rigid2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
        //?
        this.enemy = GameObject.Find("EnemyPrefab");
        if(this.isEnd){
            Destroy(enemy);
        }

        //待機アニメーションを再生するために、Animatorのパラメータを調整する
        this.animator.SetFloat("Vertical", -1);
        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);

        //着地状態でshiftを押された場合
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        //shiftを離したら上方向への速度を減速する
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }
	}

    //?HPが1以下になったらisEndがtrueになるところまで確認。そこからEnemyPrefabを減衰する方法がわからない
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyTag" && this.HP > 1){
            this.HP--;
        }else{
            this.isEnd = true;
        }
    }
}
