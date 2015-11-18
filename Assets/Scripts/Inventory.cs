using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	private List<LootMemory>	loot = new List<LootMemory>();
	public int					size = 12;

	public bool			addLoot(Loot obj)
	{
		if (loot.Count > this.size)
			return (false);

		loot.Add ( Loot.toMemory(obj) );
		GameObject.Destroy(obj.gameObject);
		return (true);
	}

	public List<LootMemory>		getItems()
	{
		return (loot);
	}
}
