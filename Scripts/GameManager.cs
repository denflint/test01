using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Text scoreText;
	private GameObject playerObj;
	private float startPos, nowPos;
	private float score, position;
	private bool updateFlag;
	// Use this for initialization
	void Start () {
		playerObj = GameObject.Find("Player");
		startPos = playerObj.transform.position.y;
		score = 0.0f;
		updateFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (updateFlag == true) {
			//現在の位置取得
			nowPos = (Mathf.Floor(playerObj.transform.position.y * 10f)) / 10f;
			updateScore();	
		}
	}

	void updateScore () {
		if (score == nowPos) {
			updateFlag = false;
		}
		else {
			score = (Mathf.Floor((score + 0.1f)* 10f)) / 10f;
			scoreText.text = score.ToString("N1") + "cm ";
		}
	}

	public void setUpdateFlag() {
		updateFlag = true;
	}
}
