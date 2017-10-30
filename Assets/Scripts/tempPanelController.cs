using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempPanelController : MonoBehaviour {

	public Text outsideTemp;
	public Text outsideIndicator;
	public Text insideTemp;
	public Text insideIndicator;
	public Text celciusIndicator;
	public Text fahrenheitIndicator;

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
			outsideIndicator.text = "+";
		}
		if (outTemp == 0) {
			outsideIndicator.text = "";
		}
		if (outTemp < 0) {
			outsideIndicator.text = "-";
		}
		if (inTemp > 0) {
			insideIndicator.text = "+";
		}
		if (inTemp == 0) {
			insideIndicator.text = "";
		}
		if (inTemp < 0) {
			insideIndicator.text = "-";
		}
		float outTempF = outTemp;
		float inTempF = inTemp;
		if (stupidTempSystem) {
			outTempF = gameController.instance.outsideTemperature * 1.8f + 32f;
			inTempF = gameController.instance.insideTemperature * 1.8f + 32f;
		}
		outsideTemp.text = Mathf.RoundToInt(Mathf.Abs(outTempF)).ToString();
		insideTemp.text = Mathf.RoundToInt(Mathf.Abs(inTempF)).ToString();
	}
}
