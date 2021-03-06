﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridLayout : MonoBehaviour {

	public GameObject gridObject;
	public float cellWidthX;
	public float cellHeightZ;

	public int rows;
	public int columns;

	void Awake () {
		transform.position = new Vector3(0f, -5f, 0f);
		buildGrid("B1");
		transform.position = new Vector3(0f, -10f, 0f);
		buildGrid("B2");
		transform.position = new Vector3(0f, 0f, 0f);
		transform.localScale = new Vector3(50f, 1f, 50f);
		Destroy(this);
	}

	void buildGrid (string cullingLayerMask) {
		for (int cellRow = -rows; cellRow <= rows; cellRow++) {
			for (int cell = -columns; cell <= columns; cell++) {
				if ((-5f < cellRow && cellRow < 5f) && (-3f < cell && cell < 3f)) {
					// It's the basement, don't build over it!
				} else {
					Vector3 spawnPos = new Vector3(cellWidthX * cell, transform.position.y + 0.1f, cellHeightZ * cellRow);
					GameObject clone = Instantiate(gridObject, spawnPos, transform.rotation);
					clone.layer = LayerMask.NameToLayer(cullingLayerMask);
					//clone.transform.SetParent(transform);
					//clone.transform.position = new Vector3(spawnPos.x, -3.5f, spawnPos.z);
				}
			}
		}
	}
}