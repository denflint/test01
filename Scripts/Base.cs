using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

	private GameObject player;
	private Rigidbody2D playerRb2D;
	private Vector2 newPosition;
	public GameObject prefab;
	private bool createFlag;		//1:新しいプレハブ生成可能
	private GameObject[] baseArray = new GameObject[2];	//プレハブ保存用

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
