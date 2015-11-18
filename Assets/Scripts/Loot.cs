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
	public string		subname;

	public AudioClip	sound;

	public Box3DLoot	boxPrefab;

	private Box3DLoot	box;

	void Start ()
	{
		this.box = GameObject.Instantiate(boxPrefab);
		this.box.transform.position = this.transform.position + Vector3.up;
		this.box.damage.text = damage.ToString();
		this.box.speed.text = speed.ToString();
		this.box.subname.text = subname + " (" + rank + ")";
	}

	void Update ()
	{
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonUp(0))
		{
			this.addOnInventory();
		}
		this.showBox();
	}

	void OnMouseExit()
	{
		this.box.hide();
	}

	private void	showBox()
	{
		this.box.show();
	}

	private void	addOnInventory()
	{
		GameObject.Destroy(this.box.gameObject);
		Camera.main.GetComponent<AudioSource>().PlayOneShot(this.sound);
		PlayerManager.instance.inventory.addLoot(this);
	}

	private void	equip()
	{
	}

	public static LootMemory		toMemory(Loot cpy)
	{
		LootMemory result = new LootMemory();

		result.damage = cpy.damage;
		result.speed = cpy.speed;
		result.rank = cpy.rank;
		result.weapon = cpy.weapon;
		result.sprite = cpy.sprite;
		result.subname = cpy.subname;

		return (result);
	}
}
