using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Window : MonoBehaviour
{
	public bool					opened = false;
	protected CanvasGroup		canvas;
	protected KeyCode			key;

	protected void				InitWindow(KeyCode keyChoosen)
	{
		canvas = this.GetComponent<CanvasGroup>();
		key = keyChoosen;
		this.hide();
	}

	public void		updateWindow()
	{
		if (Input.GetKeyDown(key))
			this.switchOnOff();
	}
		
	public void		switchOnOff()
	{
		opened = !opened;
		canvas.alpha = (canvas.alpha + 1f) % 2;
		canvas.interactable = !canvas.interactable;
		this.GetComponent<Canvas>().sortingOrder = (int)canvas.alpha * 42;		
		
	}

	public void		show()
	{	
		opened = true;
		canvas.alpha = 1f;
		canvas.interactable = true;
		this.GetComponent<Canvas>().sortingOrder = 42;
	}

	public void		hide()
	{
		opened = false;
		canvas.alpha = 0f;
		canvas.interactable = false;
		this.GetComponent<Canvas>().sortingOrder = 0;		
	}
}
