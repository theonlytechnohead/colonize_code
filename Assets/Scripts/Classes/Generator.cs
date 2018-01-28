using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New generator", menuName = "Custom items/Generator")]
public class Generator : ScriptableObject {

	public List<ResourceAndAmount> resourcesRequired;
	public List<ResourceAndAmount> resourcesGenerated;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Generate () {
		if (CheckRequirements() && CheckGeneration()) {
			foreach (ResourceAndAmount resourceAndAmount in resourcesRequired) {
				resourceAndAmount.resource.amount -= resourceAndAmount.amount;
			}
			foreach (ResourceAndAmount resourceAndAmount in resourcesGenerated) {
				resourceAndAmount.resource.amount += resourceAndAmount.amount;
			}
		}
	}

	public bool CheckRequirements () {
		foreach (ResourceAndAmount resourceAndAmount in resourcesRequired) {
			Resource resourceRequired = resourceAndAmount.resource;
			int resourceRequiredAmount = resourceAndAmount.amount;
			if (resourceRequired != null) {
				if (resourceRequired.amount >= resourceRequiredAmount) {
					// All is well for ONE resource, now wait for the loop to finish off
				} else {
					return false;
				}
			} else {
				return false;
			}
		}
		return true;
	}

	public bool CheckGeneration () {
		foreach (ResourceAndAmount resourceAndAmount in resourcesGenerated) {
			Resource resourceGenerated = resourceAndAmount.resource;
			int amountGenerated = resourceAndAmount.amount;
			if (resourceGenerated.amount + amountGenerated <= resourceGenerated.maxAmount) {
				// All is well for ONE resource, now wait for the loop to finish off
			} else {
				return false;
			}
		}
		return true;
	}
}
