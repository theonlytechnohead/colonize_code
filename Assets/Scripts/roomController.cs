using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomController : MonoBehaviour {

	public GameObject currentRoom;
	public Room room;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (room != null & currentRoom == null) {
			currentRoom = Instantiate(room.prefab, new Vector3(transform.position.x, -1.5f, transform.position.z), transform.rotation);
		}
	}
}
