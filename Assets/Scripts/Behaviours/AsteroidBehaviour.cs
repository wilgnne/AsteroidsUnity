using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AsteroidBehaviour : MonoBehaviour {
	Rigidbody2D _rb;
	CameraBehaviour _cam;
	public float velocity = 1f;
	public int points;

	public bool isMeteorit;
	public GameObject meteorit;

	void Start()
	{
		_cam = FindObjectOfType<CameraBehaviour>();

		if(!isMeteorit)
		{
			if(transform.position.y >_cam.transform.position.y)
			{
				if(transform.position.x > _cam.transform.position.x)
				{
					transform.Rotate(new Vector3(0,0,Random.Range(90f,180f)));
				}
				else
				{
					transform.Rotate(new Vector3(0,0,Random.Range(180f,270f)));
				}
			}
			else
			{
				if(transform.position.x > _cam.transform.position.x)
				{
					transform.Rotate(new Vector3(0,0,Random.Range(0f,90f)));
				}
				else
				{
					transform.Rotate(new Vector3(0,0,Random.Range(270f,360f)));
				}
			}
		}
		else{
			transform.Rotate(new Vector3(0,0,Random.Range(0f,360f)));
		}

		_rb = GetComponent<Rigidbody2D>();
		_rb.velocity = transform.up * velocity;
	}

	void Update()
	{
		if(transform.position.x > _cam.direira.x + 5 || transform.position.x < _cam.esquerda.x - 5 ||
		transform.position.y > _cam.direira.y + 5 || transform.position.y < _cam.esquerda.y - 5)
		{
			isMeteorit = true;
			Destroy();
		}
	}

	public void Destroy()
	{
		if(!isMeteorit)
		{
			Instantiate(meteorit, transform.position, Quaternion.identity, transform.parent);
			Instantiate(meteorit, transform.position, Quaternion.identity, transform.parent);
		}
		Destroy(gameObject);
	}
}