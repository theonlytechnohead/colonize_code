using UnityEngine;
using UnityEngine.SceneManagement;

public class worldLoader : MonoBehaviour {

	public void loadWorld (string worldName) {
		print("Loading " + worldName);
		SceneManager.LoadScene(worldName);
	}

	public void generateWorld (string worldName) {
		
	}
}