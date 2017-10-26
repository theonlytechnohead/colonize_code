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
			currentRoom = Instantiate(room.prefab, transform.position, transform.rotation);
			currentRoom.transform.SetParent(transform);
			currentRoom.transform.position += new Vector3(0f, 2f, 0f);
		}
	}
}
