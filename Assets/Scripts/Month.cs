using UnityEngine;
[CreateAssetMenu(fileName = "New month", menuName = "Custom items/Month")]
public class Month : ScriptableObject {

	new public string name;
	public int maxTemp;
	public int minTemp;

}
