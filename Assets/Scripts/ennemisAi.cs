using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ennemisAi : MonoBehaviour {
    public static GameObject Cible;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Cible = GameObject.Find("PrefabAstro");
        print(Cible.transform.position);
        GetComponent<NavMeshAgent>().SetDestination(Cible.transform.position);
        GetComponent<Animator>().SetFloat("vitesse", GetComponent<NavMeshAgent>().velocity.magnitude);
    }
}
