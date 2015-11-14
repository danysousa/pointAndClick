using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Maya : Humanoid {

	private Vector3		cameraDecalage = new Vector3(0.6f, -8.55f, 7f);
	private int			maxHP;

	public Text				hpUI;
	public RectTransform	hpBarUI;

	void Awake ()
	{
		this.initHumanoid();
		maxHP = HP;
	}
	
	void Update ()
	{

		hpUI.text = HP.ToString();
		float tmp = HP;
		tmp /= maxHP;
		tmp *= 0.35f;
		tmp += 0.15f;
		hpBarUI.anchorMax = new Vector2( tmp, hpBarUI.anchorMax.y );
		if (!this.isAlive())
		{
			this.animator.SetInteger("HP", HP);
			return;
		}
		if (Input.GetMouseButton(0))
			this.chooseAction();
		this.updateCamera();
		this.updateAnimation();
		this.updateWeapons();
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
				return;
			}
		}
		this.setDestination(lastChoice.point);

	}
}
