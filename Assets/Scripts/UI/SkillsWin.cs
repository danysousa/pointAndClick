using UnityEngine;
using System.Collections;

public class SkillsWin : Window {

	public GameObject skillTooltip;
	public int pointsLeft = 2;

	private CanvasGroup tooltip;
	private GameObject currentElement;
	private bool isHover = false;
	// Use this for initialization
	void Start () {
		this.InitWindow(KeyCode.N);
		tooltip = skillTooltip.GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.updateWindow();
	}

	public void displayInfoEnter(GameObject element)
	{
		if (element != null && element.GetComponent<Skill> ().isEnabled) {
			RectTransform elem = element.GetComponent<RectTransform> (); 
			elem.localScale = elem.localScale * 1.2f;
		}
		currentElement = element;
		activateToolTip ();

	}

	public void displayExit(GameObject element)
	{
		if (element != null && element.GetComponent<Skill> ().isEnabled) {
			RectTransform elem = element.GetComponent<RectTransform> (); 
			elem.localScale = elem.localScale / 1.2f;
		}
		deactivateToolTip ();
		currentElement = null;
	}
	
	private void activateToolTip()
	{
		isHover = true;
		if (currentElement != null) {
			float tooltipWidth = skillTooltip.GetComponent<RectTransform>().rect.width;
			float iconWidth = currentElement.GetComponent<RectTransform>().rect.width;
			Vector3 tmp = currentElement.transform.position;
			tmp.x += tooltipWidth/2 + iconWidth*2;
			tooltip.transform.position = tmp;
			skillTooltip.GetComponent<SkillInformation>().setText(currentElement.GetComponent<Skill> ().getNameSkill(),currentElement.GetComponent<Skill> ().getEffetSkill());
			tooltip.alpha = 1f;
		}
	}

	private void deactivateToolTip()
	{
		isHover = false;
		tooltip.alpha = 0f;
	}


}
