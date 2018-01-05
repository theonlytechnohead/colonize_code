using UnityEngine;

[CreateAssetMenu(fileName = "New generator", menuName = "Custom items/Generator")]
public class Generator : ScriptableObject {

	public Resource resourceRequired;
	public int resourceRequiredAmount;
	public Resource resourceGenerated;
	public int resourceGeneratedAmount;
	public int powerRequired;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Generate () {
		if (gameController.instance.power.amount >= powerRequired) {
			if (resourceRequired != null) {
				if (resourceRequired.amount >= resourceRequiredAmount) {
					if (resourceGenerated.amount + resourceGeneratedAmount <= resourceGenerated.maxAmount) {
						resourceGenerated.amount += resourceGeneratedAmount;
						resourceRequired.amount -= resourceRequiredAmount;
						gameController.instance.power.amount -= powerRequired;
					}
				}
			}
		}
	}
}
