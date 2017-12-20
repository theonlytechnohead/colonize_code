using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class resourcePanelController : MonoBehaviour {

	public bool visible = false;
	public Transform hiddenPosition;
	public Transform normalPosition;

	public TextMeshProUGUI oxygen;
	public TextMeshProUGUI water;
	public TextMeshProUGUI food;
	public TextMeshProUGUI power;
	public TextMeshProUGUI kironide;
	public TextMeshProUGUI rypherium;

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
		oxygen.text = "Oxygen: " + gameController.instance.oxygen;
		water.text = "Water: " + gameController.instance.water;
		food.text = "Food: " + gameController.instance.food;
		power.text = "Power: " + gameController.instance.power;
		kironide.text = "Kironide: " + gameController.instance.kironide;
		rypherium.text = "Rhypherium: " + gameController.instance.rhypherium;

		visible = buildPanelController.instance.visible;
		if (visible) {
			transform.position = Vector3.Lerp(transform.position, normalPosition.position, 10f * Time.deltaTime);
		} else {
			transform.position = Vector3.Lerp(transform.position, hiddenPosition.position, 10f * Time.deltaTime);
		}
	}
}
