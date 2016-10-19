using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public Transform goal;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}
