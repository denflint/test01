using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

	private string textToEdit = "";					//デバッグ
	private string debugText = "";
	private string debugText2 = "";
	public float speed = 5;							//移動速度
	private Vector2 startPos, endPos, distance;		//移動処理用
	private Rigidbody2D rb2D;						//rb
	private float moveTime = 0;						//移動時間(distance有効時間)
	private Vector2 originPos;						//スタート地点

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D>();
		originPos = transform.position;
	}
	// Update is called once per frame
	void Update () {

		GetMousePosition();

		if(rb2D.velocity == Vector2.zero)
			GetMouseDistance();

		//時間管理
		if(rb2D.velocity != Vector2.zero)
			moveTime ++;
		if(rb2D.velocity == Vector2.zero)
			moveTime = 0;
	}

	void FixedUpdate() {
			MovePlayer();
	}
	void OnGUI () {
	// テキストエリアを表示する
		textToEdit = GUI.TextArea(new Rect(10, 10, 100, 20), textToEdit);
		debugText = GUI.TextArea(new Rect(10, 40, 100, 20), debugText);
		debugText2 = GUI.TextArea(new Rect(10, 70, 100, 20), debugText2);
	}

	void GetMousePosition () {

		textToEdit = "(" + rb2D.velocity.x.ToString() + "," + rb2D.velocity.y.ToString() + ")"; 
	}

	void GetMouseDistance () {
		if(Input.GetMouseButtonDown(0))
		{
			//start_pos = Input.mousePosition;
			startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		if(Input.GetMouseButtonUp(0))
		{
			//end_pos = Input.mousePosition;
			endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//距離計算
			distance = startPos - endPos;

		}

		//更新
		debugText = "time:" + moveTime;


	}

	void MovePlayer () {		
		rb2D.AddForce(speed * (distance - rb2D.velocity));
		//debugText2 = "(" + distance.x.ToString() + "," + distance.y.ToString() + ")"; 
		//debugText2 = "(" + Screen.width + "," + Screen.height + ")"; 
		debugText2 = "(" + transform.position.x + "," + transform.position.y + ")"; 
		//原則開始
		if(moveTime > 50f)
			distance -= distance / speed;
		//微妙に進むのを止める(速度が0.0...ぐらいになると止める)
		if( ((-0.5 < rb2D.velocity.x) && (rb2D.velocity.x < 0.5) && 
			 (-0.5 < rb2D.velocity.y) && (rb2D.velocity.y < 0.5)) &&
			 (moveTime > 50f) )
		{
			distance = Vector2.zero;
		}

	}
}
