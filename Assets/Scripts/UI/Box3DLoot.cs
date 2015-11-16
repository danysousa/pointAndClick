using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Box3DLoot : MonoBehaviour {

	public bool					opened = false;
	protected CanvasGroup		canvas;

	public Text					damage;
	public Text					subname;
	public Text					speed;
	
	void			Start()
	{
		canvas = this.GetComponent<CanvasGroup>();
		this.hide();
	}
	
	void			Update()
	{
	}
	
	public void		switchOnOff()
	{
		opened = !opened;
		canvas.alpha = (canvas.alpha + 1f) % 2;
		canvas.interactable = !canvas.interactable;
	}
	
	public void		show()
	{	
		opened = true;
		canvas.alpha = 1f;
		canvas.interactable = true;
	}
	
	public void		hide()
	{
		opened = false;
		canvas.alpha = 0f;
		canvas.interactable = false;
	}
}