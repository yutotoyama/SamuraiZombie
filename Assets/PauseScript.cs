using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour{

    [SerializeField]
    //ポーズした時に表示するUIのプレハブ
    private GameObject pauseUIPrefab;
    //ポーズUIのインスタンス
    private GameObject pauseUIInstance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("q")){
            if(pauseUIInstance == null){
                pauseUIInstance = Instantiate(pauseUIPrefab) as GameObject;
                Time.timeScale = 0f;
            }else{
                Destroy(pauseUIInstance);
                Time.timeScale = 1f;
            }
        }
	}
}
