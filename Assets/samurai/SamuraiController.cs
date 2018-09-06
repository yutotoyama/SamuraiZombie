using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiController : MonoBehaviour {
    //アニメーションするためのコンポーネントを入れる
    Animator animator;
    //移動速度
    private float spd = -0.17f;
    //消滅位置
    private float deadLine = -10;

	// Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        //移動させる
        transform.Translate(this.spd, 0, 0);
        //画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }
    //SlashingTagに当たったらdamageアニメーション表示
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "SlashingTag"){
            GetComponent<Animator>().SetTrigger("DamageTrigger");
            Debug.Log("test");
            Destroy(gameObject, 0.1f);
        }
    }
}