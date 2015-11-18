using UnityEngine;
using System.Collections;

public class PotionLife : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player" && col.GetComponent<Maya>() != null)
			col.GetComponent<Maya>().takePotion();
		Destroy (this.gameObject);
	}
}
