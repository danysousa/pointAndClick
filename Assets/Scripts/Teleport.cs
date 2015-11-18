using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public GameObject		destination;
	public AudioClip		changeSound;
	public GameObject		ambiance;

	void Start()
	{
		this.ambiance.SetActive(false);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			col.GetComponent<Maya>().initialPos = destination.transform.position;
			col.gameObject.GetComponent<NavMeshAgent>().enabled = false;
			col.gameObject.transform.position = destination.transform.position;
			Camera.main.GetComponent<AudioSource>().Stop ();
			Camera.main.GetComponent<AudioSource>().clip = changeSound;
			Camera.main.GetComponent<AudioSource>().Play ();
			
			col.gameObject.GetComponent<NavMeshAgent>().enabled = true;
			this.ambiance.SetActive(true);
		}
	}
}
