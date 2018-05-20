﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour {

	public GameObject bombPrefab;
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.RightControl)) {
			Vector2 pos = transform.position;
			pos.x = Mathf.Round (pos.x);
			pos.y = Mathf.Round (pos.y);
			Instantiate (bombPrefab, pos, Quaternion.identity);
		}
	}
}
