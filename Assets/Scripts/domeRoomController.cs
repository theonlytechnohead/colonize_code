using System.Collections;
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
				currentRoom = Instantiate(roomToBuild, new Vector3(0f, transform.position.y, 0f), Quaternion.Euler(-90f, transform.rotation.eulerAngles.y + (360 / 32), 180f));
				currentRoom.layer = gameObject.layer;
				currentRoom.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, 29f);
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
					if (room.resourceRequired = gameController.instance.rhypherium) {
						if (gameController.instance.rhypherium.amount >= room.resourceAmount) {
							buildRoom(room.prefab);
							renderer.material.color = builtColour;
							gameController.instance.rhypherium.amount -= room.resourceAmount;
						}
					} else if (room.resourceRequired = gameController.instance.kironide) {
						if (gameController.instance.kironide.amount >= room.resourceAmount) {
							buildRoom(room.prefab);
							renderer.material.color = builtColour;
							gameController.instance.kironide.amount -= room.resourceAmount;
						}
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
