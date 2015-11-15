﻿using UnityEngine;
using System.Collections;

public class LootSystem : MonoBehaviour {

	public Maya		player;
	public Loot[]	loots;

	private static LootSystem	inst;

	public static LootSystem	instance
	{
		get
		{
			if (inst == null)
				return new LootSystem();
			return inst;
		}
	}

	void Awake ()
	{
		LootSystem.inst = this;
	}

	public void		createLootsHere(Vector3 pos)
	{
		this.lootWeapon(pos);
		this.lootPotion(pos);
	}

	private void	lootPotion(Vector3 pos)
	{
		return;
	}
	

	private void	lootWeapon(Vector3 pos)
	{
		int		i;
		Loot	tmp;
		string[]	rank = {"Commun", "Commun", "Commun", "Commun", "Mystique", "Mystique","Mystique", "Rare", "Rare", "Legendaire"};
		
		i = Random.Range(0, loots.GetLength(0) * 4);		
		if (i >= loots.GetLength(0))
			return ;
		
		tmp = GameObject.Instantiate(loots[i]);
		tmp.transform.position = pos + Vector3.up * 0.8f;
		i = Random.Range(0, rank.GetLength(0));
		tmp.damage = tmp.damage + player.getLevel() * 10 + Random.Range(0, i * 3);
		tmp.speed = tmp.speed + (float)i / 10;
		tmp.rank = rank[i];
	}
}
