// @version 2018-10-10

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTop : MonoBehaviour {

    public GameObject cible; // suit le personnage 
    public float distanceY;// garde la camera a distance Y du personnage

    //Joue en boucle (à chaque cycle)
    void Update()
    {
        //Distance fixe de la camera sans tourner selon le personnage
        transform.position = cible.transform.position + new Vector3(0, distanceY, 0);
    }
}
