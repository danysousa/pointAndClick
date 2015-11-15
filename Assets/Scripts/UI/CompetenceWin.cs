using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CompetenceWin : Window {

	public Text			STR;
	public Text			AGI;
	public Text			CONST;

	public int			strength = 0;
	public int			agility = 0;
	public int			constitution = 0;

	public int			pointCompetence = 0;

	public CanvasGroup	indicator;

	void Start ()
	{
		this.InitWindow(KeyCode.C);
	}
	
	void Update ()
	{
		this.updateWindow();
		this.updateText();
		this.updateIndicator();
	}

	void updateText()
	{
		STR.text = strength.ToString();
		AGI.text = agility.ToString();
		CONST.text = constitution.ToString();
	}

	private void	updateIndicator()
	{
		if (this.pointCompetence > 0)
		{
			this.indicator.alpha = 1f;
			this.indicator.interactable = true;
		}
		else
		{
			this.indicator.alpha = 0f;
			this.indicator.interactable = false;
		}
	}

	public void		addSTR()
	{
		if (pointCompetence > 0)
		{
			strength +=1;
			pointCompetence -= 1;
		}
	}

	public void		addAGI()
	{
		if (pointCompetence > 0)
		{
			agility +=1;
			pointCompetence -= 1;
		}
	}

	public void		addCONST()
	{
		if (pointCompetence > 0)
		{
			constitution +=1;
			pointCompetence -= 1;
		}
	}

	public void		delSTR()
	{
		strength -=1;
		pointCompetence += 1;
	}
	
	public void		delAGI()
	{
		agility -=1;
		pointCompetence += 1;
	}
	
	public void		delCONST()
	{
		pointCompetence += 1;
		constitution -=1;
	}
}
