using UnityEngine;
using System.Collections;

public class LightSkill : Skill {

	private Skill fireball1;
	private Skill fireball2;
	private Skill fireball3;
	
	void Start () {
		base.Start ();
		this.nameSkill = "Life";
		this.effects = "regain little life";
		fireball1 = GameObject.FindGameObjectWithTag ("fireball1").GetComponent<Skill>();
		fireball2 = GameObject.FindGameObjectWithTag ("fireball2").GetComponent<Skill>();
		fireball3 = GameObject.FindGameObjectWithTag ("fireball3").GetComponent<Skill>();
	}
	
	public void addLevel(GameObject elem)
	{
		if (elem.tag == "fireball1" && fireball1.lvl < 5 && fireball1.isEnabled) {
			fireball1.lvl++;
		} else if (elem.tag == "fireball2" && fireball2.lvl < 5 && fireball2.isEnabled) {
			fireball2.lvl++;
		} else if (elem.tag == "fireball3" && fireball3.lvl < 5 && fireball3.isEnabled) {
			fireball3.lvl++;
		}
	}
	
	
	public override void useSkill()
	{

	}
}
