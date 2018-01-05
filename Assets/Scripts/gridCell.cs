using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gridCell : MonoBehaviour {

	public GameObject defaultStructure;
	public GameObject roomHolder;
	public List<Tool> compatibleTools;
	new private Renderer renderer;
	private GameObject childGameObject;
	private Room childRoom;

	public Color normalColour;
	public Color highlightColour;
	public Color builtColour;

	float counter = 0f;

	// Use this for initialization
	void Start () {
		buildGameObject(defaultStructure);
		renderer = GetComponent<Renderer>();
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
			foreach (Tool compatibleTool in compatibleTools) {
				if (buildPanelController.instance.selectedTool == compatibleTool) {
					if (childGameObject == null) {
						if (gameController.instance.kironide.amount > 10f) {
							if (compatibleTool.roomToBuild != null) {
								buildRoom(compatibleTool.roomToBuild);
							} else {
								buildGameObject(compatibleTool.thingToBuild);
							}
							renderer.material.color = builtColour;
							gameController.instance.kironide.amount -= 10f;
						} else {
							// Error feedback somehow stuff can't be bothered right now though
						}
					}
				}
			}
		}
	}
	void OnMouseOver () {
		if (buildPanelController.instance.selectedTool != null) {
			foreach (Tool compatibleTool in compatibleTools) {
				if (buildPanelController.instance.selectedTool == compatibleTool) {
					renderer.material.color = highlightColour;
				} else {
					renderer.material.color = normalColour;
				}
			}
		} else {
			renderer.material.color = normalColour;
		}
		if (EventSystem.current.IsPointerOverGameObject()) {
			renderer.material.color = normalColour;
    	}
	}
    void OnMouseExit () {
		if (childGameObject == null) {
			renderer.material.color = normalColour;
		}
    }
}
