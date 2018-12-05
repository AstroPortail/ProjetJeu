using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {
    public GameObject cible;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<NavMeshAgent>().SetDestination(cible.transform.position);
        GetComponent<Animator>().SetFloat("vitesse", GetComponent<NavMeshAgent>().velocity.magnitude);

        float dist = Vector3.Distance(cible.transform.position, transform.position);
        print("La Distance = " + dist);
        if (dist <= 3)
        {
            GetComponent<Animator>().SetTrigger("estProche");
        }
       
    }
}
