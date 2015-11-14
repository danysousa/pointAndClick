using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Maya : Humanoid {

	private Vector3		cameraDecalage = new Vector3(0.6f, -8.55f, 7f);

	public Text				hpUI;
	public RectTransform	hpBarUI;
	public Text				xpText;
	public Text				levelText;
	public RectTransform	xpBar;
	public PlayerManager	manager;

	private int				oldLevel;

	void Awake ()
	{
		this.initHumanoid();
		this.oldLevel = level;
	}
	
	void Update ()
	{
		this.updateUI();
		if (!this.isAlive())
		{
			this.animator.SetInteger("HP", HP);
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
			this.target.GetComponent<Zombie>().showUI();
	}

	private void	updateStat()
	{
		if (this.oldLevel != this.level)
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
		tmp *= 0.45f;

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
				point.collider.GetComponent<Zombie>().showUI();
				return;
			}
		}
		this.setDestination(lastChoice.point);

	}
}
