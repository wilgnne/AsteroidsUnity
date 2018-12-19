using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ui
{
	public Text pointsText;
	public GameObject[] lifeImagens;
}

public class GameController : MonoBehaviour {
	public int life = 3;
	public int points = 0;

	public ui UI;

	void Start()
	{
		pointUpdate (0);
	}

	void Update()
	{
		if (life == 0) 
		{
			Time.timeScale = 0;
			FindObjectOfType<InputController> ().active = false;
		}
	}

	public void demege()
	{
		UI.lifeImagens [life-1].SetActive (false);
		life--;
	}

	public void pointUpdate(int point)
	{
		points += point;
		UI.pointsText.text = points.ToString();
	}
}
