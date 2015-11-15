using UnityEngine;
using System.Collections;

public class auto_lights : MonoBehaviour {
	
	private Light currentLight;
	// Use this for initialization
	void Start () {
		currentLight = GetComponent<Light> ();
		currentLight.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
			currentLight.enabled = true;
	}
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player")
			currentLight.enabled = false;
	}
}
