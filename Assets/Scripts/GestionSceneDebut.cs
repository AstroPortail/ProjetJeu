using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionSceneDebut: MonoBehaviour {
    public GameObject PanneauInstru;
    public GameObject btnReglages;
    public GameObject btnJouer;
    public GameObject btnInstru;

    //public InputField champNomJoueur;

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
        
          PanneauInstru.SetActive(true);
            btnReglages.SetActive(false);
          btnInstru.SetActive(false);
          btnJouer.SetActive(true);


    }


}// FIN CLASSE GESTIONSCENES

