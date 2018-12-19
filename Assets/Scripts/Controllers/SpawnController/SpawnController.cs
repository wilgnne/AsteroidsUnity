using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
	//public SpawnObject[] spawnObjects;
	public List<SpawnObject> spawnObjects = new List<SpawnObject>();

	CameraBehaviour _cam;

	[System.NonSerialized]
	public Vector2 esquerda, direita;

	// Use this for initialization
	void Start () {
		_cam = FindObjectOfType<CameraBehaviour>();
		esquerda = _cam.esquerda - new Vector2(1,1);
		direita = _cam.direira + new Vector2(1,1);

		foreach (SpawnObject item in spawnObjects)
		{
			GameObject o = Instantiate(new GameObject(), transform);
			o.name = item.name;
			if(item.proceduralWaves)
			{
				item.nextWave();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (SpawnObject item in spawnObjects)
		{
			item.setTime(item.getTime() + Time.deltaTime);

			float time = item.getTime()/item.spawnWave.waveDuration;
			item.spawnWave.setFrequency(item.spawnWave.frequency*(item.spawnWave.decayFunction.Evaluate(time)));

			if(item.getTime() > item.spawnWave.waveDuration)
			{
				if(transform.Find(item.name).childCount == 0)
					item.nextWave();
				return;
			}

			if(Random.Range(0f, 100f) <= item.spawnWave.getFrequency())
			{
				Vector2 pos = new Vector2();
				switch (Random.Range(0,4))
				{
					case 0:
						pos = new Vector2(Random.Range(esquerda.x, direita.x), direita.y);
						break;
					case 1:
						pos = new Vector2(Random.Range(esquerda.x, direita.x), esquerda.y);
						break;
					case 2:
						pos = new Vector2(esquerda.x, Random.Range(esquerda.y, direita.y));
						break;
					case 3:
						pos = new Vector2(direita.x, Random.Range(esquerda.y, direita.y));
						break;
					default:
						Debug.Log("Error in random(0, 3)");
						break;
				}
				Instantiate(item.prefab, pos, Quaternion.identity,transform.Find(item.name));
			}
		}
	}
}
