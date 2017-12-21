using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class gridCell : MonoBehaviour {

	public GameObject defaultStructure;
	public GameObject roomHolder;
	new private Renderer renderer;
	private GameObject newRoom;

	public Color normalColour;
	public Color highlightColour;
	public Color builtColour;

	// Use this for initialization
	void Start () {
		buildRoom(defaultStructure);
		renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (buildPanelController.instance.visible) {
			GetComponent<MeshRenderer>().enabled = true;
		} else {
			GetComponent<MeshRenderer>().enabled = false;
		}
	}

	public void buildRoom (GameObject roomHolder) {
		newRoom = Instantiate(roomHolder, new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z), transform.rotation);
		newRoom.layer = gameObject.layer;
		//newRoom.transform.SetParent(transform);
		//newRoom.transform.position += new Vector3(0f, 0.5f, 0f);
	}

	void OnMouseDown () {
		if(EventSystem.current.IsPointerOverGameObject()) {
			// we're over a UI element... peace out
			return;
    	}
		if (buildPanelController.instance.selectedTool != null) {
			if (buildPanelController.instance.selectedTool.name == "Foundation") {
				if (newRoom == null) {
					if (gameController.instance.kironide > 10f) {
						buildRoom(roomHolder);
						renderer.material.color = builtColour;
						gameController.instance.kironide -= 10f;
					} else {
						// Error feedback somehow stuff can't be bothered right now though
					}
				}
			}	
		}
	}
	void OnMouseOver () {
		if (buildPanelController.instance.selectedTool != null) {
			if (buildPanelController.instance.selectedTool.name == "Foundation") {
				if (newRoom == null) {
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
		if (newRoom == null) {
			renderer.material.color = normalColour;
		}
    }
}
