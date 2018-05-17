using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {

	private string textToEdit = "TextArea";
	private float mouse_x, mouse_y;
	public float speed = 5;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		Vector3 mousePosition = Input.mousePosition;
		mouse_x = mousePosition.x;
		mouse_y = mousePosition.y;

		textToEdit = "(" + mouse_x.ToString() + "," + mouse_y.ToString() + ")";

		// 右・左
	    float x = Input.GetAxisRaw ("Horizontal");
	    // 上・下
	    float y = Input.GetAxisRaw ("Vertical");
	    // 移動する向きを求める
	    Vector2 direction = new Vector2 (x, y).normalized;
	    // 移動する向きとスピードを代入する
	    GetComponent<Rigidbody2D>().velocity = direction * speed;

	}
	void OnGUI () {
	// テキストエリアを表示する
		textToEdit = GUI.TextArea(new Rect(10, 10, 200, 20), textToEdit);
	}
}
