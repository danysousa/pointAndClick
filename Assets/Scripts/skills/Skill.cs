using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skill : MonoBehaviour {
	
	public bool enabled = true;
	public int lvl = 0;
	public Skill nextSkill;
	private Text lvlText;
	private RectTransform image;
	private Color originalColor;

	// Use this for initialization
	void Start () {
		image = GetComponent<RectTransform> ();
		lvlText = GetComponentInChildren<Text> ();
		originalColor = image.GetComponent<Image> ().color;
	}
	
	// Update is called once per frame
	void Update () {
		lvlText.text = "" + lvl;
		if (enabled) {
			enableSkill();

		} else {
			disableSkill();
		}
	}

	private void disableSkill()
	{
		image.GetComponent<Image> ().color = Color.gray;
	}

	public void enableSkill()
	{
		image.GetComponent<Image> ().color = originalColor;
	}

	public void addLevel()
	{
		lvl++;

	}
}
