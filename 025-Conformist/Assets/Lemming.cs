using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lemming : MonoBehaviour {
	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();		
		agent.SetDestination(new Vector3(12.83f, -7, 0));
	}
	
	// Update is called once per frame
	void Update () {		
	}
}
