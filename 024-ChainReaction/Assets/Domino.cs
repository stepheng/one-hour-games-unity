using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino : MonoBehaviour {

	Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();		
		rigidbody.centerOfMass = new Vector3(0, -0.5f, 0);
	}
	
	// Update is called once per frame
	void Update () {		
		if (Input.GetKeyDown(KeyCode.Space)) {
			RaycastHit hit;                
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				if (hit.transform.gameObject == this.gameObject) {
            		rigidbody.AddForceAtPosition(new Vector3(0, 1, 0), transform.forward * 100);
				}
			}
        }
	}
}
