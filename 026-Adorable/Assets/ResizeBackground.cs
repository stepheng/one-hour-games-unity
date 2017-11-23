using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float width = Screen.width / 768f;
		float height = Screen.height / 768f;
		transform.localScale = new Vector3(width, height, 1);
		Debug.Log("Scale: " + width + ", " + height + " - " + Screen.width + ", " + Screen.height);		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
