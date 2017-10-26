using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridCell : MonoBehaviour {

	public GameObject roomHolder;
	new private Renderer renderer;

	public Material normalMaterial;
	public Material outline_diffuse;

	// Use this for initialization
	void Start () {
		//buildRoom(roomHolder);
		renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void buildRoom (GameObject roomHolder) {
		GameObject newRoom = Instantiate(roomHolder, new Vector3(transform.position.x, -0.5f, transform.position.z), transform.rotation);
		newRoom.transform.SetParent(transform);
	}

	void OnMouseDown () {
		buildRoom(roomHolder);
	}
	void OnMouseEnter () {
		renderer.material.color = Color.yellow;
	}
    void OnMouseExit () {
		renderer.material.color = Color.white;
    }
}
