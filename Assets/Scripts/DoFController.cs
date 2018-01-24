using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class DoFController : MonoBehaviour {

	PostProcessingProfile postProcessingProfile;

	void Start() {
		postProcessingProfile = gameObject.GetComponent<PostProcessingBehaviour>().profile;
	}

	void FixedUpdate () {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
			var settings = postProcessingProfile.depthOfField.settings;
			settings.focusDistance = Mathf.Lerp(settings.focusDistance, hit.distance, 1.5f * Time.deltaTime);
			postProcessingProfile.depthOfField.settings = settings;
		}
    }
}
