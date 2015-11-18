using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Maya : Humanoid {

	private Vector3		cameraDecalage = new Vector3(0.6f, -8.55f, 6f);

	public Text				hpUI;
	public RectTransform	hpBarUI;
	public Text				xpText;
	public Text				levelText;
	public RectTransform	xpBar;
	public PlayerManager	manager;
	public GameObject		hand;
	public RawImage			imgWeapon;

	private LootMemory		weaponMemory = null;
	private int				oldLevel;
	private Vector3			initialPos;

	void Awake ()
	{
		this.initialPos = this.transform.position;
		this.initHumanoid();
		this.oldLevel = level;
	}
	
	void Update ()
	{
		this.updateUI();
		if (!this.isAlive())
		{
			this.animator.SetInteger("HP", HP);
			StartCoroutine(respawn());
			return;
		}
		this.updateCamera();
		if (manager.haveWindowOpened())
			return;
		if (Input.GetMouseButton(0))
			this.chooseAction();
		this.updateAnimation();
		this.updateWeapons();
		this.updateStat();
		if (this.target != null)
		{
			if ( this.target.GetComponent<Zombie>() != null)
				this.target.GetComponent<Zombie>().showUI();
			else if (this.target.GetComponent<ZombieBoss>() != null)
				this.target.GetComponent<ZombieBoss>().showUI();
		}
	}

	private IEnumerator	respawn()
	{
		this.target = null;
		this.HP = maxHP;
		yield return new WaitForSeconds(3);
		this.transform.position = initialPos;
		this.animator.SetInteger("HP", HP);
	}

	private void	updateStat()
	{
		if (this.oldLevel < this.level)
			this.manager.levelUp();

		this.oldLevel = level;
		this.maxHP = 5 * CON;
		Mindamage = STR / 2;
		Maxdamage = Mindamage + 4;
		if (maxHP < HP)
			HP = maxHP;
	}

	private void	updateUI()
	{
		float tmp = HP;
		/*
		 * HP 
		 */
		if (HP < 0)
			tmp = 0;
		hpUI.text = HP.ToString();

		tmp /= maxHP;
		tmp *= (0.45f - 0.135f);
		tmp += 0.135f;

		hpBarUI.anchorMax = new Vector2( tmp, hpBarUI.anchorMax.y );

		/*
		 * XP 
		 */
		this.defineLevel();
		xpText.text = XP +  "/" + XPForCurrentLevel;
		
		tmp = (float)XP / (float)XPForCurrentLevel;
		
		xpBar.anchorMax = new Vector2( tmp, 0.02f );
		levelText.text = this.level.ToString();
	}

	private void	chooseAction()
	{
		RaycastHit[] hit; 
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		hit = Physics.RaycastAll (ray, 100.0f);

		if (hit.GetLength(0) > 0)
		{
			foreach (RaycastHit point in hit)
			{
				Vector3		tmp = point.point - point.collider.gameObject.transform.position;

				if (point.collider.gameObject.tag == "Ennemy" && point.collider.GetComponent<Humanoid>().isAlive() && Mathf.Abs(tmp.magnitude) < 3f)
				{
					this.ennemyDestination(hit);
					return;
				}
				else if (point.collider.gameObject.tag == "Terrain")
					hit[0] = point;

			}
			this.setDestination(hit[0].point);
		}
	}

	private void 	updateCamera()
	{
		Camera.main.transform.position = this.transform.position - cameraDecalage;
	}

	private void	ennemyDestination(RaycastHit[] hit)
	{
		RaycastHit	lastChoice = hit[0];

		foreach (RaycastHit point in hit)
		{
			if (point.collider.gameObject.tag != "Ennemy")
				continue ;
			Vector3		tmp = point.point - point.collider.gameObject.transform.position;
			
			if (Mathf.Abs(tmp.magnitude) > 1.8f)
				lastChoice = point;
			else
			{
				this.setCible(point.collider.GetComponent<Humanoid>());
				if (point.collider.GetComponent<Zombie>() != null)
					point.collider.GetComponent<Zombie>().showUI();
				else if (point.collider.GetComponent<ZombieBoss>() != null)
					point.collider.GetComponent<ZombieBoss>().showUI();
	
				return;
			}
		}
		this.setDestination(lastChoice.point);

	}

	public LootMemory	equipWeapon(LootMemory loot)
	{
		LootMemory oldWeaponMemory = weaponMemory;

		foreach (Weapon w in weapons)
			Destroy(w.gameObject);

		weapons[0] = GameObject.Instantiate(loot.weapon);
		weapons[0].damage = loot.damage;
		weapons[0].transform.SetParent(this.hand.transform.parent);
		weapons[0].transform.localPosition = loot.weapon.transform.position;
		weapons[0].transform.localScale = loot.weapon.transform.localScale;
		weapons[0].transform.localRotation = loot.weapon.transform.rotation;
		imgWeapon.texture = loot.getSprite();
		weaponMemory = loot.cpy();

		return (oldWeaponMemory);
	}

	public void			takePotion()
	{
		this.HP += (maxHP / 10);
		if (this.HP > maxHP)
			this.HP = maxHP;
	}

	public void			cheatUp()
	{
		if (manager.getCheatMode() == false)
			return;

		this.level += 1;
		HP = maxHP;
	}

	public void			cheatDown()
	{
		if (manager.getCheatMode() == false || this.level == 0)
			return;
		
		this.level -= 1;
		HP = maxHP;
	}
}
