using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class confirm : MonoBehaviour {

	public GameObject confirmPrefab;
	private GameObject confirmObject;
	private bool confirmYes = false;
	private bool confirmNo = false;
	private bool toReturn;

	#region Singleton
	public static confirm instance;

	private void Awake () {
		if (instance != null) {
			Debug.LogWarning("More than one instance of confirm found!");
			return;
		}
		instance = this;
	}
	#endregion

	#region Usage
	/*
		StartCoroutine(confirm.instance.check("Test?", (returnedValue) => {
			Debug.Log("Returned " + returnedValue);
		}));
	*/
	#endregion

	public IEnumerator check (string text, System.Action<bool> callback) {
		if (confirmObject != null) {
			yield return false;
		}
		confirmYes = false;
		confirmNo = false;
		confirmObject = Instantiate(confirmPrefab);
		confirmObject.transform.SetParent(GameObject.Find("Canvas").transform, false);
		GameObject.Find("confirmText").GetComponent<TextMeshProUGUI>().text = text;
		GameObject.Find("yesButton").GetComponent<Button>().onClick.AddListener(yesButtonClicked);
		GameObject.Find("noButton").GetComponent<Button>().onClick.AddListener(noButtonClicked);
		while (confirmYes == false && confirmNo == false) {
			yield return null;
		}
		if (confirmYes) {
			callback(true);
		} else if (confirmNo) {
			callback(false);
		} else {
			callback(false);
		}
		Destroy(confirmObject);
	}

	void yesButtonClicked () {
		confirmYes = true;
	}

	void noButtonClicked () {
		confirmNo = true;
	}
}
