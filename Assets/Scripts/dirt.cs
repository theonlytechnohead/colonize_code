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
		transform.position += new Vector3(0f, 1.5f, 0f);
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
