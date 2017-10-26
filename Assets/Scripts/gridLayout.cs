using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridLayout : MonoBehaviour {

	public GameObject gridObject;
	public float cellWidthX;
	public float cellHeightZ;

	public int rows;
	public int columns;

	// Use this for initialization
	void Start () {
		for (int cellRow = -rows; cellRow <= rows; cellRow++) {
			for (int cell = -columns; cell <= columns; cell++) {
				Vector3 spawnPos = new Vector3(cellWidthX * cell, 0f, cellHeightZ * cellRow);
				GameObject clone = Instantiate(gridObject, spawnPos, transform.rotation);
				clone.transform.SetParent(transform);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
