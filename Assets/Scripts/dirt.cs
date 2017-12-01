using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dirt : MonoBehaviour {

	public Color normalColour;
	public Color highlightColour;
	private Renderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		transform.position += new Vector3(0f, 1.5f, 0f);
	}

	void OnMouseDown () {
		if(EventSystem.current.IsPointerOverGameObject()) {
			// we're over a UI element... peace out
			return;
    	}
		if (buildPanelController.instance.selectedTool != null) {
			if (buildPanelController.instance.selectedTool.name == "Dig") {
				Destroy(gameObject);
			}
		}		
	}
	void OnMouseEnter () {
		renderer.material.color = highlightColour;
	}
    void OnMouseExit () {
		renderer.material.color = normalColour;
    }
}
