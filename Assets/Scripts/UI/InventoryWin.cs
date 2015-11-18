using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryWin : Window {

	public RawImage[]		slot;
	public BoxInventory		box;

	List<LootMemory>	loot;
	
	void Start ()
	{
		this.InitWindow(KeyCode.I);
	}
	
	void Update ()
	{
		this.updateWindow();
		if (this.opened)
			loot = PlayerManager.instance.inventory.getItems();
		this.updateSlot();
	}

	private void	updateSlot()
	{
		if (this.opened == false)
			return;

		int					i = 0;
		foreach (LootMemory obj in loot)
		{
			if (i > slot.GetLength(0))
				return;
			slot[i].texture = obj.getSprite();
			slot[i].color = Color.white;
			i++;
		}
	}
		
	public void			showBox(int i)
	{
		loot = PlayerManager.instance.inventory.getItems();
		if (i >= loot.Count)
			return;
		this.box.subname.text = loot[i].subname;
		this.box.damage.text = loot[i].damage.ToString();
		this.box.speed.text = loot[i].speed.ToString();
		this.box.show();
	}

	public void			hideBox(int rank)
	{
		loot = PlayerManager.instance.inventory.getItems();
		if (rank >= loot.Count)
			return;
		this.box.hide();
	}
}
