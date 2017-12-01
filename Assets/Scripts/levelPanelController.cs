using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class levelPanelController : MonoBehaviour {

	public GameObject normalPosition;
	public GameObject hiddenPosition;
	public GameObject levelInfoPanel;
	public GameObject levelText;
	public GameObject outsideText;
	public GameObject L3Text;
	public GameObject L2Text;
	public GameObject L1Text;
	public GameObject GroundText;
	public GameObject B1Text;
	public GameObject B2Text;
	public GameObject selectImage;

	private bool mouseOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mouseOver) {
			levelInfoPanel.transform.position = Vector3.Lerp(levelInfoPanel.transform.position, normalPosition.transform.position, 10f * Time.deltaTime);
			if (gameController.instance.levelNames[gameController.instance.currentLevel] == "Outside") {
				selectImage.transform.position = outsideText.transform.position;
				if (levelText.transform.position.y > outsideText.transform.position.y) {
					levelText.transform.position = outsideText.transform.position;
				}
			} else if (gameController.instance.levelNames[gameController.instance.currentLevel] == "L3") {
				selectImage.transform.position = L3Text.transform.position;
				if (levelText.transform.position.y > L3Text.transform.position.y) {
					levelText.transform.position = L3Text.transform.position;
				}
			} else if (gameController.instance.levelNames[gameController.instance.currentLevel] == "L2") {
				selectImage.transform.position = L2Text.transform.position;
				if (levelText.transform.position.y > L2Text.transform.position.y) {
					levelText.transform.position = L2Text.transform.position;
				}
			} else if (gameController.instance.levelNames[gameController.instance.currentLevel] == "L1") {
				selectImage.transform.position = L1Text.transform.position;
				if (levelText.transform.position.y > L1Text.transform.position.y) {
					levelText.transform.position = L1Text.transform.position;
				}
			} else if (gameController.instance.levelNames[gameController.instance.currentLevel] == "Ground") {
				selectImage.transform.position = GroundText.transform.position;
				if (levelText.transform.position.y > GroundText.transform.position.y) {
					levelText.transform.position = GroundText.transform.position;
				}
			} else if (gameController.instance.levelNames[gameController.instance.currentLevel] == "B1") {
				selectImage.transform.position = B1Text.transform.position;
				if (levelText.transform.position.y > B1Text.transform.position.y) {
					levelText.transform.position = B1Text.transform.position;
				}
			} else if (gameController.instance.levelNames[gameController.instance.currentLevel] == "B2") {
				selectImage.transform.position = B2Text.transform.position;
				if (levelText.transform.position.y > B2Text.transform.position.y) {
					levelText.transform.position = B2Text.transform.position;
				}
			}
		} else {
			levelInfoPanel.transform.position = Vector3.Lerp(levelInfoPanel.transform.position, hiddenPosition.transform.position, 10f * Time.deltaTime);
			if (gameController.instance.levelNames[gameController.instance.currentLevel] == "Outside") {
				selectImage.transform.position = outsideText.transform.position;
				if (levelText.transform.position.y < GetComponent<Transform>().position.y) {
					levelText.transform.position = outsideText.transform.position;
				} else {
					levelText.transform.position = GetComponent<Transform>().position;
				}
			} else if (gameController.instance.levelNames[gameController.instance.currentLevel] == "L3") {
				selectImage.transform.position = L3Text.transform.position;
				if (levelText.transform.position.y < GetComponent<Transform>().position.y) {
					levelText.transform.position = L3Text.transform.position;
				} else {
					levelText.transform.position = GetComponent<Transform>().position;
				}
			} else if (gameController.instance.levelNames[gameController.instance.currentLevel] == "L2") {
				selectImage.transform.position = L2Text.transform.position;
				if (levelText.transform.position.y < GetComponent<Transform>().position.y) {
					levelText.transform.position = L2Text.transform.position;
				} else {
					levelText.transform.position = GetComponent<Transform>().position;
				}
			} else if (gameController.instance.levelNames[gameController.instance.currentLevel] == "L1") {
				selectImage.transform.position = L1Text.transform.position;
				if (levelText.transform.position.y < GetComponent<Transform>().position.y) {
					levelText.transform.position = L1Text.transform.position;
				} else {
					levelText.transform.position = GetComponent<Transform>().position;
				}
			} else if (gameController.instance.levelNames[gameController.instance.currentLevel] == "Ground") {
				selectImage.transform.position = GroundText.transform.position;
				if (levelText.transform.position.y < GetComponent<Transform>().position.y) {
					levelText.transform.position = GroundText.transform.position;
				} else {
					levelText.transform.position = GetComponent<Transform>().position;
				}
			} else if (gameController.instance.levelNames[gameController.instance.currentLevel] == "B1") {
				selectImage.transform.position = B1Text.transform.position;
				if (levelText.transform.position.y < GetComponent<Transform>().position.y) {
					levelText.transform.position = B1Text.transform.position;
				} else {
					levelText.transform.position = GetComponent<Transform>().position;
				}
			} else if (gameController.instance.levelNames[gameController.instance.currentLevel] == "B2") {
				selectImage.transform.position = B2Text.transform.position;
				if (levelText.transform.position.y < GetComponent<Transform>().position.y) {
					levelText.transform.position = B2Text.transform.position;
				} else {
					levelText.transform.position = GetComponent<Transform>().position;
				}
			}
		}
	}

	public void SetMouseOverState (bool state) {
		mouseOver = state;
	}
}
