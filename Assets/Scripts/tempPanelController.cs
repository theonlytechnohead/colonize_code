using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempPanelController : MonoBehaviour {

	public Text outsideTemp;
	public Text outsideTempPositive;
	public Text outsideTempNegative;
	public Text insideTemp;
	public Text insideTempPositive;
	public Text insideTempNegative;
	public Text celciusIndicator;
	public Text fahrenheitIndicator;

	public Color activeColour;
	public Color inactiveColour;

	[HideInInspector]
	public bool stupidTempSystem = false;

	private float outTemp;
	private float inTemp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		outTemp = gameController.instance.outsideTemperature;
		inTemp = gameController.instance.insideTemperature;
		if (outTemp > 0) {
			outsideTempPositive.color = activeColour;
			outsideTempNegative.color = inactiveColour;
		}
		if (outTemp == 0) {
			outsideTempPositive.color = inactiveColour;
			outsideTempNegative.color = inactiveColour;
		}
		if (outTemp < 0) {
			outsideTempPositive.color = inactiveColour;
			outsideTempNegative.color = activeColour;
		}
		if (inTemp > 0) {
			insideTempPositive.color = activeColour;
			insideTempNegative.color = inactiveColour;
		}
		if (inTemp == 0) {
			insideTempPositive.color = inactiveColour;
			insideTempNegative.color = inactiveColour;
		}
		if (inTemp < 0) {
			insideTempPositive.color = inactiveColour;
			insideTempNegative.color = activeColour;
		}
		float outTempF = outTemp;
		float inTempF = inTemp;
		if (stupidTempSystem) {
			outTempF = gameController.instance.outsideTemperature * 1.8f + 32f;
			inTempF = gameController.instance.insideTemperature * 1.8f + 32f;
		}
		outsideTemp.text = Mathf.Abs(outTempF).ToString();
		insideTemp.text = Mathf.Abs(inTempF).ToString();
	}
}
