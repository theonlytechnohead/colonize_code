using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class tempPanelController : MonoBehaviour {

	public TextMeshProUGUI outsideTemp;
	public TextMeshProUGUI outsideIndicator;
	public TextMeshProUGUI insideTemp;
	public TextMeshProUGUI insideIndicator;
	public TextMeshProUGUI celciusIndicator;
	public TextMeshProUGUI fahrenheitIndicator;
	public TextMeshProUGUI pumpIndicator;


	public GameObject temperatureInfoPanel;
	public GameObject normalPosition;
	public GameObject hiddenPosition;
	[HideInInspector]
	public bool venting;
	[HideInInspector]
	public bool heating;
	private bool error = false;


	private ColorBlock activeColourBlock;
	private ColorBlock normalColourBlock;
	public Color panelDefaultColour;
	public Color activeColour;
	public Color normalColour;
	public Color errorColour;

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
		normalColourBlock = GameObject.Find("NormalSpeedButton").GetComponent<Button>().colors;
		normalColourBlock.normalColor = normalColour;
		Stop();
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
			pumpIndicator.text = "<";
		} else if (heating) {
			pumpIndicator.text = ">";
		} else {
			pumpIndicator.text = "|";
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
		GameObject.Find("ventButton").GetComponent<Image>().color = Color.green;
		activeColourBlock = GameObject.Find("ventButton").GetComponent<Button>().colors;
		activeColourBlock.normalColor = activeColour;
		GameObject.Find("ventButton").GetComponent<Button>().colors = activeColourBlock;
		venting = true;
		heating = false;
	}
	public void Heat () {
		ResetColours();
		GameObject.Find("heatButton").GetComponent<Image>().color = Color.green;
		activeColourBlock = GameObject.Find("heatButton").GetComponent<Button>().colors;
		activeColourBlock.normalColor = activeColour;
		GameObject.Find("heatButton").GetComponent<Button>().colors = activeColourBlock;
		heating = true;
		venting = false;
	}
	public void Stop () {
		ResetColours();
		GameObject.Find("stopButton").GetComponent<Image>().color = Color.green;
		activeColourBlock = GameObject.Find("stopButton").GetComponent<Button>().colors;
		activeColourBlock.normalColor = activeColour;
		GameObject.Find("stopButton").GetComponent<Button>().colors = activeColourBlock;
		venting = false;
		heating = false;
	}
	public void errorLight (string button) {
		GameObject.Find(button + "Button").GetComponent<Image>().color = errorColour;
		error = true;
		GetComponent<Image>().color = errorColour;
		notificationPanelController.instance.AddNotification("Temperature management system", "Temperature adjustments failed! Make sure you have enough power to run the system");
	}
	public void updateLights () {
		if (!error) {
			if (venting || heating) {
				GetComponent<Image>().color = Color.green;
			} else {
				GetComponent<Image>().color = panelDefaultColour;
			}
		}
		if (venting) {
			GameObject.Find("ventButton").GetComponent<Image>().color = Color.green;
		} else if (heating) {
			GameObject.Find("ventButton").GetComponent<Image>().color = Color.green;
		} else {
			GameObject.Find("stopButton").GetComponent<Image>().color = Color.green;
		}
	}
	public void ResetColours () {
		EventSystem.current.SetSelectedGameObject(null);
		GameObject.Find("ventButton").GetComponent<Image>().color = Color.white;
		GameObject.Find("heatButton").GetComponent<Image>().color = Color.white;
		GameObject.Find("stopButton").GetComponent<Image>().color = Color.white;
		GameObject.Find("ventButton").GetComponent<Button>().colors = normalColourBlock;
		GameObject.Find("heatButton").GetComponent<Button>().colors = normalColourBlock;
		GameObject.Find("stopButton").GetComponent<Button>().colors = normalColourBlock;
		error = false;
	}
}
