using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class domeController : MonoBehaviour {

	//private Renderer renderer;
	public GameObject dome;

	// Use this for initialization
	void Start () {
		//renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) & dome.activeSelf) {
			hideDome();
		} else if (Input.GetKeyDown(KeyCode.E)) {
			showDome();
		}
	}

	void hideDome () {
		dome.SetActive(false);
	}
    void showDome () {
		dome.SetActive(true);
    }
}
