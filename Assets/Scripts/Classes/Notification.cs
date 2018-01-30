using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notification : MonoBehaviour {

	public string time;
	public string title;
	public string content;
	private TextMeshProUGUI textComponent;

	void Start () {
		textComponent = GetComponent<TextMeshProUGUI>();
	}

	void Update () {
		textComponent.text = time + title + content;
	}
}
