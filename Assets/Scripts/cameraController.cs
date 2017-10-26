using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	#region Singleton
	public static Camera mainCamera;

	private void Awake () {
		if (mainCamera != null) {
			Debug.LogWarning("More than one instance of mainCamera found!");
			return;
		}
		mainCamera = transform.Find("Camera").GetComponent<Camera>();
	}
	#endregion

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 20 * Time.deltaTime);
	}
}
