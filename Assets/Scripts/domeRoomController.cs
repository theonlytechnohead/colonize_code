﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class domeRoomController : MonoBehaviour {

	public GameObject currentRoom;
	public Room room;
	private MeshRenderer renderer;

	public Color normalColour;
	public Color highlightColour;
	public Color builtColour;
	
	void Start () {
		renderer = GetComponent<MeshRenderer>();
		renderer.material.color = normalColour;
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
					if (gameController.instance.rhypherium > room.cost) {
						buildRoom(room.prefab);
						renderer.material.color = builtColour;
						gameController.instance.rhypherium -= room.cost;
					}
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