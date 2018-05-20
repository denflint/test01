using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

	private string textToEdit = "";
	private string debugtext = "";
	public float speed = 5;
	private Vector2 vec;
	private Vector2 now_pos, start_pos, end_pos, distance, move_result;
	
	// Use this for initialization
	void Start () {
		now_pos = transform.position;
		move_result = transform.position;
	}
	// Update is called once per frame
	void Update () {

		GetMousePosition();
		GetMouseDistance();

		MovePlayer();

		
	}
	void OnGUI () {
	// テキストエリアを表示する
		textToEdit = GUI.TextArea(new Rect(10, 10, 200, 20), textToEdit);
		debugtext = GUI.TextArea(new Rect(10, 40, 200, 20), debugtext);
	}

	void GetMousePosition () {

		textToEdit = "(" + distance.x.ToString() + "," + distance.y.ToString() + ")"; 
	}

	void GetMouseDistance () {
		if(Input.GetMouseButtonDown(0)){
			//start_pos = Input.mousePosition;
			start_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		if(Input.GetMouseButtonUp(0)){
			//end_pos = Input.mousePosition;
			end_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			
			distance = start_pos - end_pos;
			move_result = distance + now_pos;
		}

		//更新
		debugtext = "(" + now_pos.x.ToString() + "," + now_pos.y.ToString() + ")";

	}

	void MovePlayer () {
		// 右・左
	    float x = Input.GetAxisRaw ("Horizontal");
	    // 上・下
	    float y = Input.GetAxisRaw ("Vertical");
	    // 移動する向きを求める
	    Vector2 direction = new Vector2 (x, y).normalized;
	    // 移動する向きとスピードを代入する
	    GetComponent<Rigidbody2D>().velocity = direction * speed;
	    
	    //クリックした位置に移動
	    if(Input.GetMouseButton(0)){
			//vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//transform.position = new Vector2( vec.x, vec.y );	
		}

		transform.position = Vector2.MoveTowards(transform.position, new Vector2(move_result.x, move_result.y), speed *Time.deltaTime); 
		//transform.position = Vector2.MoveTowards(transform.position, new Vector2(vec.x,vec.y), speed *Time.deltaTime); 

		now_pos = move_result;
	}
}
