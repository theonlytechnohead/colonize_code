using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class notificationPanelController : MonoBehaviour {

	public bool visible = false;
	public Transform hiddenPosition;
	public Transform normalPosition;
	public GameObject contentContainer;
	public RectTransform leftPos;
	public RectTransform leftSpacer;
	public RectTransform rightPos;
	public TextMeshProUGUI runningMessage;
	public GameObject notificationTemplate;

	public List<GameObject> notifications;
	private Queue<string> notificationsQueue;
	public bool ready = true;

	#region Singleton
	public static notificationPanelController instance;

	private void Awake () {
		if (instance != null) {
			Debug.LogWarning("More than one instance of notificationPanelController found!");
			return;
		}
		instance = this;
	}
	#endregion

	void Start () {
		notificationsQueue = new Queue<string>();
		//AddNotification("Test at runtime", "Testing testing testing testing the message stuff at runtime!");
		//AddNotification("Test 2", "Testing again, testing again, testing again!");
	}

	public void ClearNotifications () {
		foreach (GameObject notification in notifications) {
			Destroy(notification);
		}
		notificationsQueue.Clear();
		notifications.Clear();
	}
	
	public void SetMouseOverState (bool state) {
		visible = state;
	}
	void Update () {
		if (visible) {
			transform.position = Vector3.Lerp(transform.position, normalPosition.position, 10f * Time.deltaTime);
		} else {
			transform.position = Vector3.Lerp(transform.position, hiddenPosition.position, 10f * Time.deltaTime);
		}
		while (notificationsQueue.Count != 0 && ready) {
			DisplayRunningMessage();
		}
	}

	public void AddNotification (string title, string content) {
		Vector3 offset = Vector3.zero;
		foreach (GameObject notification in notifications) {
			offset.y += notification.GetComponent<RectTransform>().rect.height;
			
		}
		GameObject newNotification = Instantiate(notificationTemplate);
		newNotification.GetComponent<Notification>().time = gameController.instance.time.ToString() + " " + gameController.instance.currentMonth.name + ", ";
		newNotification.GetComponent<Notification>().title = title + ": ";
		newNotification.GetComponent<Notification>().content = content;
		newNotification.transform.SetParent(contentContainer.transform, false);
		newNotification.GetComponent<RectTransform>().localPosition = notificationTemplate.GetComponent<RectTransform>().localPosition - offset;
		notifications.Add(newNotification);
		notificationsQueue.Enqueue(title + ": " + content);
	}

	void DisplayRunningMessage () {
		ready = false;
		runningMessage.text = notificationsQueue.Dequeue();
		leftPos.gameObject.GetComponent<TextMeshProUGUI>().text = runningMessage.text;
		leftSpacer.gameObject.GetComponent<TextMeshProUGUI>().text = runningMessage.text;
		rightPos.gameObject.GetComponent<TextMeshProUGUI>().text = runningMessage.text;
		StartCoroutine(MoveIt((returnedValue) => {
			ready = returnedValue;
		}));
	}

	IEnumerator MoveIt (System.Action<bool> ready) {
		float counter = 0;
		runningMessage.gameObject.transform.localPosition = rightPos.localPosition;
		while (runningMessage.gameObject.transform.localPosition.x > leftPos.localPosition.x) {
			Vector3 newPos = runningMessage.gameObject.transform.localPosition;
			newPos.x = Mathf.Lerp(rightPos.localPosition.x, leftPos.localPosition.x, counter);
			runningMessage.gameObject.transform.localPosition = newPos;
			counter += 0.002f;
			yield return null;
		}
		runningMessage.gameObject.transform.localPosition = rightPos.localPosition;
		ready(true);
		yield return null;
	}
}
