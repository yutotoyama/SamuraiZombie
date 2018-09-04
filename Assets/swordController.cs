using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("test");
        //enemyに攻撃した場合
        if(other.gameObject.tag == "EnemyTag"){
            //攻撃が当たったらenemyが消える
            Destroy(other.gameObject);
        }
    }
}
