using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZombieBoss : Humanoid {
	
	public Text				levelText;
	public RectTransform	lifeBar;
	public CanvasGroup		UI;
	public AudioClip[]		voices;
	public AudioClip[]		grow;
	
	private int				oldHP;
	private float			timeLastPlay;
	
	
	IEnumerator		speak()
	{
		while (this.isAlive())
		{
			yield return new WaitForSeconds(Random.Range(7, 35));
			this.GetComponent<AudioSource>().PlayOneShot(voices[Random.Range(0, voices.GetLength(0))]);
		}
	}
	
	void	Awake()
	{
		oldHP = HP;
		this.initHumanoid();
		this.hideUI();
		StartCoroutine(speak());
		timeLastPlay = Time.timeSinceLevelLoad;
	}
	
	void	Update()
	{
		if (this.navAgent.enabled && !this.isAlive())
		{
			LootSystem.instance.createLootsHere(this.transform.position);
			this.animator.SetInteger("HP", 0);
			this.updateUI();
			this.animator.SetBool("attack", false);
			this.disableAll();
			return ;
		}
		else if (this.navAgent.enabled == false)
			return ;
		if (oldHP > HP && timeLastPlay + 2 < Time.timeSinceLevelLoad)
		{
			this.GetComponent<AudioSource>().PlayOneShot(this.grow[Random.Range (0, grow.GetLength(0))]);
			timeLastPlay = Time.timeSinceLevelLoad;
		}
		this.updateStat();
		this.updateAnimation();
		this.updateWeapons();
		this.updateUI();
		oldHP = HP;
	}
	
	private void		updateStat()
	{
		if (this.level == PlayerManager.instance.player.getLevel())
			return ;
		this.level = PlayerManager.instance.player.getLevel();
		this.Armor = (this.level + 1) * 25;
		this.STR = (this.level + 1) * 15;
		this.AGI = (this.level + 1) * 15;
		this.CON = (this.level + 1) * 50;
		Armor = STR / 4 + CON / 2;
		if (Armor >= 100)
			Armor = 100;
		if (this.HP == maxHP)
		{
			this.HP = 5 * CON;
			this.maxHP = HP;
		}
	}
	
	private void		updateUI()
	{
		this.defineLevel();
		this.levelText.text = "Level  " + this.level.ToString();
		float tmp = (float)HP / (float)maxHP;
		this.lifeBar.anchorMax = new Vector2(tmp, this.lifeBar.anchorMax.y);
	}
	
	private void		disableAll()
	{
		this.navAgent.enabled = false;
		this.GetComponent<SphereCollider>().enabled = false;
	}
	
	public void			hideUI()
	{
		UI.alpha = 0;
		UI.interactable = false;
	}
	
	public void			showUI()
	{
		UI.alpha = 1;
		UI.interactable = true;
	}	
	
	void	OnTriggerStay(Collider col)
	{
		if (!this.isAlive())
			return ;
		if ( this.target == null && col.gameObject.tag == "Player")
			this.setCible(col.GetComponent<Humanoid>());
	}
	
	void	OnTriggerExit(Collider col)
	{
		if ( col.gameObject.tag == "Player")
			this.target = null;
	}
	
	void OnMouseEnter()
	{
		this.showUI();
	}
	
	void OnMouseExit()
	{
		this.hideUI();
	}
}
