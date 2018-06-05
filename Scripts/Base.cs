using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

	private GameObject player;			//プレイヤー参照用
	private Rigidbody2D playerRb2D;		//プレイヤーのrb
	private Vector2 newPosition;		//次の足場の生成位置
	public GameObject prefab;			//プレハブ生成
	private bool createFlag;			//1:新しいプレハブ生成可能

	// Use this for initialization
	void Start () {
		//Playerの情報を取得
		player = GameObject.Find ("Player");
		playerRb2D = player.GetComponent<Rigidbody2D>();

		createFlag = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D Player) {
		// プレハブからインスタンスを生成
		if(createFlag && (playerRb2D.velocity == Vector2.zero) )
		{
			createFlag = false;
			newPosition = new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(0, 10f) + playerRb2D.transform.position.y);
			Instantiate(prefab, newPosition, Quaternion.identity);
		}
	}
}
