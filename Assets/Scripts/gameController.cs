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

	[Range(-130, 20)]
	public int outsideTemperature = -55;
	[Range(-30, 30)]
	public int insideTemperature = 20;

	#region Singleton
	public static gameController instance;

	private void Awake () {
		if (instance != null) {
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}
		instance = this;
	}
	#endregion

	// Use this for initialization
	void Start () {
		NormalTime();
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
	}

	public void TripleTime () {
		warpSpeed = 4;
		ResetColours();
		GameObject.Find("TripleSpeedButton").GetComponent<Image>().color = timeActivatedColour;
	}

	public void DoubleTime () {
		warpSpeed = 2;
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