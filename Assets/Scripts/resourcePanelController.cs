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
		oxygen.text = "Oxygen\n" + gameController.instance.oxygen.amount;
		oxygenSlider.maxValue = gameController.instance.oxygen.maxAmount;
		oxygenSlider.value = gameController.instance.oxygen.amount;

		water.text = "Water\n" + gameController.instance.water.amount;
		waterSlider.maxValue = gameController.instance.water.maxAmount;
		waterSlider.value = gameController.instance.water.amount;

		food.text = "Food\n" + gameController.instance.food.amount;
		foodSlider.maxValue = gameController.instance.food.maxAmount;
		foodSlider.value = gameController.instance.food.amount;

		power.text = "Power\n" + gameController.instance.power.amount;
		powerSlider.maxValue = gameController.instance.power.maxAmount;
		powerSlider.value = gameController.instance.power.amount;

		kironide.text = "Kironide\n" + Mathf.Round(gameController.instance.kironide.amount);
		kironideSlider.maxValue = gameController.instance.kironide.maxAmount;
		kironideSlider.value = gameController.instance.kironide.amount;

		rypherium.text = "Rhypherium\n" + gameController.instance.rhypherium.amount;
		rhypheriumSlider.maxValue = gameController.instance.rhypherium.maxAmount;
		rhypheriumSlider.value = gameController.instance.rhypherium.amount;

		visible = buildPanelController.instance.visible;
		if (visible) {
			transform.position = Vector3.Lerp(transform.position, normalPosition.position, 10f * Time.deltaTime);
		} else {
			transform.position = Vector3.Lerp(transform.position, hiddenPosition.position, 10f * Time.deltaTime);
		}
	}
}
