using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionSceneDebut: MonoBehaviour {
    public GameObject PanneauInstru;
    public GameObject btnEnregistrer;
    public GameObject btnJouer;
    public GameObject btnInstru;

    public InputField champNomJoueur;

    public void Rejouer()
    {
        SceneManager.LoadScene("SceneJeu");
    }

    public void Jouer()
    {   
        SceneManager.LoadScene("SceneJeu");
    }

    public void Instructions()
    {
        if(champNomJoueur.text!="")
        {
          PanneauInstru.SetActive(true);
          btnEnregistrer.SetActive(false);
          btnInstru.SetActive(false);
          btnJouer.SetActive(true);
        }

    }


}// FIN CLASSE GESTIONSCENES

