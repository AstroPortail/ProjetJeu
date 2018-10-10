using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionEtoile : MonoBehaviour {

    //PRÉFABS DES ÉTOILES A ASSIGNER DANS L'INSPECTEUR----------------------------------
    public GameObject etoileBleuePrefab;
    public GameObject etoileJaunePrefab;
    public GameObject etoileRougePrefab;
    public GameObject etoileVertePrefab;

    void Start()
        //AU DÉBUT DE LA PARTIE, ON CHOISIT LE NOMBRE D'ÉTOILES A INSTANCIER DANS LE JEU.
    {
        //--ÉTOILES BLEUES
        Apparition(etoileBleuePrefab);
        Apparition(etoileBleuePrefab);
        Apparition(etoileBleuePrefab);

        //--ÉTOILES VERTES 10
        Apparition(etoileVertePrefab);
        Apparition(etoileVertePrefab);
        Apparition(etoileVertePrefab);
        Apparition(etoileVertePrefab);
        Apparition(etoileVertePrefab);
        Apparition(etoileVertePrefab);
        Apparition(etoileVertePrefab);
        Apparition(etoileVertePrefab);
        Apparition(etoileVertePrefab);
        Apparition(etoileVertePrefab);

        //--ÉTOILES JAUNES 7
        Apparition(etoileJaunePrefab);
        Apparition(etoileJaunePrefab);
        Apparition(etoileJaunePrefab);
        Apparition(etoileJaunePrefab);
        Apparition(etoileJaunePrefab);
        Apparition(etoileJaunePrefab);
        Apparition(etoileJaunePrefab);

        //--ÉTOILES ROUGE 7
        Apparition(etoileRougePrefab);
        Apparition(etoileRougePrefab);
        Apparition(etoileRougePrefab);
        Apparition(etoileRougePrefab);
        Apparition(etoileRougePrefab);
        Apparition(etoileRougePrefab);
        Apparition(etoileRougePrefab);

    }

    // -- FONCTION POUR FAIRE APPARAITRE LES ÉTOILES DANS DES POSITIONS ALÉATOIRES
    // -- SUR DES POSITIONS DE TERRAIN EXISTANTES
    void Apparition(GameObject etoile)
    {
       //--LES 3 POSITIONS POSSIBLES 
        Vector3 position1 = new Vector3(Random.Range(-143,1.6f), 16.5f, Random.Range(-427,-257));
        Vector3 position2 = new Vector3(Random.Range(84,240), 16.5f, Random.Range(-267,-142));
        Vector3 position3 = new Vector3(Random.Range(185,335), 16.5f, Random.Range(-603, -461));

        //--UN ÉTOILE AU HASARD QUI VA INSTANCIER SELON LA POSITION, ROTATION
        GameObject etoileChoisie = Instantiate(etoile,etoile.transform.position,etoile.transform.rotation); 
        
        int aleatoire = Random.Range(1, 3); // on va mettre le switch aléatoire pour attribuer les positions aux étoiles

        switch(aleatoire)
        {
            case 1:
                etoileChoisie.transform.position = position1; // on choisit la position 1 
                etoileChoisie.SetActive(true);
                
                break;

            case 2:
                etoileChoisie.transform.position = position3; // on choisit la position 3
                etoileChoisie.SetActive(true);

                break;

            case 3:
                etoileChoisie.transform.position = position2; // on choisit la position 2
                etoileChoisie.SetActive(true);
                break;


        }
    }

}


