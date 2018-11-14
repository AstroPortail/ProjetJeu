﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectiles : MonoBehaviour {

    public bool peutTirer;
    //public GameObject particuleContact;
    public GameObject particuleTir;
    public GameObject gun;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //rayon à partir de la caméra vers l’avant à la position de la souris
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // variable locale : contiendra les infos retournées par le Raycast sur l’objet touché
        RaycastHit infoCollision;

        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 5000, LayerMask.GetMask("Terrain")))
        {
            Vector3 pointAregarder = infoCollision.point; // On copie le vecteur3 de contact pour pouvoir changer le y
           // pointAregarder.y = 0; // élimine la hauteur lorsque le jeu se passe sur un plancher
            transform.LookAt(infoCollision.point); // L'objet regarde vers le point de contact
            //transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        }

        //si le bouton gauche est appuyé et qu'on peut tirer, alors on tire continuellement
        if (Input.GetKey(KeyCode.Mouse0) && peutTirer == true)
        {
            Invoke("TirerBalle", 0.1f);
            peutTirer = false;

           // if (Physics.Raycast(gun.transform.position, transform.forward, out infoCollision, 30))
           // {
             //   if (infoCollision.collider.tag == "ennemi")
               // {
                  //  infoCollision.collider.gameObject.GetComponent<AI>().Touche(); //(FONCTION qui tue le personnage et active le son du personnage ennemi)

            //    }

                // GameObject cloneParticule = Instantiate(particuleContact, transform.position, transform.rotation);
              //  DestroyImmediate(particuleContact);
           // }
        }
    }

    //function qui permet d'activer des particules 
    void TirerBalle()
    {
        particuleTir.SetActive(true);
        Invoke("DesactiveBalle", 0.2f);
    }

    //function qui  désactive la balle
    void DesactiveBalle()
    {
        peutTirer = true;
        particuleTir.SetActive(false);
    }
}