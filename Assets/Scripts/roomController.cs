using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class roomController : MonoBehaviour {

	public GameObject currentRoom;
	public Room room;
	public List<Tool> compatibleTools;
	private Renderer renderer;

	public Color normalColour;
	public Color highlightColour;
	public Color builtColour;

	float counter = 0f;
	
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		transform.position += new Vector3(0f, 0.25f, 0f);
		
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter >= 1f) {
			roomGenerate();
			counter = 0f;
		}
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

	void roomGenerate () {
		if (room.generator != null) {
			room.generator.Generate();
		}
	}

	void OnMouseDown () {
		if (EventSystem.current.IsPointerOverGameObject()) {
			// we're over a UI element... peace out
			return;
    	}
		if (buildPanelController.instance.selectedTool != null) {
			if (CheckCompatibleTool()) {
				if (currentRoom == null) {
					if (room.resourceRequired == gameController.instance.rhypherium) {
						if (gameController.instance.rhypherium.amount >= room.resourceAmount) {
							buildRoom(room.prefab);
							renderer.material.color = builtColour;
							gameController.instance.rhypherium.amount -= room.resourceAmount;
						}
					} else if (room.resourceRequired == gameController.instance.kironide) {
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
			if (CheckCompatibleTool()) {
				renderer.material.color = highlightColour;
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

	bool CheckCompatibleTool () {
		foreach (Tool compatibleTool in compatibleTools) {
			if (buildPanelController.instance.selectedTool == compatibleTool) {
				return true;
			}
		}
		return false;
	}
}
