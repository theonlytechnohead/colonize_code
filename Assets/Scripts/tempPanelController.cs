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

		outsideTemp.text = Mathf.RoundToInt(Mathf.Abs(outTempFinal)).ToString();
		insideTemp.text = Mathf.RoundToInt(Mathf.Abs(inTempFinal)).ToString();
	}
}
