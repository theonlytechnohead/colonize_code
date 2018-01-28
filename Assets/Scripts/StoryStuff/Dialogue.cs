using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New dialogue", menuName = "Custom items/Dialogue")]
public class Dialogue : ScriptableObject {
	[TextArea(3, 10)]
	public List<string> dialogue;
}
