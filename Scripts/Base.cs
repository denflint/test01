using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

	private GameObject Player;

	// Use this for initialization
	void Start () {
		//Playerの情報を取得
		Player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if( Player.GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0) )
   		transform.position = new Vector2(0, 0);
	}
}
