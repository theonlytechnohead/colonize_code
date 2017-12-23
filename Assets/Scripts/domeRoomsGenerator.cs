using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class domeRoomsGenerator : MonoBehaviour {

	public GameObject outerFoundation;
	public GameObject innerFoundation;
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
			for (int room = 0; room <= 32; room++) {
				GameObject newInnerRoom = Instantiate(innerFoundation, new Vector3(0f, floorHeight[floor - 1], 0f) + new Vector3(0f, 0.1f, 0f), Quaternion.Euler(new Vector3(90f, (360 / 32) * room, 0f)));
				newInnerRoom.transform.localScale = transform.localScale + new Vector3(scale, scale, 0f);
				newInnerRoom.layer = layers[floor - 1];
				GameObject newOuterRoom = Instantiate(outerFoundation, new Vector3(0f, floorHeight[floor - 1], 0f) + new Vector3(0f, 0.1f, 0f), Quaternion.Euler(new Vector3(90f, (360 / 32) * room, 0f)));
				newOuterRoom.transform.localScale = transform.localScale + new Vector3(scale, scale, 0f);
				newOuterRoom.layer = layers[floor - 1];
			}
		}
		Destroy(this);
	}
}
