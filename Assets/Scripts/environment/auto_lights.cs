using UnityEngine;
using System.Collections;

public class auto_lights : MonoBehaviour {

	public float distanceLimit = 16f;
	private GameObject player;
	private Light currentLight;
	private bool checkingDistance = false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
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
		yield return new WaitForSeconds(0.3f);
		float distance = Vector3.Distance(transform.position, player.transform.position);
		currentLight.enabled = (distance <= distanceLimit);
		checkingDistance = false;
	}
}
