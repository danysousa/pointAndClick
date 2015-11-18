using UnityEngine;
using System.Collections;

public class LightEffectSkill : MonoBehaviour {

	private Light currentLight;
	private float angleBase = 15f;
	// Use this for initialization
	void Start () {
		currentLight = GetComponentInChildren<Light> ();
		currentLight.spotAngle = angleBase;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tmp = PlayerManager.instance.player.transform.position;
		tmp.y += 5f;
		transform.position = tmp;

	}
	
	public void setSpotAngle(float angle)
	{
		if (currentLight != null)
			currentLight.spotAngle = angle;
	}
	
	public void destroyLight()
	{
		Destroy (gameObject);
	}
}
