using UnityEngine;
using System.Collections;

public class RageSkill : Skill {

	public GameObject ragePrefab;

	private GameObject currentRage;

	private Skill rage1;
	private Skill rage2;
	private Skill rage3;
	private Skill rage4;
	private Skill rage5;
	private bool inProgress = false;
	public float time = 10f;
	
	void Start () {
		base.Start ();
		this.nameSkill = "rage";
		this.effects = "very high damge for little time";
		rage1 = GameObject.FindGameObjectWithTag ("rage1").GetComponent<Skill>();
		rage2 = GameObject.FindGameObjectWithTag ("rage2").GetComponent<Skill>();
		rage3 = GameObject.FindGameObjectWithTag ("rage3").GetComponent<Skill>();
		rage4 = GameObject.FindGameObjectWithTag ("rage4").GetComponent<Skill>();
		rage5 = GameObject.FindGameObjectWithTag ("rage5").GetComponent<Skill>();
	}
	
	public void addLevel(GameObject elem)
	{
		if (elem.tag == "rage1" && rage1.lvl < 5 && rage1.isEnabled) {
			rage1.lvl++;
			time += 1f;
		} else if (elem.tag == "rage2" && rage2.lvl < 5 && rage2.isEnabled) {
			rage2.lvl++;
			time += 1f;
		} else if (elem.tag == "rage3" && rage3.lvl < 5 && rage3.isEnabled) {
			rage3.lvl++;
			time += 1f;
		}else if (elem.tag == "rage4" && rage4.lvl < 5 && rage4.isEnabled) {
			rage4.lvl++;
			time += 1f;
		}else if (elem.tag == "rage5" && rage5.lvl < 5 && rage5.isEnabled) {
			rage5.lvl++;
			time += 1f;
		}
	}
	
	
	public override void useSkill()
	{
		if (!inProgress)
			StartCoroutine (ragePower());
	}
	
	public override void disableSkillEffect()
	{
		
	}

	void Update () {
		base.Update ();
		if (currentRage != null)
			currentRage.transform.position = PlayerManager.instance.player.transform.position;
	}

	private IEnumerator ragePower()
	{
		inProgress = true;

		PlayerManager.instance.player.addLife (20);
		currentRage = Instantiate (ragePrefab, PlayerManager.instance.player.transform.position, Quaternion.identity) as GameObject;
		int tmp = PlayerManager.instance.player.damage;
		PlayerManager.instance.player.damage = tmp + 50;
		yield return new WaitForSeconds( time );
		PlayerManager.instance.player.damage = tmp;
		Destroy (currentRage);
		currentRage = null;
		inProgress = false;
		
	}
}
