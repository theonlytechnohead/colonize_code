using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomController : MonoBehaviour {

	public GameObject currentRoom;
	public Room room;
	new private Renderer renderer;
	
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void buildRoom (Room roomToBuild) {
			if (room != null & currentRoom == null) {
				currentRoom = Instantiate(roomToBuild.prefab, transform.position, transform.rotation);
				currentRoom.transform.SetParent(transform);
				currentRoom.transform.position += new Vector3(0f, 2f, 0f);
		}
	}

	void OnMouseDown () {
		if (currentRoom == null) {
			buildRoom(room);
			renderer.material.color = Color.gray;
		}
	}
	void OnMouseEnter () {
		if (currentRoom == null) {
			renderer.material.color = Color.yellow;
		}
	}
    void OnMouseExit () {
		if (currentRoom == null) {
			renderer.material.color = Color.white;
		}
    }
}
