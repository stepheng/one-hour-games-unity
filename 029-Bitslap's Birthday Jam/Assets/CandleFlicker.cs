using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleFlicker : MonoBehaviour {

	Light light;
	public float flickerPercentage = 0.7f;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range(0.0f, 1.0f) > flickerPercentage) {
			light.intensity = Random.Range(1.5f, 2.5f);
		}
	}
}
