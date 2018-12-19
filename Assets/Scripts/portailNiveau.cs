using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class portailNiveau : MonoBehaviour {

    public string sceneEnCours;
   // public GameObject ObjetDuNiveau;
    public bool estTrouve = false;
    public GameObject panneauAvertissement;
    public Text avertissement;

    public Image cadeau;
    public Image champi;
    public Image citrouille;

    private void Start()
    {
        sceneEnCours = SceneManager.GetActiveScene().name;
         
    }

    IEnumerator ActivePanneauAvertissement2()
    {
        panneauAvertissement.SetActive(true);
        avertissement.text = "Vous devez amasser l'objet spécial de ce niveau avant d'acceder au portail !";
        yield return new WaitForSeconds(5);
        panneauAvertissement.SetActive(false);
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

        if (infoCollision.gameObject.name == "PrefabAstro")
        {

            if(estTrouve == true)
            {
                GameObject son = GameObject.Find("sonPortail");
                son.GetComponent<AudioSource>().Play();
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
            } else
            {
                StartCoroutine(ActivePanneauAvertissement2());
            }
           
        }
    }
}
