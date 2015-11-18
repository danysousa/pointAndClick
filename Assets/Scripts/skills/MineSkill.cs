using UnityEngine;
using System.Collections;

public class MineSkill : Skill {

	public GameObject minePrefab;

	private Skill mine1;
	private Skill mine2;
	private Skill mine3;

	void Start () {
		base.Start ();
		this.nameSkill = "mine";
		this.effects = "drop a mine to destroy zombies";
		mine1 = GameObject.FindGameObjectWithTag ("mine1").GetComponent<Skill>();
		mine2 = GameObject.FindGameObjectWithTag ("mine2").GetComponent<Skill>();
		mine3 = GameObject.FindGameObjectWithTag ("mine3").GetComponent<Skill>();
	}

	public void addLevel(GameObject elem)
	{
		if (elem.tag == "mine1" && mine1.lvl < 5 && mine1.isEnabled) {
			mine1.lvl++;
		} else if (elem.tag == "mine2" && mine2.lvl < 5 && mine2.isEnabled) {
			mine2.lvl++;
		} else if (elem.tag == "mine3" && mine3.lvl < 5 && mine2.isEnabled) {
			mine3.lvl++;
		}
	}

	public override void useSkill()
	{
		if (gameObject.tag == "mine1") {
			Instantiate (minePrefab, PlayerManager.instance.player.transform.position, Quaternion.identity);
		} else if (gameObject.tag == "mine2") {
			Instantiate (minePrefab, PlayerManager.instance.player.transform.position, Quaternion.identity);
			Instantiate (minePrefab, PlayerManager.instance.player.transform.position, Quaternion.identity);
		} else {
			Instantiate (minePrefab, PlayerManager.instance.player.transform.position, Quaternion.identity);
			Instantiate (minePrefab, PlayerManager.instance.player.transform.position, Quaternion.identity);
			Instantiate (minePrefab, PlayerManager.instance.player.transform.position, Quaternion.identity);
		}
	}

	public override void disableSkillEffect()
	{

	}
}
