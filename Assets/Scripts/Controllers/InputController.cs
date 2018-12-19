using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

	public enum _controller{Thouch, Teclado};

	public _controller controller;

	public GameObject UI;

	public bool active = true;

	[System.NonSerialized]
	public float horzontal, vertical;
	[System.NonSerialized]
	public bool fire, thust;

	public void Start()
	{
		if (controller == _controller.Thouch)
			UI.SetActive (true);
		else
			UI.SetActive (false);
	}

	public void Update()
	{
		if (controller == _controller.Teclado) 
		{
			pressHorizontal(Input.GetAxis("Horizontal"));
			pressVertical (Input.GetAxis ("Vertical"));
			pressFire(Input.GetButton("Jump"));
			pressThust (Input.GetAxis ("Vertical") > 0 ? true : false);
		}
	}

	public void pressHorizontal(float _horizontal)
	{
		if(active)
			horzontal = _horizontal;
	}

	public void pressVertical(float _vertical)
	{
		if(active)
			vertical = _vertical;
	}

	public void pressFire(bool _fire)
	{
		if(active)
			fire = _fire;
	}

	public void pressThust(bool _thust)
	{
		if(active)
			thust = _thust;
	}
}
