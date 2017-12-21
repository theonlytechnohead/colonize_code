using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {
	
	public float panSpeed = 30f;
	public float scrollSpeed = 30f;

	public Transform cameraMoveTarget;

	#region Singleton
	public static Camera mainCamera;

	private void Awake () {
		if (mainCamera != null) {
			Debug.LogWarning("More than one instance of mainCamera found!");
			return;
		}
		mainCamera = GameObject.Find("Camera").GetComponent<Camera>();
	}
	#endregion

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//// Camera movement and rotation controls
		// Setup temp position variable
		Vector3 pos = cameraMoveTarget.transform.position;
		Vector3 rot = cameraMoveTarget.transform.rotation.eulerAngles;
		// Translate from world space to local space for proper movment according to current rotation
		pos = cameraMoveTarget.transform.InverseTransformPoint(pos);
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
		if (Input.GetKey(KeyCode.Q)) { // Rotate camera via keyboard
			rot += new Vector3(0f, -1.5f, 0f);
			cameraMoveTarget.rotation = Quaternion.Slerp(cameraMoveTarget.rotation, Quaternion.Euler(rot), 100f * Time.deltaTime);
			//cameraMoveTarget.transform.Rotate(0, -1.5f, 0);
		}
		if (Input.GetKey(KeyCode.E)) {
			rot += new Vector3(0f, 1.5f, 0f);
			cameraMoveTarget.rotation = Quaternion.Slerp(cameraMoveTarget.rotation, Quaternion.Euler(rot), 100f * Time.deltaTime);
		}
		if (Input.GetMouseButton(2)) // Rotate camera up/down left/right via holding scrollwheel/middle mouse button
 		{
			cameraMoveTarget.transform.Rotate(0f, Input.GetAxis("Mouse X") * 200f * Time.deltaTime, 0f);
			mainCamera.transform.Rotate(-Input.GetAxis("Mouse Y") * 200f * Time.deltaTime, 0f, 0f);
			// Hide and lock the cursor while rotating
			Cursor.lockState = CursorLockMode.Locked;
        	Cursor.visible = false;
 		} else { // Show and unlock the cursor otherwise
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
		
		// Applying scrolling to zoom FORWARD/IN (the CENTRE of the screen, not up/down!)
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		pos.y -= scroll * scrollSpeed * 30f * Time.deltaTime;
		pos.z += scroll * scrollSpeed * 30f * Time.deltaTime;

		// Revert back into world space so that clamping workings properly, and can be directly applied
		Vector3 newPos = cameraMoveTarget.transform.TransformPoint(pos);
		newPos.x = Mathf.Clamp(newPos.x, -45, 45);
		newPos.y = Mathf.Clamp(newPos.y, 2, 50);
		newPos.z = Mathf.Clamp(newPos.z, -27, 27);
		// Apply the transformation!
		cameraMoveTarget.position = newPos;
		transform.rotation = Quaternion.Slerp(transform.rotation, cameraMoveTarget.rotation, 10f * Time.deltaTime);
	}

	void LateUpdate () {
		Vector3 smoothedPos = Vector3.Lerp(transform.position, cameraMoveTarget.transform.position, 10f * Time.deltaTime);
		transform.position = smoothedPos;
	}
}
