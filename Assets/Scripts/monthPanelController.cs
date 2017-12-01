using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class monthPanelController : MonoBehaviour {

	public GameObject normalPosition;
	public GameObject hiddenPosition;
	public GameObject monthInfoPanel;
	public GameObject timeText;

	private bool mouseOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mouseOver) {
			monthInfoPanel.transform.position = Vector3.Lerp(monthInfoPanel.transform.position, normalPosition.transform.position, 10f * Time.deltaTime);
		} else {
			monthInfoPanel.transform.position = Vector3.Lerp(monthInfoPanel.transform.position, hiddenPosition.transform.position, 10f * Time.deltaTime);
		}
		timeText.GetComponent<TextMeshProUGUI>().text = "Time: " + gameController.instance.time;
	}

	public void SetMouseOverState (bool state) {
		mouseOver = state;
	}
}
