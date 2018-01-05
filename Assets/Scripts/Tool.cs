using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New tool", menuName = "Custom items/Tool")]
public class Tool : ScriptableObject {

	public bool build;
	public GameObject thingToBuild;
	public Room roomToBuild;

	public void Action(GameObject clickedObject) {
		if (build) {
			gridCell gridCell = clickedObject.GetComponent<gridCell>();
			roomController roomController = clickedObject.GetComponent<roomController>();
			if (gridCell != null) {
				if (thingToBuild != null) {
					gridCell.buildGameObject(thingToBuild);
				}
			} else if (roomController != null) {
				roomController.buildRoom(roomToBuild.prefab);
			}
		} else {
			Destroy(clickedObject.gameObject);
		}
	}

}
