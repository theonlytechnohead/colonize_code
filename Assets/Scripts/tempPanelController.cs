﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class tempPanelController : MonoBehaviour {

	public Text outsideTemp;
	public Text outsideIndicator;
	public Text insideTemp;
	public Text insideIndicator;
	public Text celciusIndicator;
	public Text fahrenheitIndicator;
	public Text heatIndicator;


	public GameObject temperatureInfoPanel;
	public GameObject normalPosition;
	public GameObject hiddenPosition;
	[HideInInspector]
	public bool venting;
	[HideInInspector]
	public bool heating;

	public Color activeColour;
	public Color normalColour;

	public bool stupidTempSystem = false;

	private float outTemp;
	private float inTemp;

	private bool mouseOver;

	#region Singleton
	public static tempPanelController instance;

	private void Awake () {
		if (instance != null) {
			Debug.LogWarning("More than one instance of tempPanelController found!");
			return;
		}
		instance = this;
	}
	#endregion

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		outTemp = gameController.instance.outsideTemperature;
		inTemp = gameController.instance.insideTemperature;
		float outTempFinal = outTemp;
		float inTempFinal = inTemp;
		if (stupidTempSystem) {
			outTempFinal = gameController.instance.outsideTemperature * 1.8f + 32f;
			inTempFinal = gameController.instance.insideTemperature * 1.8f + 32f;
		}
		if (outTempFinal > 0) {
			outsideIndicator.text = "+";
		}
		if (outTempFinal == 0) {
			outsideIndicator.text = "";
		}
		if (outTempFinal < 0) {
			outsideIndicator.text = "-";
		}
		if (inTempFinal > 0) {
			insideIndicator.text = "+";
		}
		if (inTempFinal == 0) {
			insideIndicator.text = "";
		}
		if (inTempFinal < 0) {
			insideIndicator.text = "-";
		}

		if (venting) {
			heatIndicator.text = "<";
		} else if (heating) {
			heatIndicator.text = ">";
		} else {
			heatIndicator.text = "|";
		}

		outsideTemp.text = Mathf.RoundToInt(Mathf.Abs(outTempFinal)).ToString();
		insideTemp.text = Mathf.RoundToInt(Mathf.Abs(inTempFinal)).ToString();

		if (mouseOver) {
			temperatureInfoPanel.transform.position = Vector3.Lerp(temperatureInfoPanel.transform.position, normalPosition.transform.position, 10f * Time.deltaTime);
		} else {
			temperatureInfoPanel.transform.position = Vector3.Lerp(temperatureInfoPanel.transform.position, hiddenPosition.transform.position, 10f * Time.deltaTime);
		}
	}
	public void SetMouseOverState (bool state) {
		mouseOver = state;
	}
	public void Vent () {
		ResetColours();
		GameObject.Find("ventButton").GetComponent<Image>().color = activeColour;
		venting = true;
		heating = false;
	}
	public void Heat () {
		ResetColours();
		GameObject.Find("heatButton").GetComponent<Image>().color = activeColour;
		heating = true;
		venting = false;
	}
	public void Stop () {
		ResetColours();
		GameObject.Find("stopButton").GetComponent<Image>().color = activeColour;
		venting = false;
		heating = false;
	}
	public void ResetColours () {
		EventSystem.current.SetSelectedGameObject(null);
		GameObject.Find("ventButton").GetComponent<Image>().color = normalColour;
		GameObject.Find("heatButton").GetComponent<Image>().color = normalColour;
		GameObject.Find("stopButton").GetComponent<Image>().color = normalColour;
	}
}
