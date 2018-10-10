// @version 2018-10-10

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPremierePersonne : MonoBehaviour {


    public float ValeurTransition;
    public GameObject cible; // suit le personnage 
    public float distanceX; // garde la camera a distance X du personnage
    public float distanceY; // garde la camera a distance Y du personnage
    public float distanceZ; // garde la camera a distance Z du personnage

    //Joue en boucle (à chaque cycle)
    void FixedUpdate()
    {

        // Définie  position en hauteur et en avant de la cible
        Vector3 poisitionFinale = cible.transform.TransformPoint(distanceX, distanceY, distanceZ);

        // position entre la position de départ de caméra et la position finale
        transform.position = Vector3.Lerp(transform.position, poisitionFinale, ValeurTransition);

        //regarde la cible
        transform.LookAt(cible.transform);
    }
}
