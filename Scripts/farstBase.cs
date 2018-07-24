using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farstBase : MonoBehaviour {
	private GameObject playerObj;
	private Player playerScr;
	private Rigidbody2D playerRb2D;				//各rb

	// Use this for initialization
	void Start () {
		playerObj = GameObject.Find ("Player");
		playerRb2D = playerObj.GetComponent<Rigidbody2D>();
		playerScr = playerObj.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D Player) {
		// プレハブからインスタンスを生成
		if (playerRb2D.velocity == Vector2.zero) 
		{
			playerScr.setLoadFlag(false);
		}
	}
	void OnTriggerExit2D(Collider2D Other) {
		playerScr.setLoadFlag(true);
	}
}
