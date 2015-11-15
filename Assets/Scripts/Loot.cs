using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Loot : MonoBehaviour
{
	public Texture[]	sprite;
	public Weapon		weapon;

	public int			damage;
	public float		speed;
	public string		rank;
	private bool		onInventory = false;

	void Start ()
	{
		
	}

	void Update ()
	{
		
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonUp(0))
		{
			if (!onInventory)
				this.addOnInventory();
			else
				this.equip();
			Debug.Log (name);
		}
	}

	private void	addOnInventory()
	{
		onInventory = true;
		PlayerManager.instance.inventory.addLoot(this);
	}

	private void	equip()
	{
		//onInventory = true;
	}

	public static LootMemory		toMemory(Loot cpy)
	{
		LootMemory result = new LootMemory();

		result.damage = cpy.damage;
		result.speed = cpy.speed;
		result.rank = cpy.rank;
		result.weapon = cpy.weapon;
		result.sprite = cpy.sprite;

		return (result);
	}
}
