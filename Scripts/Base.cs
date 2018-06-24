using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

	private GameObject playerObj, gameManagerObj;		//各オブジェクト
	private Rigidbody2D playerRb2D;				//各rb
	private Vector2 newPosition;				//生成位置
	public GameObject prefab;					//プレハブ
	private bool createFlag;					//1:新しいプレハブ生成可能
	private GameManager gameManagerScr;			//

	// Use this for initialization
	void Start () {
		//Playerの情報を取得
		playerObj = GameObject.Find ("Player");
		playerRb2D = playerObj.GetComponent<Rigidbody2D>();
		gameManagerObj = GameObject.Find ("GameManager");
		gameManagerScr = gameManagerObj.GetComponent<GameManager>();

		createFlag = true;
	}
	
	// Update is called once per frame
	void Update () {

		if( (transform.position.y - playerObj.transform.position.y) < -3f )
			Destroy(gameObject);
	}

	void OnTriggerStay2D(Collider2D Player) {
		// プレハブからインスタンスを生成
		if(createFlag && (playerRb2D.velocity == Vector2.zero) )
		{
			createFlag = false;
			gameManagerScr.setUpdateFlag();
			createBase();
			
		}
	}

	void createBase() {
		//生成位置決定
		newPosition = new Vector2(Random.Range(-2f, 2f), Random.Range(5f, 9f) + playerObj.transform.position.y);
		var Obj =  Instantiate(prefab, newPosition, Quaternion.identity);
		Obj.name = prefab.name;
	}
}
