using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class worldLoader : MonoBehaviour {

	public Color startColour;
	public Color targetColour;

	void Update () {
		startColour = Color.Lerp(startColour, targetColour, Time.deltaTime);
		GetComponent<Camera>().backgroundColor = startColour;
	}

	public void loadWorld (string worldName) {
		SceneManager.LoadScene(worldName);
	}
}