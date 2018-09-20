using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour {
    //計算用スコア
    private int score = 0;
    //スコア用表示テキスト
    private Text scoreText;
 
    //swordのprefab
    public GameObject slashingPrefab;
    GameObject go;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //左クリックで表示
        if (Input.GetMouseButtonUp(0))
        {
            GameObject Zombie = GameObject.Find("zombie");
            go = Instantiate(slashingPrefab, Zombie.transform) as GameObject;
            Destroy(go, 0.1f);
        }
		
	}
}