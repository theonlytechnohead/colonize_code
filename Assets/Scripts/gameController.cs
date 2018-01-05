using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class gameController : MonoBehaviour {

	public Color timeActivatedColour;
	public Color normalColour;

	// Level
	public List<LayerMask> levelMask;
	public int currentLevel = 0;
	public GameObject levelText;
	public List<string> levelNames;

	// Time
	public int warpSpeed = 1;
	public List<Month> months;
	public GameObject monthText;
	private Month currentMonth;
	private int month = 4;

	public int time = 0;
	public float dayProgress = 0f;
	private float addTime;

	public Light sun;

	// Resources
	public Resource oxygen;
	public Resource water;
	public Resource food;
	public Resource power;
	public Resource kironide;
	public Resource rhypherium;


	[HideInInspector]
	public int outsideTemperature;
	[HideInInspector]
	public int insideTemperature;

	#region Singleton
	public static gameController instance;

	private void Awake () {
		if (instance != null) {
			Debug.LogWarning("More than one instance of gameController found!");
			return;
		}
		instance = this;
	}
	#endregion

	// Use this for initialization
	void Start () {
		NormalTime();
		currentMonth = months[month];
		monthText.GetComponent<TextMeshProUGUI>().text = currentMonth.name;
		UpdateTemperature();
		time = 500;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (buildPanelController.instance.visible) {
				if (buildPanelController.instance.selectedTool != null) {
					buildPanelController.instance.SelectButton(null);
					buildPanelController.instance.SelectTool(null);
				} else {
					buildPanelController.instance.toggleVisibility();
				}
			} else {
				Application.Quit();
			}
		}
		if (Input.GetKeyDown("1")) {
			NormalTime();
		}
		if (Input.GetKeyDown("2")) {
			DoubleTime();
		}
		if (Input.GetKeyDown("3")) {
			TripleTime();
		}
		if (Input.GetKeyDown("space")) {
			if (warpSpeed == 0) {
				NormalTime();
			}
			else {
				PauseTime();
			}
		}
		if (Input.GetKeyDown(KeyCode.PageUp)) {
			if (currentLevel > 0) {
				currentLevel--;
			}
			cameraController.mainCamera.cullingMask = levelMask[currentLevel];
			levelText.GetComponent<TextMeshProUGUI>().text = levelNames[currentLevel];
		}
		if (Input.GetKeyDown(KeyCode.PageDown)) {
			if (currentLevel < levelMask.Count - 1) {
				currentLevel++;
			}
			cameraController.mainCamera.cullingMask = levelMask[currentLevel];
			levelText.GetComponent<TextMeshProUGUI>().text = levelNames[currentLevel];
		}

		addTime += Time.deltaTime * warpSpeed;
		if (addTime >= 1f) {
			if (time < 999) {
				time++;
				if (time % 5 == 0) {
					UpdateTemperature();
				}
				addTime = 0f;
			} else {
				time = 0;
				if (month < 11) {
					month++;
				} else {
					month = 0;
				}
			}
		}
		if (time <= 500) {
			dayProgress = (time / 1000f) * 2f;
		} else {
			dayProgress = Mathf.Abs((time - 1000) / 1000f) * 2f;
		}

		currentMonth = months[month];
		monthText.GetComponent<TextMeshProUGUI>().text = currentMonth.name;
		sun.intensity = dayProgress;
		//sun.intensity = 0.01f;

		// Resource stuffs
		oxygen.amount = Mathf.Clamp(oxygen.amount, 0f, oxygen.maxAmount);
		oxygen.amount = Mathf.Round(oxygen.amount * 100f) / 100f;

		water.amount = Mathf.Clamp(water.amount, 0f, water.maxAmount);
		water.amount = Mathf.Round(water.amount * 100f) / 100f;

		food.amount = Mathf.Clamp(food.amount, 0f, food.maxAmount);
		food.amount = Mathf.Round(food.amount * 100f) / 100f;

		power.amount = Mathf.Clamp(power.amount, 0f, power.maxAmount);
		power.amount = Mathf.Round(power.amount * 100f) / 100f;

		kironide.amount = Mathf.Clamp(kironide.amount, 0f, kironide.maxAmount);
		kironide.amount = Mathf.Round(kironide.amount * 100f) / 100f;

		rhypherium.amount = Mathf.Clamp(rhypherium.amount, 0f, rhypherium.maxAmount);
		rhypherium.amount = Mathf.Round(rhypherium.amount * 100f) / 100f;
	}

	void UpdateTemperature () {
		float newOutTemp = Mathf.Lerp(currentMonth.minTemp, currentMonth.maxTemp, dayProgress) + Random.Range(-3f, 3f);
		float newInTemp = insideTemperature;
		newInTemp = Mathf.Lerp(newInTemp, newOutTemp, Time.deltaTime);
		if (tempPanelController.instance.venting) {
			if (power.amount > 0.1f) {
				newInTemp -= Random.Range(2f, 4f);
				power.amount -= 0.1f;
				tempPanelController.instance.updateLights();
			} else {
				tempPanelController.instance.errorLight("vent");
			}
		} else if (tempPanelController.instance.heating) {
			if (power.amount > 1f) {
				newInTemp += Random.Range(1.5f, 4f);
				power.amount -= 1f;
				tempPanelController.instance.updateLights();
			} else {
				tempPanelController.instance.errorLight("heat");
			}
		} else {
			tempPanelController.instance.updateLights();
		}
		outsideTemperature = Mathf.RoundToInt(newOutTemp);
		insideTemperature = Mathf.RoundToInt(newInTemp);
	}

	public void TripleTime () {
		warpSpeed = 100;
		ResetColours();
		GameObject.Find("TripleSpeedButton").GetComponent<Image>().color = timeActivatedColour;
	}

	public void DoubleTime () {
		warpSpeed = 10;
		ResetColours();
		GameObject.Find("DoubleSpeedButton").GetComponent<Image>().color = timeActivatedColour;
	}

	public void NormalTime () {
		warpSpeed = 1;
		ResetColours();
		GameObject.Find("NormalSpeedButton").GetComponent<Image>().color = timeActivatedColour;
	}

	public void PauseTime () {
		warpSpeed = 0;
		ResetColours();
		GameObject.Find("PauseButton").GetComponent<Image>().color = timeActivatedColour;
	}

	public void ResetColours () {
		EventSystem.current.SetSelectedGameObject(null);
		GameObject.Find("TripleSpeedButton").GetComponent<Image>().color = normalColour;
		GameObject.Find("DoubleSpeedButton").GetComponent<Image>().color = normalColour;
		GameObject.Find("NormalSpeedButton").GetComponent<Image>().color = normalColour;
		GameObject.Find("PauseButton").GetComponent<Image>().color = normalColour;
	}
}