using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangementScenePortail : MonoBehaviour {

    public string sceneEnCours; // permet de ne pas retourner dans une sc�ne ou le perso est d�j�.
    public  InputField champNomJoueur;
    public static string leNomDuJoueur;

   void Start()
    {
        sceneEnCours = SceneManager.GetActiveScene().name; // sauvegarde le nom de la sc�ne actuelle.
        print(sceneEnCours);
    }

    public void Jouer()
    {
        if (champNomJoueur.text !="")
        {
            leNomDuJoueur = champNomJoueur.text;
            // Sc�ne al�atoire au d�but du jeu
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


    public void Rejouer()
        {
        // Sc�ne al�atoire au d�but du jeu
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

    public void MenuDepart()
    {
        //Revenir a l'accueil
        SceneManager.LoadScene("EcranIntro");
    }
}// FIN CLASSE GESTIONSCENES

