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
		if (PlayerManager.instance.pointTalent > 0) {
			if (elem.tag == "support" && support.lvl < 5 && support.isEnabled) {
				support.lvl++;
				PlayerManager.instance.pointTalent -= 1;
			}
		}
	}

	public override void useSkill()
	{
		GameObject tmp = Instantiate (supportPrefab, PlayerManager.instance.player.transform.position, Quaternion.identity) as GameObject;
	}

}
