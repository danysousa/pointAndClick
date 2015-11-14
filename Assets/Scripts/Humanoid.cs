using UnityEngine;
using System.Collections;

public class Humanoid : MonoBehaviour {

	protected NavMeshAgent		navAgent;
	protected Animator			animator;
	protected float				minRangeAttack;
	protected Humanoid			target = null;
	protected int					HP;

	public Weapon[]				weapons;
	public int					damage;
	private int					Mindamage;
	private int					Maxdamage;

	public int					level = 0;
	public int					XP = 0;
	public int					money = 0;
	public int					Armor;
	public int					STR;
	public int					AGI;
	public int					CON;

	protected void		initHumanoid()
	{
		this.HP = 5 * CON;
		Mindamage = STR / 2;
		Mindamage = Mindamage + 4;
		this.navAgent = GetComponent<NavMeshAgent>();
		this.animator = GetComponent<Animator>();
		initMinRangeAttack();
	}

	private void		initMinRangeAttack()
	{
		this.minRangeAttack = 0f;
		if (weapons.GetLength(0) < 1)
			return ;

		this.minRangeAttack = weapons[0].rangeAttack;
		foreach (Weapon weapon in weapons)
		{
			if (this.minRangeAttack > weapon.rangeAttack)
				this.minRangeAttack = weapon.rangeAttack;
		}
	}

	protected void		setDestination(Vector3 dest)
	{
		this.navAgent.destination = dest;
		this.target = null;
	}

	private bool		canAttack()
	{
		Vector3			tmp;
		
		if (target == null || this.navAgent.enabled == false)
			return (false);
		tmp = target.transform.position - this.transform.position;
		this.navAgent.destination = this.target.transform.position;
		return ( (Mathf.Abs(tmp.magnitude) <= minRangeAttack) );
	}

	protected void		updateAnimation()
	{
		this.animator.SetBool("run", ( Mathf.Abs (this.navAgent.velocity.magnitude) > navAgent.speed / 1.5f ));
		this.animator.SetBool("attack", canAttack() && !this.animator.GetBool("run"));
			
		this.animator.SetInteger("HP", this.HP);
	}

	protected void		updateWeapons()
	{
		if (this.target != null && this.target.isAlive() == false)
			this.target = null;
		if (!canAttack())
			return;

		foreach (Weapon weapon in weapons)
		{
			if (weapon.hitSomeone())
			{
				int hit = 75 + AGI - weapon.getVictime().AGI;
				if ( Random.Range (0, 101) < hit)
					weapon.getVictime().receiveDamage( Random.Range (Mindamage, Maxdamage));
				weapon.disableDoubleHit();
			}
		}
	}

	protected void		setCible(Humanoid cible)
	{
		if (!cible.isAlive())
		{
			this.navAgent.destination = cible.transform.position;
			return ;
		}
		this.navAgent.destination = cible.GetComponent<NavMeshAgent>().transform.position;
		this.target = cible;
	}

	public bool			isAlive()
	{
		return (this.HP > 0);
	}

	public void		receiveDamage(int damage)
	{
		this.HP -= (damage  * (1 - Armor/200) );
	}

}
