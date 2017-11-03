using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class gameController : MonoBehaviour {

	public Color timeActivatedColour;
	public Color normalColour;

	public List<LayerMask> levelMask;
	public int currentLevel = 0;
	public GameObject levelText;
	public List<string> levelNames;

	public int warpSpeed = 1;
	public List<Month> months;
	public Text monthText;
	private Month currentMonth;
	private int month = 4;

	public int time = 0;
	private float addTime;

	public Light sun;

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
		monthText.text = currentMonth.name;
		UpdateTemperature();
	}
	
	// Update is called once per frame
	void Update () {
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
			levelText.GetComponent<Text>().text = levelNames[currentLevel];
		}
		if (Input.GetKeyDown(KeyCode.PageDown)) {
			if (currentLevel < levelMask.Count - 1) {
				currentLevel++;
			}
			cameraController.mainCamera.cullingMask = levelMask[currentLevel];
			levelText.GetComponent<Text>().text = levelNames[currentLevel];
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
		currentMonth = months[month];
		monthText.text = currentMonth.name;
		sun.intensity = time / 1000f;
		//sun.intensity = 0.01f;
	}

	void UpdateTemperature () {
		float newOutTemp = Mathf.Lerp(currentMonth.minTemp, currentMonth.maxTemp, time / 1000) + Random.Range(-3f, 3f);
		float newInTemp = insideTemperature;
		newInTemp = Mathf.Lerp(newInTemp, newOutTemp, Time.deltaTime);
		if (tempPanelController.instance.venting) {
			newInTemp -= Random.Range(1f, 3f);
		} else if (tempPanelController.instance.heating) {
			newInTemp += Random.Range(1f, 3f);
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