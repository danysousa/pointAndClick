using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Skill : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	public bool isEnabled = true;
	public int lvlEnabled = 0;
	public int lvl = 0;
	public string nameSkill;
	public string effects;

	public static GameObject itemBeingDragged;
	private Vector3 startPosition;

	private Text lvlText;
	private RectTransform image;
	private Color originalColor;


	// Use this for initialization
	public void Start () {
		image = GetComponent<RectTransform> ();
		lvlText = GetComponentInChildren<Text> ();
		originalColor = image.GetComponent<Image> ().color;
	}
	
	// Update is called once per frame
	public void Update () {
		lvlText.text = "" + lvl;
		if (isEnabled) {
			enableSkill();
		} else {
			disableSkill();
		}

		if (PlayerManager.instance.player.getLevel () >= lvlEnabled)
			isEnabled = true;
	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{	if (isEnabled) {
			itemBeingDragged = gameObject;
			startPosition = transform.position;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		if (isEnabled)
			transform.position = Input.mousePosition;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		if (isEnabled) {
			itemBeingDragged = null;
			GetComponent<CanvasGroup> ().blocksRaycasts = true;
			transform.position = startPosition;
		}
	}

	#endregion

	private void disableSkill()
	{
		image.GetComponent<Image> ().color = Color.gray;
	}

	public void enableSkill()
	{
		image.GetComponent<Image> ().color = originalColor;
	}

	public void addLevel(GameObject elem)
	{
	}

	public string getNameSkill()
	{
		return this.nameSkill;
	}
	
	public string getEffetSkill()
	{
		return this.effects;
	}

	virtual public void useSkill()
	{
		Debug.Log ("#here#");
	}	
	virtual public void disableSkillEffect()
	{
	}
}
