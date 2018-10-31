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
    public GameObject leCanva;
    public GameObject lePerso;

    public static bool ceciEstLaFinDuJeu = false;

    //public InputField champNomJoueur;

   void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(ceciEstLaFinDuJeu == true)
        {
            portailFin();
        }
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

        if (Input.GetKeyDown("j"))
        {
            ceciEstLaFinDuJeu = true;
            SceneManager.LoadScene("Image");
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

    public void portailFin()
    {
        leCanva.SetActive(false);
        lePerso = GameObject.Find("PrefabAstro");
        lePerso.transform.position = new Vector3(9.01967f, 24.0951f, 84.73033f);
        lePerso.GetComponent<ControlerPersonnage>().vitesseDeplacement = 5f;
    }


}// FIN CLASSE GESTIONSCENES

