using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum NavigatorState {
	WALKING,
	NAVIGATING
}

public class NavigateScript : MonoBehaviour {

	public Transform goal;
	
	private  NavMeshAgent agent;

	private NavigatorState navigatorState = NavigatorState.WALKING;

	private float timeToStateChange = float.MaxValue;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		timeToStateChange = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		switch(navigatorState) {
			case NavigatorState.NAVIGATING:
				if (timeToStateChange <= Time.realtimeSinceStartup) {
					navigatorState = NavigatorState.WALKING;
					timeToStateChange = Time.realtimeSinceStartup;
					return;
				}
				break;
			case NavigatorState.WALKING:
				if (timeToStateChange <= Time.realtimeSinceStartup) {
					Debug.Log("Picking new destination");
					agent.destination = new Vector3(Random.Range(-15f, 15f), 0f, Random.Range(-15f, 15f));
					timeToStateChange = float.MaxValue;
					return;
				}
				float distance = Vector3.Distance(agent.destination, transform.position);
				Debug.Log("Distance: " + distance);
				if (agent.isStopped || distance < 1.5f) {
					timeToStateChange = Time.realtimeSinceStartup;					
				}
				break;
		}
	}

	void FixedUpdate() {
	}

	void OnTriggerEnter(Collider collider) {
		timeToStateChange = Time.realtimeSinceStartup + 5f;
	}

	public void SetGoal(Transform goal) {
		this.goal = goal;
		agent.destination = goal.position;	
		navigatorState = NavigatorState.NAVIGATING;
	}
}
