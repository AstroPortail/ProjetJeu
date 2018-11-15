using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangementScenePortail : MonoBehaviour {

    public string sceneEnCours; // permet de ne pas retourner dans une scène ou le perso est déjà.
    public static InputField champNomJoueur;
    

   void Start()
    {
        sceneEnCours = SceneManager.GetActiveScene().name; // sauvegarde le nom de la scène actuelle.
        print(sceneEnCours);
    }

    void Update()//à remplacer dans le OnCollisionStay pour que si la scène est mauvaise, il peut regénérer un chfifre.
    {



    }


    /*public void Rejouer()
{
    SceneManager.LoadScene("HiverHelo");
}*/

    public void Jouer()
    {
        if (champNomJoueur.text != "")
        {
            // Scène aléatoire au début du jeu
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
        // Scène aléatoire au début du jeu
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

        // Va falloir penser a si jamais le joueur arrive toujours aux mêmes saisons et en manque toujours
        //une, comment on va s'arranger
    





}// FIN CLASSE GESTIONSCENES

