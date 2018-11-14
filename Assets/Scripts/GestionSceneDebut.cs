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
        lePerso.transform.rotation = Quaternion.identity;
    }

    


}// FIN CLASSE GESTIONSCENES

