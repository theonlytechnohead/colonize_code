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
	public Slider oxygenSlider;
	public TextMeshProUGUI water;
	public Slider waterSlider;
	public TextMeshProUGUI food;
	public Slider foodSlider;
	public TextMeshProUGUI power;
	public Slider powerSlider;
	public TextMeshProUGUI kironide;
	public Slider kironideSlider;
	public TextMeshProUGUI rypherium;
	public Slider rhypheriumSlider;

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
		gameController.instance.oxygen = Mathf.Round(gameController.instance.oxygen * 100f) / 100f;
		gameController.instance.water = Mathf.Round(gameController.instance.water * 100f) / 100f;
		gameController.instance.food = Mathf.Round(gameController.instance.food * 100f) / 100f;
		gameController.instance.power = Mathf.Round(gameController.instance.power * 100f) / 100f;
		gameController.instance.kironide = Mathf.Round(gameController.instance.kironide * 1f) / 1f;
		gameController.instance.rhypherium = Mathf.Round(gameController.instance.rhypherium * 100f) / 100f;
		oxygen.text = "Oxygen: " + gameController.instance.oxygen;
		oxygenSlider.maxValue = gameController.instance.maxOxygen;
		oxygenSlider.value = gameController.instance.oxygen;

		water.text = "Water: " + gameController.instance.water;
		waterSlider.maxValue = gameController.instance.maxWater;
		waterSlider.value = gameController.instance.water;

		food.text = "Food: " + gameController.instance.food;
		foodSlider.maxValue = gameController.instance.maxFood;
		foodSlider.value = gameController.instance.food;

		power.text = "Power: " + gameController.instance.power;
		powerSlider.maxValue = gameController.instance.maxPower;
		powerSlider.value = gameController.instance.power;

		kironide.text = "Kironide: " + gameController.instance.kironide;
		kironideSlider.maxValue = gameController.instance.maxKironide;
		kironideSlider.value = gameController.instance.kironide;

		rypherium.text = "Rhypherium: " + gameController.instance.rhypherium;
		rhypheriumSlider.maxValue = gameController.instance.maxRhypherium;
		rhypheriumSlider.value = gameController.instance.rhypherium;

		visible = buildPanelController.instance.visible;
		if (visible) {
			transform.position = Vector3.Lerp(transform.position, normalPosition.position, 10f * Time.deltaTime);
		} else {
			transform.position = Vector3.Lerp(transform.position, hiddenPosition.position, 10f * Time.deltaTime);
		}
	}
}
