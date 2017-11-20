using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	private Rigidbody rigidbody;
	private bool is_grounded = false;
	private int jump_timer = 0;
	// Use this for initialization

	void Start () {
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		float hspeed = 10f;
		if (jump_timer <= 0) {
			if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f)) {
				is_grounded = true;
			} else {				
				hspeed = 5f;
			}
		}

		if (Input.GetKey(KeyCode.A)) {
			rigidbody.AddRelativeForce(Vector3.left * hspeed, ForceMode.Acceleration);
		} else if (Input.GetKey(KeyCode.D)) {
			rigidbody.AddRelativeForce(Vector3.right * hspeed, ForceMode.Acceleration);			
		}
		if (is_grounded && jump_timer <= 0 && Input.GetKey(KeyCode.Space)) {
			is_grounded = false;
			rigidbody.AddRelativeForce(Vector3.up * 350, ForceMode.Force);
			jump_timer = 5;
		}
		if (jump_timer > 0) {
			jump_timer--;
		}

		Vector3 camPosition = Camera.main.transform.position;				
		camPosition.x = Mathf.Max(0, transform.position.x);
		Camera.main.transform.position = camPosition;
	}

	void OnCollisionEnter(Collision collision) {
		is_grounded = true;
	}
}
