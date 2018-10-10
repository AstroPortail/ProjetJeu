using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlerPersonnage : MonoBehaviour
{


    // GESTION PERSONNAGE--------------------------------------------------------
    public Rigidbody rbPerso; // va chercher le rigid du perso
    public Animator animPerso; // va chercher l'anim du perso

    public float vitesseRotation; //la vitesse de rotation du perso
    public float vitesseDeplacement = 10f; // la vitesse de déplacement du perso

    public float vDeplacement; // la vitesse de déplacement du personnage
    public float vitesseSaut = 6; // hauteur de saut

    public bool auSol; //pour qu'on regarde si le perso est au sol ou non

    // CAMERAS---------------------------------------------------------------------
    public GameObject camDos; // pour la caméra de dos au personnage
    public GameObject cam1erePersonne; // pour la caméra qui regarde ce que le perso voit



    private CharacterController controlleur; //controler le personnage
    private Vector3 changerDirection = Vector3.zero; //
    public float graviter = 20.0f; // permet au personnage d'avancer

    void Start()
    {
        controlleur = GetComponent<CharacterController>();

        rbPerso = GetComponent<Rigidbody>();
        animPerso = GetComponent<Animator>();
       
    }

    // on va faire une fonction qui va activer la camera
    void ActiverCamera(GameObject choixCamera)
    {
        Camera.main.gameObject.SetActive(false); //on désactive la caméra avant d'activer la suivante

        choixCamera.SetActive(true); //On active la caméra qui a été sélectionnée avec le #
    }

    void Update()

    {

        if (controlleur.isGrounded)
        {
            changerDirection = transform.forward * Input.GetAxis("Vertical") * vitesseDeplacement; //changer de direction du personnage
        }
        controlleur.Move(changerDirection * Time.deltaTime); 
        changerDirection.y -= graviter * Time.deltaTime; // permet detre a une hauteur et d'avancer

        //-------------CAMERA GESTION---------------------

        //gérer l'activation des caméras selon 1 ou 2

        /* if (Input.GetKeyDown(KeyCode.Alpha1)) // Si le joueur appuie sur 1
         {
             ActiverCamera(camDos); //active caméra de dos
         }
         else if (Input.GetKeyDown(KeyCode.Alpha2)) // Si le joueur appuie sur 2
         {
             ActiverCamera(cam1erePersonne); // active caméra première personne
         } */

        //-------------GESTION DU PERSONNAGE---------------------
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0); // la rotation sur l'axe horizontal

        vDeplacement = Input.GetAxis("Vertical") * vitesseDeplacement; // vitesse de déplacement sur l'axe verticale

        //remplace : rbPerso.AddRelativeForce(0,0, vDeplacement)
        // OU si le perso doit subir la gravité et pouvoir 

        rbPerso.velocity = (transform.forward * vDeplacement) + new Vector3(0, rbPerso.velocity.y, 0); // on fait avancer notre perso

        // si le perso est au sol, il peut sauter
        if (Input.GetKeyDown(KeyCode.Space) && auSol == true)
        {
            rbPerso.velocity += new Vector3(0, vitesseSaut, 0); // déclare la variable du saut pour l'attribuer dans l'Inspecteur

        }
        // on apelle l'animation 
        AnimerPerso();
     
    }// FIN DU UPDATE

    //-------------GESTION ANIMATION PERSONNAGE---------------------
    void AnimerPerso()
    {
        animPerso.SetFloat("vitesseDep", rbPerso.velocity.magnitude);
        RaycastHit infoCollision;
        auSol = Physics.SphereCast(transform.position + new Vector3(0, 0.5f, 0), 0.2f, -Vector3.up,
        out infoCollision, 0.8f); // on regarde si le personnage touche le sol
        //Si le personnage n'est pas au Sol alors l'animation saut doit jouer sinon elle arrête
        animPerso.SetBool("animSaut", !auSol);
    }


}// fin de la classe
