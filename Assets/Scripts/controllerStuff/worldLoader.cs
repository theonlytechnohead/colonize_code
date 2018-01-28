using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class worldLoader : MonoBehaviour {

	public GameObject loadFadePanel;
	public Image panel;
	Color targetColour = Color.clear;

	void Start () {
		DontDestroyOnLoad(gameObject);
	}

	void Update () {
		if (panel != null) {
			panel.color = Color.Lerp(panel.color, targetColour, 1.25f * Time.deltaTime);
		}
	}

	public void loadScene (string sceneName) {
		panel = loadFadePanel.AddComponent<Image>();
		panel.color = Color.clear;
		targetColour = Color.black;
		StartCoroutine(waitThenLoad(sceneName));
	}

	IEnumerator waitThenLoad (string sceneName) {
		yield return new WaitForSeconds(2.5f);
		SceneManager.LoadScene(sceneName);
		fadeOut();
	}

	void fadeOut () {
		targetColour = Color.clear;
		Destroy(gameObject, 2.5f);
		Destroy(loadFadePanel, 2.5f);
	}
}