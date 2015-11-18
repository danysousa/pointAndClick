using UnityEngine;
using System.Collections;

public class LightSkill : Skill {

	public GameObject lightPrefab;
	private GameObject currentLight;
	private Skill light1;
	private Skill light2;
	private Skill light3;
	private Skill light4;
	
	private bool isInUse = false;
	private bool inProgress = false;
	public float angle = 10f;
	
	void Start () {
		base.Start ();
		this.nameSkill = "Light";
		this.effects = "permanent light to follow you !";
		light1 = GameObject.FindGameObjectWithTag ("light1").GetComponent<Skill>();
		light2 = GameObject.FindGameObjectWithTag ("light2").GetComponent<Skill>();
		light3 = GameObject.FindGameObjectWithTag ("light3").GetComponent<Skill>();
		light4 = GameObject.FindGameObjectWithTag ("light4").GetComponent<Skill>();
	}
	
	public void addLevel(GameObject elem)
	{
		if (PlayerManager.instance.pointTalent > 0) {
			if (elem.tag == "light1" && light1.lvl < 5 && light1.isEnabled) {
				light1.lvl++;
				angle += 1f;
				PlayerManager.instance.pointTalent -= 1;
			} else if (elem.tag == "light2" && light2.lvl < 5 && light2.isEnabled) {
				light2.lvl++;
				angle += 1f;
				PlayerManager.instance.pointTalent -= 1;
			} else if (elem.tag == "light3" && light3.lvl < 5 && light3.isEnabled) {
				light3.lvl++;
				angle += 1f;
				PlayerManager.instance.pointTalent -= 1;
			} else if (elem.tag == "life4" && light4.lvl < 5 && light4.isEnabled) {
				PlayerManager.instance.pointTalent -= 1;
				light4.lvl++;
				angle += 1f;
			}

		}
	}
	
	void Update () {
		base.Update();
	}
	
	public override void useSkill()
	{
		if (!isInUse && currentLight == null) {
			currentLight = Instantiate (lightPrefab, PlayerManager.instance.player.transform.position, Quaternion.identity) as GameObject;
			currentLight.GetComponent<LightEffectSkill> ().setSpotAngle (angle);
			isInUse = true;
		}
	}
	
	public override void disableSkillEffect()
	{
		currentLight.GetComponent<LightEffectSkill> ().destroyLight();
		Destroy (currentLight);
		isInUse = false;
	}
}
