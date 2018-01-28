using UnityEngine;

[CreateAssetMenu(fileName = "New resource", menuName = "Custom items/Resource")]
public class Resource : ScriptableObject {

	public string resource;
	public float amount;
	public float maxAmount;
}
