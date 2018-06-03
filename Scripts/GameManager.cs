using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private bool updateFlag;
	private GameObject playerObj, baseObj, backgroundObj1, backgroundObj2;
	private Player player;
	private Base base1;
	private BackGround background1;
	private BackGround background2;

	// Use this for initialization
	void Start () {
		updateFlag = false;
		//オブジェクト取得
		playerObj = GameObject.Find ("Player");
		baseObj = GameObject.Find ("Base");
		backgroundObj1 = GameObject.Find ("BackGround1");
		backgroundObj2 = GameObject.Find ("BackGround2");
		//スクリプト取得
		player = playerObj.GetComponent<Player>();
		base1 = baseObj.GetComponent<Base>();
		background1 = backgroundObj1.GetComponent<BackGround>();
		background2 = backgroundObj2.GetComponent<BackGround>();
	}
	
	// Update is called once per frame
	void Update () {
		if(updateFlag == true)
		{
			updateFlag = false;
			screenUpdate();
		}
	}

	void screenUpdate() {
		player.screenUpdate();
		base1.screenUpdate();
		background1.screenUpdate();
		background2.screenUpdate();
	}	

	public void setUpdateFlag() {
		updateFlag = true;
	}
}
