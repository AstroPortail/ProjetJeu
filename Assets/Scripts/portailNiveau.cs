using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class portailNiveau : MonoBehaviour {

    public string sceneEnCours;
   // public GameObject ObjetDuNiveau;
    public bool estTrouve = false;

    public Image cadeau;
    public Image champi;
    public Image citrouille;

    private void Start()
    {
        sceneEnCours = SceneManager.GetActiveScene().name;
         
    }

    private void Update()
    {
        if (sceneEnCours == "Automne")
        {
            if (ControlerPersonnage.citrouilleRamasse == true)
            {
                estTrouve = true;
                
            }
        }
        else if (sceneEnCours == "HiverHelo")
        {
            if (ControlerPersonnage.cadeauRamasse == true)
            {
                estTrouve = true;
                
            }
        }
        else if (sceneEnCours == "EteLaurence")
        {
            if (ControlerPersonnage.champiRamasse == true)
            {
                estTrouve = true;
                
            }
        }
    }

    private void OnTriggerStay(Collider infoCollision)
    {

        if (infoCollision.gameObject.name == "PrefabAstro" && estTrouve == true)
        {
            int sceneAleatoire = Random.Range(0, 3);

            if (sceneAleatoire == 0 && sceneEnCours != "Automne")
            {

                SceneManager.LoadScene("Automne");
            }

            if (sceneAleatoire == 1 && sceneEnCours != "HiverHelo")
            {
                //SceneManager.LoadScene("EteLaurence");
                SceneManager.LoadScene("HiverHelo");
            }

            if (sceneAleatoire == 2 && sceneEnCours != "EteLaurence")
            {
                //SceneManager.LoadScene("HiverHelo");
                SceneManager.LoadScene("EteLaurence");

            }
        }
    }
}
