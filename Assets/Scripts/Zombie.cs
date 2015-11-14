using UnityEngine;
using System.Collections;

public class Zombie : Humanoid {

	void	Awake()
	{
		this.initHumanoid();
	}

	void	Update()
	{
		if (this.navAgent.enabled && !this.isAlive())
		{
			this.animator.SetInteger("HP", 0);
			this.animator.SetBool("attack", false);
			this.disableAll();
			return ;
		}
		else if (this.navAgent.enabled == false)
			return ;
		this.updateAnimation();
		
		this.updateWeapons();
	}

	private void		disableAll()
	{
		this.navAgent.enabled = false;
		this.GetComponent<SphereCollider>().enabled = false;
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
}
