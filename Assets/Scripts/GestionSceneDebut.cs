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

   void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

        // Fonction temporaire pour visualiser les divers environnements en appuyant sur une touche
        if (Input.GetKeyDown("f"))
        {
         
            SceneManager.LoadScene("Automne");
        }

        if (Input.GetKeyDown("e"))
        {
            SceneManager.LoadScene("EteLaurence");
        }

        if (Input.GetKeyDown("h"))
        {
            SceneManager.LoadScene("HiverHelo");
        }
        
    }


        public void Rejouer()
    {
        SceneManager.LoadScene("HiverHelo");
    }

    public void Jouer()
    {   
        SceneManager.LoadScene("HiverHelo");
    }

    public void Instructions()
    {
        
          PanneauInstru.SetActive(true);
          btnReglages.SetActive(false);
          btnInstru.SetActive(false);
          btnJouer.SetActive(true);

    }

    


}// FIN CLASSE GESTIONSCENES

