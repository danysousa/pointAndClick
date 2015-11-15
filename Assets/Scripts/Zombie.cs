using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Zombie : Humanoid {

	public Text				levelText;
	public RectTransform	lifeBar;
	public CanvasGroup		UI;
	

	void	Awake()
	{
		this.initHumanoid();
		this.hideUI();
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
		this.updateAnimation();
		this.updateWeapons();
		this.updateUI();
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
