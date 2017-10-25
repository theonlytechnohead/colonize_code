﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour {

	public Color timeActivatedColour;
	public Color normalColour;

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
			if (Time.timeScale == 0f) {
				NormalTime();
			}
			else {
				PauseTime();
			}
		}
	}
	
	public void TripleTime () {
		Time.timeScale = 3f;
		ResetColours();
		GameObject.Find("TripleSpeedButton").GetComponent<Image>().color = timeActivatedColour;
	}

	public void DoubleTime () {
		Time.timeScale = 2f;
		ResetColours();
		GameObject.Find("DoubleSpeedButton").GetComponent<Image>().color = timeActivatedColour;
	}

	public void NormalTime () {
		Time.timeScale = 1f;
		ResetColours();
		GameObject.Find("NormalSpeedButton").GetComponent<Image>().color = timeActivatedColour;
	}

	public void PauseTime () {
		Time.timeScale = 0f;
		ResetColours();
		GameObject.Find("PauseButton").GetComponent<Image>().color = timeActivatedColour;
	}

	public void ResetColours () {
		GameObject.Find("TripleSpeedButton").GetComponent<Image>().color = normalColour;
		GameObject.Find("DoubleSpeedButton").GetComponent<Image>().color = normalColour;
		GameObject.Find("NormalSpeedButton").GetComponent<Image>().color = normalColour;
		GameObject.Find("PauseButton").GetComponent<Image>().color = normalColour;
	}
}