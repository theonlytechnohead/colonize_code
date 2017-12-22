using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class domeRoomsGenerator : MonoBehaviour {

	public GameObject outerRoom;
	public GameObject innerRoom;
	public Color roomColour;
	public List<int> layers;
	public List<float> floorHeight;

	void Start () {
		float scale = 0f;
		for (int floor = 1; floor <=5; floor++) {
			if (floor == 1) {scale = 1f;} else
			if (floor == 2) {scale = 0f;} else
			if (floor == 3) {scale = -4f;} else
			if (floor == 4) {scale = 2f;} else
			if (floor == 5) {scale = 2f;}
			for (int room = 1; room <= 24; room++) {
				GameObject newInnerRoom = Instantiate(innerRoom, new Vector3(0f, floorHeight[floor - 1], 0f) + new Vector3(0f, 0.1f, 0f), transform.rotation * Quaternion.Euler(new Vector3(0f, 180f, (360 / 24) * room)));
				newInnerRoom.transform.localScale = transform.localScale + new Vector3(scale, scale, 0f);
				newInnerRoom.layer = layers[floor - 1];
				GameObject newOuterRoom = Instantiate(outerRoom, new Vector3(0f, floorHeight[floor - 1], 0f) + new Vector3(0f, 0.1f, 0f), transform.rotation * Quaternion.Euler(new Vector3(0f, 180f, (360 / 24) * room)));
				newOuterRoom.transform.localScale = transform.localScale + new Vector3(scale, scale, 0f);
				newOuterRoom.layer = layers[floor - 1];
			}
		}
		Destroy(this);
	}
}
