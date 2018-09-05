using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    //swordのprefab
    public GameObject swordPrefab;
    GameObject go;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //returnで表示
        if (Input.GetKeyDown("return"))
        {
            GameObject unitychan = GameObject.Find("UnityChan2D");
            go = Instantiate(swordPrefab, unitychan.transform) as GameObject;
        }

        //returnを離す
        if (Input.GetKeyUp("return"))
        {
            Destroy(go);
        }
		
	}
}
