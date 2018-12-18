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
        if (dist <= 3)
        {
            GetComponent<Animator>().SetTrigger("estProche");
        }
       
    }

    // si les ennemis sont touché par une balle
    public void Touche()
    {
        // pointage de 20 pour un elephant
        if (gameObject.transform.name == "ennemiArbre")
        {
            print("ARBRE");
        }

        // pointage de 10 pour un lapin
        else if (gameObject.transform.name == "ennemiAraignee")
        {
            print("ARAIGNEE");
        }

        // pointage de 5 pour un ours
        else if (gameObject.transform.name == "ennemiAbeille")
        {
            print("ABEILLE");
        }

        // on joue le son de leur mort
        GetComponent<AudioSource>().Play();
        // on joue leur animation de mort
        GetComponent<Animator>().SetTrigger("Mort");
        // on arette de le déplacer
        GetComponent<NavMeshAgent>().enabled = false;
        // et on le detruit après 2 secondes
        Invoke("Mort", 2f);
    }

    // detruire l'ennemi
    public void Mort()
    {
        Destroy(gameObject);
    }

}
