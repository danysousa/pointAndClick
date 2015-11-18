using UnityEngine;
using System.Collections;

public class AirSupportSkill : Skill {

	public GameObject supportPrefab;
	private Skill support;
	
	void Start () {
		base.Start ();
		this.nameSkill = "Air Support";
		this.effects = "call an air support";
		support = GameObject.FindGameObjectWithTag ("support").GetComponent<Skill>();
	}
	
	public void addLevel(GameObject elem)
	{
		if (elem.tag == "support" && support.lvl < 5 && support.isEnabled) {
			support.lvl++;
		}
	}

	public override void useSkill()
	{
		Instantiate (supportPrefab);
	}

}
