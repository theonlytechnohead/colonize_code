using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {
	
	public float panSpeed = 30f;
	public float scrollSpeed = 30f;

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
		//transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 20 * Time.deltaTime);
		Vector3 pos = transform.position;
		pos = transform.InverseTransformPoint(pos);
		if (Input.GetKey(KeyCode.W)) {
			pos.z += panSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S)) {
			pos.z -= panSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A)) {
			pos.x -= panSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D)) {
			pos.x += panSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.Q)) {
			transform.Rotate(0, -1f, 0);
		}
		if (Input.GetKey(KeyCode.E)) {
			transform.Rotate(0, 1f, 0);
		}
		if (Input.GetMouseButton(2))
 		{
			transform.Rotate(0f, Input.GetAxis("Mouse X") * 200f * Time.deltaTime, 0f);
			mainCamera.transform.Rotate(-Input.GetAxis("Mouse Y") * 200f * Time.deltaTime, 0f, 0f);
			Cursor.lockState = CursorLockMode.Locked;
        	Cursor.visible = false;
 		} else {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		pos.y -= scroll * scrollSpeed * 30f * Time.deltaTime;
		pos.z += scroll * scrollSpeed * 30f * Time.deltaTime;

		//Debug.Log(pos);
		Vector3 newPos = transform.TransformPoint(pos);
		newPos.x = Mathf.Clamp(newPos.x, -50, 50);
		newPos.y = Mathf.Clamp(newPos.y, 2, 50);
		newPos.z = Mathf.Clamp(newPos.z, -50, 50);
		transform.position = newPos;
	}
}
