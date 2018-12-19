using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraBehaviour : MonoBehaviour {
	Camera _cam;
	public Vector2 esquerda, direira;

	public float xmod, ymod;

	void Awake()
	{
		_cam = GetComponent<Camera>();
		esquerda = _cam.ScreenToWorldPoint(new Vector2(0,0));
		direira = _cam.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
		xmod = direira.x - esquerda.x;
		ymod = direira.y - esquerda.y;

		transform.Translate(new Vector2(xmod/2, ymod/2));
		
		esquerda = _cam.ScreenToWorldPoint(new Vector2(0,0));
		direira = _cam.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
	}
}
