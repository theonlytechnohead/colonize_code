using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dirt : MonoBehaviour {

	public Color normalColour;
	public Color highlightColour;
	public Color dugColour;
	private bool digging = false;
	private Renderer renderer;
	public GameObject dirtExplodeEffect;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		transform.position += new Vector3(0f, 1.5f, 0f);
	}

	void Update () {
		if (digging) {
			renderer.material.color = Color.Lerp(renderer.material.color, dugColour, 0.2f * Time.deltaTime);
			transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(10, 0, 5), 0.2f * Time.deltaTime);
			transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, -5, transform.localPosition.z), 0.2f * Time.deltaTime);
		}
	}

	void OnMouseDown () {
		if(EventSystem.current.IsPointerOverGameObject()) {
			// we're over a UI element... peace out
			return;
    	}
		if (buildPanelController.instance.selectedTool != null) {
			if (buildPanelController.instance.selectedTool.name == "Dig") {
				digging = true;
				renderer.material.color = normalColour;
				StartCoroutine(destroyAfterSeconds(10));
			}
		}		
	}
	void OnMouseOver () {
		if (digging) {
			return;
		}
		if (buildPanelController.instance.selectedTool != null) {
			if (buildPanelController.instance.selectedTool.name == "Dig") {
				renderer.material.color = highlightColour;
			} else {
				renderer.material.color = normalColour;
			}
		} else {
			renderer.material.color = normalColour;
		}
		if (EventSystem.current.IsPointerOverGameObject()) {
			renderer.material.color = normalColour;
    	}
	}
    void OnMouseExit () {
		if (digging) {
			return;
		}
		renderer.material.color = normalColour;
    }

	IEnumerator destroyAfterSeconds (int seconds) {
		yield return new WaitForSeconds(seconds);
		Instantiate(dirtExplodeEffect, transform.position, transform.rotation);
		gameController.instance.kironide += Random.Range(15f, 20f);
		Destroy(gameObject);
	}
}
