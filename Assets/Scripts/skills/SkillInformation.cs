using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillInformation : MonoBehaviour {

	public Text nameSkill;
	public Text description;


	private string nameString = "name: ";
	private string descriptionString = "effects: ";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		nameSkill.text = nameString;
		description.text = descriptionString;
	}

	public void setText(string nameText, string descriptionText)
	{
		nameString = "name: "+nameText;
		descriptionString = "effects: "+descriptionText;
	}

}
