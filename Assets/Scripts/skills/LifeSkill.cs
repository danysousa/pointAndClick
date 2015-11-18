using UnityEngine;
using System.Collections;

public class LifeSkill : Skill {

	private Skill life1;
	private Skill life2;
	private Skill life3;
	private Skill life4;
	private Skill life5;

	private bool isInUse = false;
	public int lifeRegain = 1;
	private float time = 20f;
	private bool inProgress = false;
	
	void Start () {
		base.Start ();
		this.nameSkill = "Life";
		this.effects = "regain little life";
		life1 = GameObject.FindGameObjectWithTag ("life1").GetComponent<Skill>();
		life2 = GameObject.FindGameObjectWithTag ("life2").GetComponent<Skill>();
		life3 = GameObject.FindGameObjectWithTag ("life3").GetComponent<Skill>();
		life4 = GameObject.FindGameObjectWithTag ("life4").GetComponent<Skill>();
		life5 = GameObject.FindGameObjectWithTag ("life5").GetComponent<Skill>();
	}
	
	public void addLevel(GameObject elem)
	{
		if (elem.tag == "life1" && life1.lvl < 5 && life1.isEnabled) {
			time -= 1f;
			life1.lvl++;
		} else if (elem.tag == "life2" && life2.lvl < 5 && life2.isEnabled) {
			time -= 1f;
			life2.lvl++;
		} else if (elem.tag == "life3" && life3.lvl < 5 && life3.isEnabled) {
			time -= 1f;
			life3.lvl++;
		} else if (elem.tag == "life4" && life4.lvl < 5 && life4.isEnabled) {
			time -= 1f;
			life4.lvl++;
		}else if (elem.tag == "life5" && life5.lvl < 5 && life5.isEnabled) {
			time -= 1f;
			life5.lvl++;
		}
	}

	void Update () {
		base.Update();
		if (!inProgress && isInUse)
			StartCoroutine( lifePower( ) );
	}

	public override void useSkill()
	{
		isInUse = true;
	}

	public override void disableSkillEffect()
	{
		isInUse = false;
	}

	private IEnumerator lifePower()
	{
		inProgress = true;
		yield return new WaitForSeconds( time );
		PlayerManager.instance.player.addLife (1);
		inProgress = false;

	}
}
