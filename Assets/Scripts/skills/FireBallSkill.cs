using UnityEngine;
using System.Collections;

public class FireBallSkill : Skill {

	public GameObject prefabFireBall;

	private Skill fireball1;
	private Skill fireball2;
	private Skill fireball3;
	
	void Start () {
		base.Start ();
		this.nameSkill = "fireball";
		this.effects = "huge fireball to destroy zombies";
		fireball1 = GameObject.FindGameObjectWithTag ("fireball1").GetComponent<Skill>();
		fireball2 = GameObject.FindGameObjectWithTag ("fireball2").GetComponent<Skill>();
		fireball3 = GameObject.FindGameObjectWithTag ("fireball3").GetComponent<Skill>();
	}
	
	public void addLevel(GameObject elem)
	{
		if (PlayerManager.instance.pointTalent > 0) {
			if (elem.tag == "fireball1" && fireball1.lvl < 5 && fireball1.isEnabled) {
				fireball1.lvl++;
				PlayerManager.instance.pointTalent -= 1;
			} else if (elem.tag == "fireball2" && fireball2.lvl < 5 && fireball2.isEnabled) {
				fireball2.lvl++;
				PlayerManager.instance.pointTalent -= 1;
			} else if (elem.tag == "fireball3" && fireball3.lvl < 5 && fireball3.isEnabled) {
				fireball3.lvl++;
				PlayerManager.instance.pointTalent -= 1;
			}
		}
	}
	

	public override void useSkill()
	{
		if (gameObject.tag == "fireball1") {
			Instantiate (prefabFireBall, PlayerManager.instance.player.transform.position, Quaternion.identity);
		} else if (gameObject.tag == "fireball2") {
			Instantiate (prefabFireBall, PlayerManager.instance.player.transform.position, Quaternion.identity);
			Instantiate (prefabFireBall, PlayerManager.instance.player.transform.position, Quaternion.identity);
		} else if (gameObject.tag == "fireball3"){
			Instantiate (prefabFireBall, PlayerManager.instance.player.transform.position, Quaternion.identity);
			Instantiate (prefabFireBall, PlayerManager.instance.player.transform.position, Quaternion.identity);
			Instantiate (prefabFireBall, PlayerManager.instance.player.transform.position, Quaternion.identity);
		}
	}

	public override void disableSkillEffect()
	{
		
	}
}
