using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
* 1. Donner l'astronaute comme cible pour le navMesh des ennemis
* 2. Gestion de la mort des ennemis lorsqu'ils recoivent des coups
*/

public class AI : MonoBehaviour {
    public GameObject cible;
    public bool estMort = false;
    public float coupsRecus = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        // on donne une cible et on vérifie si le perso avance a chaque frame SI l'ennemi n'est pas mort
        if(estMort == false)
        {
            GetComponent<NavMeshAgent>().SetDestination(cible.transform.position);
            GetComponent<Animator>().SetFloat("vitesse", GetComponent<NavMeshAgent>().velocity.magnitude);
        }

        //on ajuste l'animation d'attaque si le perso est a moins de 3 et que l'ennemi n'est pas mort
        float dist = Vector3.Distance(cible.transform.position, transform.position);
        if (dist <= 3 && estMort == false)
        {
            GetComponent<Animator>().SetTrigger("estProche");
        }
       
    }

    void OnCollisionEnter(Collision infoCollision)
    {
        print(infoCollision.gameObject.name);

        if (infoCollision.gameObject.name == "Projectile Seed Purple(Clone)")
        {
            print("projectile touche arbre");
            Touche();
        }
    }

        // si les ennemis sont touché par une balle
    public void Touche()
    {
        coupsRecus += 1;
        print("coupsRecus = " + coupsRecus);

      
        if (gameObject.transform.name == "ennemiArbre(Clone)")
        {
            if(coupsRecus >= 3)
            {
                estMort = true;
            }
        }

        else if (gameObject.transform.name == "ennemiAraignee(Clone)")
        {
            if (coupsRecus >= 2)
            {
                estMort = true;
            }
        }

        
        else if (gameObject.transform.name == "ennemiAbeille(Clone)")
        {
            if (coupsRecus >= 1)
            {
                estMort = true;
            }
        }

        if(estMort == true)
        {

            // on joue le son de leur mort
            GetComponent<AudioSource>().Play();

            // on arette de le déplacer
            GetComponent<NavMeshAgent>().enabled = false;

            // on joue leur animation de mort
            GetComponent<Animator>().SetTrigger("Die");

            // et on le detruit après 2 secondes
            Invoke("Mort", 2f);
        }
    }

    // detruire l'ennemi
    public void Mort()
    {
        Destroy(gameObject);
    }

}
