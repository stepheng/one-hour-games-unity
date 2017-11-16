using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public Text healthText;	
	CharacterController characterController;
	float health = 100;

	bool inLight = true;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		float speed = 0;
		if (Input.GetKey(KeyCode.W)) {
			speed = 10;
		} else if (Input.GetKey(KeyCode.S)) {
			speed = -10;
		}
		float hspeed = 0;
		if (Input.GetKey(KeyCode.A)) {
			hspeed = -10;
		} else if (Input.GetKey(KeyCode.D)) {
			hspeed = 10;
		}				
		transform.Rotate(0, Input.GetAxis("Horizontal") * 5, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
		//Vector3 strafe = transform.TransformDirection(Vector3.left) * hspeed;
		//Vector3 merged = forward + strafe;
        float curSpeed = speed;
        characterController.SimpleMove(forward * curSpeed);	
		if (inLight == false) {
			health -= Time.deltaTime;
			Debug.Log("Health: " + health);
		}
		healthText.text = "" + (int)health;
	}

	void OnTriggerEnter(Collider other) {
		Light light = other.gameObject.GetComponent<Light>();
		if (light == null) { return; }
		inLight = light.intensity > 0;
	}

	void OnTriggerStay(Collider other) {
		Light light = other.gameObject.GetComponent<Light>();
		if (light == null) { return; }
		inLight = light.intensity > 0;
	}

	void OnTriggerExit(Collider other) {
		if (inLight && other.gameObject.tag == "Light") {
			inLight = false;			
		}
	}
}
