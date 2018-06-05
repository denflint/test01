using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

	private GameObject CameraObj;		//カメラオブジェクト
	private MainCamera CameraScr;		//カメラスクリプト
	// Use this for initialization
	void Start () {
		CameraObj = GameObject.Find("Main Camera");
		CameraScr = CameraObj.GetComponent<MainCamera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y - CameraObj.transform.position.y < -10.5f ) {
			transform.position = new Vector3 (0, 10.5f + CameraObj.transform.position.y, 0);
		}
	}
}
