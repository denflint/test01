using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

	private GameObject player;			//プレイヤーオブジェクト
	private Rigidbody2D playerRb2D;		//プレイヤーrb
	private Vector2 newPosition;		//生成位置
	public GameObject prefab;			//プレハブ
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

		if( (transform.position.y - player.transform.position.y) < -3f )
			Destroy(gameObject);
	}

	void OnTriggerStay2D(Collider2D Player) {
		// プレハブからインスタンスを生成
		if(createFlag && (playerRb2D.velocity == Vector2.zero) )
		{
			createFlag = false;
			newPosition = new Vector2(Random.Range(-2f, 2f), Random.Range(5f, 9f) + player.transform.position.y);
			var Obj =  Instantiate(prefab, newPosition, Quaternion.identity);
			Obj.name = prefab.name;
		}
	}
}
