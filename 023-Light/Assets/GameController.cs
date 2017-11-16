using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	float timer = 0;
	int currentLight = 0;

	public Light[] lights;

	// Use this for initialization
	void Start () {
		foreach(Light light in lights) {
			light.intensity = 0;
		}
		lights[currentLight].intensity = 5;
		FireTimer();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			lights[currentLight].intensity = 0;
			currentLight = Random.Range(0, lights.Length);
			lights[currentLight].intensity = 5;
			FireTimer();
		}		
	}

	void FireTimer() {
		timer = Random.Range(3f, 8f);
	}
}
