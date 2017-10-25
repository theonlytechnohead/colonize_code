using UnityEngine;

[CreateAssetMenu(fileName = "New Room", menuName = "Object/Room")]
public class Room : ScriptableObject {

	new public string name;
	public int cost;
	//public List<resource> resourcesRequired;
	public GameObject prefab;
}
