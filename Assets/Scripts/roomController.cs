using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class roomController : MonoBehaviour {

	public GameObject currentRoom;
	public Room room;
	private Renderer renderer;

	public Color normalColour;
	public Color highlightColour;
	public Color builtColour;
	
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		transform.position += new Vector3(0f, 0.25f, 0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void buildRoom (GameObject roomToBuild) {
			if (room != null & currentRoom == null) {
				currentRoom = Instantiate(roomToBuild, new Vector3(transform.position.x, transform.position.y + 2.25f, transform.position.z), transform.rotation);
				//currentRoom.transform.SetParent(transform);
				//currentRoom.transform.position += new Vector3(0f, 2f, 0f);
				currentRoom.layer = gameObject.layer;
				for (int child = 0; child < currentRoom.transform.childCount; child++) {
					currentRoom.transform.GetChild(child).gameObject.layer = gameObject.layer;
				}
		}
	}

	void OnMouseDown () {
		if (EventSystem.current.IsPointerOverGameObject()) {
			// we're over a UI element... peace out
			return;
    	}
		if (buildPanelController.instance.selectedTool != null) {
			if (buildPanelController.instance.selectedTool.name == "Room") {
				if (currentRoom == null) {
					buildRoom(room.prefab);
					renderer.material.color = builtColour;
				}
			}
		}
	}
	void OnMouseOver () {
		if (buildPanelController.instance.selectedTool != null) {
			if (buildPanelController.instance.selectedTool.name == "Room") {
				if (currentRoom == null) {
					renderer.material.color = highlightColour;
				}
			} else {
				renderer.material.color = normalColour;
			}
		} else {
			renderer.material.color = normalColour;
		}
		if (EventSystem.current.IsPointerOverGameObject()) {
			renderer.material.color = normalColour;
    	}
	}
    void OnMouseExit () {
		if (currentRoom == null) {
			renderer.material.color = normalColour;
		}
    }
}
