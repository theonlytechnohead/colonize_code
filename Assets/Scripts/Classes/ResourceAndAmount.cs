using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New resource and amount", menuName = "Custom items/Resource and amount")]
public class ResourceAndAmount : ScriptableObject {

	public Resource resource;
	public int amount;

}
