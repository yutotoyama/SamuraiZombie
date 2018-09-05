using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiGenerator : MonoBehaviour {
    //敵のprefab
    public GameObject samuraiPrefab;
    //時間計測用の変数
    private float delta = 0;
    //敵の生成間隔
    private float span = 1.0f;
    //敵の生成位置:X座標
    private float genPosX = 12;
    //敵の生成位置オフセット
    private float offsetX = 0.5f;
    //敵の横方向の間隔
    private float spaceX = 0.4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        //span秒以上の時間が経過したか調べる
        if(this.delta > this.span){
            this.delta = 0;
            //敵の生成
            GameObject go = Instantiate(samuraiPrefab) as GameObject;
        }
        //次の敵までの生成時間を決める
        this.span = this.offsetX + this.spaceX;
	}
}
