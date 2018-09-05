using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiController : MonoBehaviour {
    //移動速度
    private float spd = -0.17f;
    //消滅位置
    private float deadLine = -10;

	// Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //移動させる
        transform.Translate(this.spd, 0, 0);
        //画面外に出たら破棄する
        if(transform.position.x < this.deadLine){
            Destroy(gameObject);
        }
	}
}
