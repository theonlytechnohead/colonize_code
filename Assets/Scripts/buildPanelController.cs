using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buildPanelController : MonoBehaviour {

	public bool visible = false;
	public Transform hiddenPosition;
	public Transform normalPosition;
	public Tool selectedTool;

	public List<Tool> tools;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			toggleVisibility();
		}
		if (visible) {
			transform.position = Vector3.Lerp(transform.position, normalPosition.position, 10f * Time.deltaTime);
			GameObject.Find("buildPanelButtonText").GetComponent<Text>().text = "X";
		} else {
			transform.position = Vector3.Lerp(transform.position, hiddenPosition.position, 10f * Time.deltaTime);
			GameObject.Find("buildPanelButtonText").GetComponent<Text>().text = "▲";
		}
	}

	public void SelectTool (Tool toolToSelect) {
		selectedTool = toolToSelect;
	}

	public void toggleVisibility () {
		visible = !visible;
		ResetColour();
	}

	void ResetColour () {
		EventSystem.current.SetSelectedGameObject(null);
	}
}
