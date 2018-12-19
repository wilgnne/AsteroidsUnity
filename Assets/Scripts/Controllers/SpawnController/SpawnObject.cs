using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnObject
{
	public string name = "New Object";
	public GameObject prefab;
	public bool proceduralWaves;
	int attSpawnWave = -1;
	public SpawnWave spawnWave = new SpawnWave();
	//public SpawnWave[] spawnWaves;
	public List<SpawnWave> spawnWaves = new List<SpawnWave>();

	float _time;
	public float getTime ()
    {
        return _time;
    }
	public void setTime (float time)
    {
        _time = time;
    }

	public void nextWave () 
    {
		attSpawnWave += 1;
		if(proceduralWaves) 
        {
			Keyframe[] frame = new Keyframe[100];
			for (int i = 0; i < 100; i++)
			{
				float cord = (float) (i/512f) * 5f;
				float perlin = Mathf.PerlinNoise(Random.Range(int.MinValue, int.MaxValue), cord);
				frame[i] = new Keyframe(i/100.0f, perlin);
			}
			spawnWave.decayFunction = new AnimationCurve(frame);
			_time = 0;
		}
		else if(attSpawnWave <= spawnWaves.Count)
        {
			spawnWave = spawnWaves[attSpawnWave];
			_time = 0;
		}
	}
}