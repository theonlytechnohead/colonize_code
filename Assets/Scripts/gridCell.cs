using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridCell : MonoBehaviour {

	public GameObject roomHolder;
	new private Renderer renderer;
	private GameObject newRoom;

	// Use this for initialization
	void Start () {
		//buildRoom(roomHolder);
		renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void buildRoom (GameObject roomHolder) {
		newRoom = Instantiate(roomHolder, new Vector3(transform.position.x, 0f, transform.position.z), transform.rotation);
		newRoom.transform.SetParent(transform);
		newRoom.transform.position -= new Vector3(0f, 1f, 0f);
	}

	void OnMouseDown () {
		if (newRoom == null) {
			buildRoom(roomHolder);
			renderer.material.color = Color.green;
		}
	}
	void OnMouseEnter () {
		if (newRoom == null) {
			renderer.material.color = Color.yellow;
		}
	}
    void OnMouseExit () {
		if (newRoom == null) {
			renderer.material.color = Color.white;
		}
    }
}
