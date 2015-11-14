using UnityEngine;
using System.Collections;

public class shaky_lights : MonoBehaviour {
	private Light currentLight;
	private bool checkingDistance = false;
	// Use this for initialization
	void Start () {
		currentLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!checkingDistance)
			StartCoroutine(this.enableLight());
	}
	IEnumerator enableLight()
	{
		checkingDistance = true;
		currentLight.enabled = true;
		yield return new WaitForSeconds(Random.Range(5f, 10f));
		for (int i = 0; i < 3; i++) {
			currentLight.enabled = false;
			yield return new WaitForSeconds (0.1f);
			currentLight.enabled = true;
			yield return new WaitForSeconds (0.1f);
		}
		checkingDistance = false;
	}
}
