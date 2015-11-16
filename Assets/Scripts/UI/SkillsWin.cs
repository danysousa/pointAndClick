using UnityEngine;
using System.Collections;

public class SkillsWin : Window {


	public int pointsLeft = 2;
	private bool isHover = false;
	// Use this for initialization
	void Start () {
		this.InitWindow(KeyCode.N);
	}
	
	// Update is called once per frame
	void Update () {
		this.updateWindow();
		if (isHover)
			displayInfoStay ();
	}

	public void displayInfoEnter(GameObject element)
	{
		RectTransform elem = element.GetComponent<RectTransform>(); 
		elem.localScale = elem.localScale * 1.2f;
		isHover = true;
	}

	public void displayInfoStay()
	{
			
	}

	public void displayInfoClick(GameObject element)
	{
		element.GetComponent<Skill> ().addLevel ();
	}

	public void displayExit(GameObject element)
	{
		RectTransform elem = element.GetComponent<RectTransform>(); 
		elem.localScale = elem.localScale / 1.2f;
		isHover = false;
	}
}
