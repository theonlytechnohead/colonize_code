using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class domeRoomsGenerator : MonoBehaviour {

	public GameObject outerRoom;
	public GameObject innerRoom;
	public Color roomColour;
	public List<int> layers;

	void Start () {
		float scale = 0f;
		for (int floor = 1; floor <=3; floor++) {
			if (floor == 1) {scale = 1f;} else
			if (floor == 2) {scale = 0f;} else
			if (floor == 3) {scale = -4f;}
			for (int room = 1; room <= 24; room++) {
				GameObject newInnerRoom = Instantiate(innerRoom, new Vector3(0f, 0f, 0f) + new Vector3(0f, 0.1f, 0f) + new Vector3(0f, 3f * floor, 0f), transform.rotation * Quaternion.Euler(new Vector3(0f, 180f, (360 / 24) * room)));
				newInnerRoom.transform.localScale = transform.localScale + new Vector3(scale, scale, 0f);
				newInnerRoom.layer = layers[floor - 1];
				GameObject newOuterRoom = Instantiate(outerRoom, new Vector3(0f, 0f, 0f) + new Vector3(0f, 0.1f, 0f) + new Vector3(0f, 3f * floor, 0f), transform.rotation * Quaternion.Euler(new Vector3(0f, 180f, (360 / 24) * room)));
				newOuterRoom.transform.localScale = transform.localScale + new Vector3(scale, scale, 0f);
				newOuterRoom.layer = layers[floor - 1];
			}
		}
	}
}
