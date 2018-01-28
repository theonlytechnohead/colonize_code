using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class dialogueDisplay : MonoBehaviour {

	public TextMeshProUGUI UI;
	public Dialogue dialogue;
	bool fadeIn = false;
	bool fadeOut = false;

	// Use this for initialization
	void Start () {
		StartCoroutine(displayText());
	}

	void Update () {
		if (fadeIn) {
			UI.color = Color.Lerp(UI.color, Color.white, Time.deltaTime);
		} else if (fadeOut) {
			UI.color = Color.Lerp(UI.color, Color.clear, Time.deltaTime);
		}
	}

	IEnumerator displayText () {
		foreach (string text in dialogue.dialogue) {
			UI.text = text;
			fadeIn = true;
			yield return new WaitForSeconds(1.5f);
			fadeIn = false;
			yield return new WaitForSeconds(text.Length / 20f);
			fadeOut = true;
			yield return new WaitForSeconds(1.5f);
			fadeOut = false;
		}
		SceneManager.LoadScene("main");
	}
}
