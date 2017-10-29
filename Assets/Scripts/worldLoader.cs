using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class worldLoader : MonoBehaviour {

	public GameObject loadFadeRawImage;
	Color image;
	public Color targetColor;

	void Start () {
		image = loadFadeRawImage.GetComponent<RawImage>().color;
	}

	void Update () {
		if (loadFadeRawImage != null) {
			image = Color.Lerp(image, targetColor, Time.deltaTime);
			loadFadeRawImage.GetComponent<RawImage>().color = image;
			if (image.a < 0.05f) {
				Destroy(loadFadeRawImage);
			}
		}
	}

	public void loadWorld (string worldName) {
		print("Loading " + worldName);
		SceneManager.LoadScene(worldName);
	}

	public void generateWorld (string worldName) {
		
	}
}