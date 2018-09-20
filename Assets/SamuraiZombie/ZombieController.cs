using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //ジャンプの速度の減衰
    private float dump = 0.8f;
    //ジャンプの速度
    float jumpVelocity = 20;

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
        }else if (Input.GetMouseButtonUp(0) && this.rigid2D.velocity.y <= 0)
        {
            //攻撃
            GetComponent<Animator>().SetTrigger("AttackTrigger");
            GetComponent<Animator>().SetTrigger("IdleTrigger");
        }
        else if(Input.GetMouseButton(0)){
            GetComponent<Animator>().SetTrigger("JumpAttackTrigger");
        }

        //ジャンプ
        if(Input.GetKeyDown(KeyCode.Space)){
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        }

        //クリックやめたらジャンプ減衰
        if(Input.GetKey(KeyCode.Space) == false){
            if(this.rigid2D.velocity.y > 0){
                this.rigid2D.velocity *= this.dump;
                GetComponent<Animator>().SetTrigger("IdleTrigger");
            }
        }
	}

    //?HPが1以下になったらisEndがtrueになるところまで確認。そこからEnemyPrefabを減衰する方法がわからない
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyTag" && this.HP > 1){
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHP();
            this.HP--;
        }else if(other.gameObject.tag == "EnemyTag" && this.HP <= 1){
            this.isEnd = true;
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
