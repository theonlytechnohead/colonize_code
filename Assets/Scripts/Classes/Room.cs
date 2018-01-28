using UnityEngine;

[CreateAssetMenu(fileName = "New room", menuName = "Custom items/Room")]
public class Room : ScriptableObject {

	new public string name;
	public Resource resourceRequired;
	public int resourceAmount;
	public GameObject prefab;
	public Generator generator;

}
