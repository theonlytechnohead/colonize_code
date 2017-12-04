using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class resourcePanelController : MonoBehaviour {

	public bool visible = false;
	public Transform hiddenPosition;
	public Transform normalPosition;

	#region Singleton
	public static resourcePanelController instance;

	private void Awake () {
		if (instance != null) {
			Debug.LogWarning("More than one instance of resourcePanelController found!");
			return;
		}
		instance = this;
	}
	#endregion

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)) {
			toggleVisibility();
		}
		if (visible) {
			transform.position = Vector3.Lerp(transform.position, normalPosition.position, 10f * Time.deltaTime);
		} else {
			transform.position = Vector3.Lerp(transform.position, hiddenPosition.position, 10f * Time.deltaTime);
		}
	}

	public void toggleVisibility () {
		visible = !visible;
	}
}
