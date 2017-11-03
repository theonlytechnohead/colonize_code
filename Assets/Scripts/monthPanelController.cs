using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class monthPanelController : MonoBehaviour {

	public Vector2 normalPosition;
	public Vector2 hiddenPosition;
	public GameObject monthInfoPanel;
	public Text timeText;

	private bool mouseOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mouseOver) {
			monthInfoPanel.transform.position = Vector3.Lerp(monthInfoPanel.transform.position, normalPosition, 10f * Time.deltaTime);
		} else {
			monthInfoPanel.transform.position = Vector3.Lerp(monthInfoPanel.transform.position, hiddenPosition, 10f * Time.deltaTime);
		}
		timeText.text = "Time: " + gameController.instance.time;
	}

	public void SetMouseOverState (bool state) {
		mouseOver = state;
	}
}
