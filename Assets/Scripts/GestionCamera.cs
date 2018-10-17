// Cours : Dev Jeu
// Exercice : TP session 5
// Script qui gére toute les caméras 
// @author Laurence Dodier
// @version 2018-10-10

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCamera : MonoBehaviour {
    public GameObject camPremierePersonne; // camera de face au personnage
    public GameObject camTroisPersonne; // camera derriere le personnage
    public GameObject camTop; // camera au dessus du personnage
    public GameObject camDerriere; // camera au dessus du personnage
    public GameObject camSurvole; // camera au dessus du personnage


    //Joue en boucle (à chaque cycle)
    public void Update()
    {
        //Si appuie sur 1 alors active camera devant le personnage 1er personne
        if (Input.GetKeyDown("1"))
        {
            ActiverCamera(camPremierePersonne);
        }

        //Si appuie sur 2 alors active camera derriere le personnage 3e personne
        if (Input.GetKeyDown("2"))
        {
            ActiverCamera(camTroisPersonne);
        }

        //Si appuie sur 3 alors active camera fixe
        if (Input.GetKeyDown("3"))
        {
            camTop.SetActive(!camTop.activeSelf);
        }

        //Si appuie sur 4 alors active une camera sur le coin inférieur gauche pour que le joueur puisse voir derriere lui
        if (Input.GetKeyDown("4"))
        {
            camDerriere.SetActive(true);
        }
        //Si le joueur enleve son doigts de 4 alors la camera disparait
        if (Input.GetKeyUp("4"))
        {
            camDerriere.SetActive(false);
        }

        //Si appuie sur 5 alors le jeu se mets sur pause et une camera de dessus que le joueur peut se deplacer pour voir la map
        if (Input.GetKeyDown("5"))
        {
           

        }

    }

    // Désactive la caméra actuelle et en active la caméra choisie
    public void ActiverCamera(GameObject cameraChoisie)
    {
        Camera.main.gameObject.SetActive(false);
        cameraChoisie.SetActive(true);
    }
}
