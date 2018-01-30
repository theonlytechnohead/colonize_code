using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gridCell : MonoBehaviour {

	public GameObject defaultStructure;
	public GameObject roomHolder;
	public List<Tool> compatibleTools;
	private Renderer rdr;
	private GameObject childGameObject;
	private Room childRoom;

	public Color normalColour;
	public Color highlightColour;
	public Color builtColour;

	float counter = 0f;

	// Use this for initialization
	void Start () {
		buildGameObject(defaultStructure);
		rdr = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (buildPanelController.instance.visible) {
			GetComponent<MeshRenderer>().enabled = true;
		} else {
			GetComponent<MeshRenderer>().enabled = false;
		}

		counter += Time.deltaTime;
		if (counter >= 1f) {
			if (childRoom != null) {
				GeneratorGenerate(childRoom);
			}
			counter = 0f;
		}
	}

	public void buildGameObject (GameObject gameObjectToBuild) {
		childGameObject = Instantiate(gameObjectToBuild, new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z), transform.rotation);
		childGameObject.layer = gameObject.layer;
		//newRoom.transform.SetParent(transform);
		//newRoom.transform.position += new Vector3(0f, 0.5f, 0f);
	}

	public void buildRoom (Room roomToBuild) {
		childGameObject = Instantiate(roomToBuild.prefab, new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z), transform.rotation);
		childGameObject.layer = gameObject.layer;
		childRoom = roomToBuild;
		//newRoom.transform.SetParent(transform);
		//newRoom.transform.position += new Vector3(0f, 0.5f, 0f);
	}

	void GeneratorGenerate (Room room) {
		if (room.generator != null) {
			room.generator.Generate();
		}
	}

	void OnMouseDown () {
		if(EventSystem.current.IsPointerOverGameObject()) {
			// we're over a UI element... peace out
			return;
    	}
		if (buildPanelController.instance.selectedTool != null) {
			if (CheckCompatibleTool()) {
				if (buildPanelController.instance.selectedTool.roomToBuild != null) {
					buildRoom(buildPanelController.instance.selectedTool.roomToBuild);
				} else {
					buildGameObject(buildPanelController.instance.selectedTool.thingToBuild);
				}
			}
		}
	}
	void OnMouseOver () {
		if (buildPanelController.instance.selectedTool != null) {
			if (CheckCompatibleTool()) {
				rdr.material.color = highlightColour;
			}
		} else {
			rdr.material.color = normalColour;
		}
		if (EventSystem.current.IsPointerOverGameObject()) {
			rdr.material.color = normalColour;
    	}
	}
    void OnMouseExit () {
		rdr.material.color = normalColour;
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
