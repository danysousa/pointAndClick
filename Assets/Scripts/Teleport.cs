using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public GameObject		destination;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
			col.gameObject.transform.position = destination.transform.position;
	}
}
