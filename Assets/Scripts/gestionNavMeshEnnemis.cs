using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class gestionNavMeshEnnemis : MonoBehaviour {
    //Animator ennemisAnim;
    public static GameObject Cible;
    // Use this for initialization
    void Start () {
        //ennemisAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Cible = GameObject.Find("PrefabAstro");
        GetComponent<NavMeshAgent>().SetDestination(Cible.transform.position);
        // Ligne à de code à décommenter lorsque le lapin se déplacera correctement. Elle permet d'activer l'animation de course.
        //ennemisAnim.SetFloat("vitesse", GetComponent<NavMeshAgent>().velocity.magnitude);
    }
}
