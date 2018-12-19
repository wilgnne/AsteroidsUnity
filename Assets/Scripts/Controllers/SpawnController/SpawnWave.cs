using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnWave
{
	[Range(0f,100f)]
	public float frequency;
	public AnimationCurve decayFunction = AnimationCurve.Constant(0f,1f,1f);
	public float waveDuration;
	private float _frequency;

	public float getFrequency () 
    {
        return _frequency;
    }
	public void setFrequency (float __frequency)
    {
        _frequency = __frequency;
    }
}