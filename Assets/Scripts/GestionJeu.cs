using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionJeu : MonoBehaviour {

   // public GameObject textField;
    public static string nomJoueur;
    public GameObject btnInstru;
    public GameObject btnJouer;

    public InputField champNomJoueur;

    public void Enregistrer()
    {
        if (champNomJoueur.text != "")
        {
        PlayerPrefs.SetString("nomJoueur", champNomJoueur.text);
        btnInstru.SetActive(true);
        btnJouer.SetActive(true);
        }
    }

    //PlayerPrefs.SetString("nomJoueur", txtNom.text);
    //if(GetComponent<Text>().text!="")
    //change de scène

    //On Start bravo joueur + GestionJeu.nomJoueur dans une chaine;
}
