using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryWin : Window {

	public RawImage[]		slot;
	public BoxInventory		box;
	public Vector3			tmpPosition;

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
		foreach (RawImage img in slot)
		{
			img.texture = null;
			img.color = new Color(1f,1f,1f, 4f/255f);
		}
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
		this.box.subname.text = loot[i].subname + " (" + loot[i].rank + ")";
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

	public void			equip(int rank)
	{
		LootMemory	tmp;

		if (rank >= loot.Count)
			return;
		tmp = PlayerManager.instance.player.equipWeapon(loot[rank]);
		PlayerManager.instance.inventory.getItems().RemoveAt(rank);
		if (tmp != null)
			PlayerManager.instance.inventory.getItems().Add(tmp);
		loot = PlayerManager.instance.inventory.getItems();
		slot[rank].texture = null;
		slot[rank].color = new Color(1f,1f,1f, 4f/255f);

		this.updateSlot();
		this.box.hide ();
	}

}
