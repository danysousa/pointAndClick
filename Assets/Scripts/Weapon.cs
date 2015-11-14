using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	private bool		hitEnemmy;
	private Humanoid	victime;
	private string		tagEnemmy;
	
	public float		rangeAttack = 2f;

	void Awake()
	{
		if (tag == "Player")
			tagEnemmy = "Ennemy";
		else
			tagEnemmy = "Player";
	}

	void OnTriggerEnter(Collider col)
	{
		if ( col.gameObject.tag == tagEnemmy )
		{
			this.hitEnemmy = true;
			this.victime = col.gameObject.GetComponent<Humanoid>();
		}
	}

	void OnTriggerExit(Collider col)
	{
		if ( col.gameObject.tag == tagEnemmy )
		{
			this.hitEnemmy = false;
			this.victime = null;
		}
	}

	public Humanoid		getVictime()
	{
		return (this.victime);
	}

	public bool			hitSomeone()
	{
		return (hitEnemmy);
	}

	public void			disableDoubleHit()
	{
		this.hitEnemmy = false;
		this.victime = null;
	}
}
