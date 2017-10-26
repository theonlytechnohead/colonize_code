using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirt : MonoBehaviour {

	public Color normalColour;
	public Color highlightColour;
	private Renderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
	}

	void OnMouseDown () {
		Destroy(gameObject);
	}
	void OnMouseEnter () {
		renderer.material.color = highlightColour;
	}
    void OnMouseExit () {
		renderer.material.color = normalColour;
    }
}
