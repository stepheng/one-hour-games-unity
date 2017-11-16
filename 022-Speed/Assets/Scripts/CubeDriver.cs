using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CubeDriver : MonoBehaviour {

	public Text timerText;
	private float timeStarted;
	private Rigidbody rigidbody;
	// Use this for initialization

	public Graphic panel;

	void Start () {
		timeStarted = Time.time;
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("up")) {
			rigidbody.AddRelativeForce(Vector3.forward * 20);
		} else if (Input.GetKey("down")) {
			rigidbody.AddRelativeForce(Vector3.back * 20);
		}
		if (Input.GetKey("left")) {
			float turn = -50 * Time.deltaTime;
			Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
			rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
		} else if (Input.GetKey("right")) {
			float turn = 50 * Time.deltaTime;
			Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
			rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
		}
		timerText.text = "" + (Time.time - timeStarted);
		Color Transparent = new Color(1, 1, 1, 0);
		panel.color = Color.Lerp(panel.color, Transparent, 20 * Time.deltaTime);
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Target") {
			Destroy(collider.gameObject);
			GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
			Debug.Log("Targets Remaining: " + targets.Length);
			if (targets.Length == 1) {
				 SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				 
			}
			panel.color = new Color(1f, 1f, 1f, 1f);
		}
	}
}
