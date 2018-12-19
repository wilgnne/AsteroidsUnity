using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour {
	Rigidbody2D _rb;
	CameraBehaviour _cb;
	InputController _input;

	public int life;

	public float dalayToFire, speed, eulerAngle;
	public Transform bulletPosition;
	public GameObject bullet;

	float xmod, ymod;

	bool fire;


	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D>();
		_cb = FindObjectOfType<CameraBehaviour>();
		_input = FindObjectOfType<InputController>();
		transform.position = (Vector2)_cb.transform.position;

		xmod = _cb.xmod;
		ymod = _cb.ymod;
		fire = true;
	}
	
	// Update is called once per frame
	void Update () {
		_rb.velocity = transform.up * speed * (_input.thust ? 1:0);

		transform.Rotate(new Vector3(0,0, eulerAngle * -_input.horzontal));

		if(_input.fire && fire)
		{
			StartCoroutine(WaitFire(dalayToFire));
		}

		float xPos = (transform.position.x) % xmod;
		float yPos = (transform.position.y) % ymod;
		if(xPos < 0 && xmod > 0)
			xPos = xmod - xPos;
		if(yPos < 0 && ymod > 0)
			yPos = ymod - yPos;
		
		transform.position = new Vector2(xPos, yPos);
	}

	private IEnumerator WaitFire(float waitTime)
    {
		Instantiate(bullet, bulletPosition.position, transform.rotation);
		fire = false;
        yield return new WaitForSeconds(waitTime);
        fire = true;
    }

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Asteroid")
		{
			FindObjectOfType<GameController> ().demege ();
			transform.position = (Vector2)_cb.transform.position;
		}
	}
}
