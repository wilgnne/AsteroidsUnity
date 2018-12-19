using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AreaEffector2D))]
public class AreaEffectorBehaviour : MonoBehaviour {
	AreaEffector2D _area;
	InputController _input;
	public Transform player;

	// Use this for initialization
	void Start () {
		_area = GetComponent<AreaEffector2D>();
		BoxCollider2D box = GetComponent<BoxCollider2D>();
		CameraBehaviour camera = FindObjectOfType<CameraBehaviour>();
		_input = FindObjectOfType<InputController>();
		box.size = new Vector2(camera.xmod, camera.ymod);
		transform.position = (Vector2)camera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(_input.thust)
		{
			_area.forceAngle = player.eulerAngles.z+90;
		}
	}
}
