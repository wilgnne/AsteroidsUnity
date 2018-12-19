using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletBehaviour : MonoBehaviour {
	CameraBehaviour _cam;
	Rigidbody2D _rb;
	AudioSource _as;
	public float speed;

	// Use this for initialization
	void Start () {
		_cam = FindObjectOfType<CameraBehaviour>();
		_rb = GetComponent<Rigidbody2D>();
		_as = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if((transform.position.x > _cam.direira.x || transform.position.x < _cam.esquerda.x ||
		transform.position.y > _cam.direira.y || transform.position.y < _cam.esquerda.y) && _as.isPlaying == false)
			Destroy(gameObject);
		
		_rb.velocity = transform.up * speed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Asteroid")
		{
			FindObjectOfType<GameController> ().pointUpdate (other.GetComponent<AsteroidBehaviour> ().points);
			other.GetComponent<AsteroidBehaviour>().Destroy();
			Destroy(gameObject);
		}
	}
}
