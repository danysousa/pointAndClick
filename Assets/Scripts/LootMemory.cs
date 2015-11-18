using UnityEngine;
using System.Collections;

public class LootMemory
{

	public Texture[]	sprite;
	public Weapon		weapon;
	
	public string		subname;
	public int			damage;
	public float		speed;
	public string		rank;

	private int			id_rank = -1;

	private void		defineRank()
	{
		string[]	ranks = {"Commun", "Mystique", "Rare", "Legendaire"};
		int			i = 0;

		while (i < ranks.GetLength(0))
		{
			if (ranks[i] == rank)
				break;
			i++;
		}
		id_rank = i;
	}

	public Texture		getSprite()
	{
		if (id_rank == -1)
			this.defineRank();
		if (sprite.GetLength(0) >= id_rank)
			return (sprite[id_rank]);
		return (null);
	}

	public LootMemory	cpy()
	{
		LootMemory		result = new LootMemory();
		result.sprite = this.sprite;
		result.weapon = this.weapon;
		result.subname = this.subname;
		result.damage = this.damage;
		result.speed = this.speed;
		result.rank = this.rank;

		return result;
	}

}
