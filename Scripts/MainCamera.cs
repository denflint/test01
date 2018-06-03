using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

	public GameObject player;
	private float offset;		//開始位置のオフセット
	private bool moveFlag;		//1:移動可能

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		offset = this.transform.position.y - player.transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate () {
		transform.position = new Vector3(0, player.transform.position.y +offset, -10);
	}
}
