using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridLayout : MonoBehaviour {

	public GameObject gridObject;
	public float cellWidthX;
	public float cellHeightZ;

	public int rows;
	public int columns;

	void Awake () {
		transform.position = new Vector3(0f, -4f, 0f);
		buildGrid();
	}

	void buildGrid () {
		for (int cellRow = -rows; cellRow <= rows; cellRow++) {
			for (int cell = -columns; cell <= columns; cell++) {
				Vector3 spawnPos = new Vector3(cellWidthX * cell, 0f, cellHeightZ * cellRow);
				GameObject clone = Instantiate(gridObject, spawnPos, transform.rotation);
				clone.transform.SetParent(transform);
				clone.transform.position = new Vector3(spawnPos.x, -3.5f, spawnPos.z);
			}
		}
	}
}