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

	}

	public void buildRoom (GameObject roomHolder) {
		newRoom = Instantiate(roomHolder, new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z), transform.rotation);
		newRoom.layer = gameObject.layer;
		//newRoom.transform.SetParent(transform);
		//newRoom.transform.position += new Vector3(0f, 0.5f, 0f);
	}

	void OnMouseOver () {
		if (Input.GetKeyDown(KeyCode.Delete)) {
			Destroy(gameObject);
		}
	}
	void OnMouseDown () {
		if(EventSystem.current.IsPointerOverGameObject()) {
			// we're over a UI element... peace out
			return;
    	}
		if (buildPanelController.instance.selectedTool != null) {
			if (buildPanelController.instance.selectedTool.name == "Foundation") {
				if (newRoom == null) {
					buildRoom(roomHolder);
					renderer.material.color = builtColour;
				}
			}	
		}
	}
	void OnMouseEnter () {
		if (buildPanelController.instance.selectedTool != null) {
			if (buildPanelController.instance.selectedTool.name == "Foundation") {
				if (newRoom == null) {
					renderer.material.color = highlightColour;
				}
			}
		}
	}
    void OnMouseExit () {
		if (newRoom == null) {
			renderer.material.color = normalColour;
		}
    }
}
