using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridCell : MonoBehaviour {

	public GameObject roomHolder;

	// Use this for initialization
	void Start () {
		buildRoom(roomHolder);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void buildRoom (GameObject roomHolder) {
		GameObject newRoom = Instantiate(roomHolder, new Vector3(transform.position.x, -0.5f, transform.position.z), transform.rotation);
		newRoom.transform.SetParent(transform);
	}
}
