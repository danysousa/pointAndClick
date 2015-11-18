using UnityEngine;
using System.Collections;

public class AirSupportSkill : Skill {
	
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

	public void useSkill()
	{
		Debug.Log ("mineUsed !");
	}

}
