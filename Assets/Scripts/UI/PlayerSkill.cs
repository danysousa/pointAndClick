using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerSkill : MonoBehaviour, IDropHandler {
	
	private Skill currentSkill;
	public int keycodeNumber = 1;
	public RectTransform loading;
	private float top = 0f;
	private int step;
	private bool isUsed = false;

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		if (currentSkill != null)
			currentSkill.disableSkillEffect ();
		currentSkill = Skill.itemBeingDragged.GetComponent<Skill>();
		if (currentSkill.lvl > 0) {
			step = currentSkill.lvl;
			top = 0f;
			isUsed = false;
			GetComponent<Image> ().sprite = Skill.itemBeingDragged.GetComponent<Image> ().sprite;
		} else
			currentSkill = null;
	}
	#endregion

	public bool getKeyPressed()
	{
		if (keycodeNumber == 1 && Input.GetKeyDown (KeyCode.Alpha1))
			return true;
		if (keycodeNumber == 2 && Input.GetKeyDown (KeyCode.Alpha2))
			return true;
		if (keycodeNumber == 3 && Input.GetKeyDown (KeyCode.Alpha3))
			return true;
		if (keycodeNumber == 4 && Input.GetKeyDown (KeyCode.Alpha4))
			return true;
		return false;
	}

	void Update ()
	{
		if (!isUsed && getKeyPressed()) {
			if (currentSkill != null)
			{
				currentSkill.useSkill();
				top = 0f;
				loading.offsetMax = new Vector2(0f, top);
				isUsed = true;
			}
		}
		if (top > -45f && isUsed) {
			top -= 0.01f * step;
			loading.offsetMax = new Vector2 (0f, top);
		} else
			isUsed = false;

	}
	

}
