using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    //swordのprefab
    public GameObject slashingPrefab;
    GameObject go;

	// Use this for initialization
	void Start () {
		
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