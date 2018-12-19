using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curveProce : MonoBehaviour {

	public AnimationCurve curve;
	public float reso;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Keyframe[] frame = new Keyframe[100];

		for (int i = 0; i < 100; i++)
		{
			frame[i] = new Keyframe(i, Mathf.PerlinNoise(0,i/Mathf.Sqrt(reso)));
		}
		curve = new AnimationCurve(frame);
		
	}
}
