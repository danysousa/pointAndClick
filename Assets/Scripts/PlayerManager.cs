using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	
	public Maya				player;
	public CompetenceWin	competences;
	public SkillsWin		skills;
	public Inventory		inventory;
	public InventoryWin		inventoryWin;

	private static PlayerManager	inst;
	public static PlayerManager		instance
	{
		get
		{
			if (inst == null)
				return new PlayerManager();
			return inst;
		}
	}

	void Awake ()
	{
		PlayerManager.inst = this;
	}

	void Start ()
	{
		this.competences.agility = this.player.AGI;
		this.competences.strength = this.player.STR;
		this.competences.constitution = this.player.CON;
	}
	
	void Update ()
	{
		this.updateCompetences();
	}

	private void	updateCompetences()
	{
		this.player.AGI = this.competences.agility;
		this.player.CON = this.competences.constitution;
		this.player.STR = this.competences.strength;
	}

	public void		levelUp()
	{
		this.competences.pointCompetence += 5;
	}

	public bool		haveWindowOpened()
	{
		return (competences.opened || inventoryWin.opened);
	}
}
