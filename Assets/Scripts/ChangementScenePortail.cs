using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangementScenePortail : MonoBehaviour {

    public string sceneEnCours; // permet de ne pas retourner dans une sc�ne ou le perso est d�j�.
    

    //public InputField champNomJoueur;

   void Start()
    {
        sceneEnCours = SceneManager.GetActiveScene().name; // sauvegarde le nom de la sc�ne actuelle.
        print(sceneEnCours);
    }

    void Update()//� remplacer dans le OnCollisionStay pour que si la sc�ne est mauvaise, il peut reg�n�rer un chfifre.
    {


        // Sc�ne al�atoire au d�but du jeu
        /*int sceneAleatoire = Random.Range(0,2);

         if (sceneAleatoire == 0 && sceneEnCours!="Automne")
         {

             SceneManager.LoadScene("Automne");
         }


         if (sceneAleatoire == 1 && sceneEnCours != "EteLaurence")
         {
             SceneManager.LoadScene("EteLaurence");
         }

         if (sceneAleatoire == 2 && sceneEnCours != "HiverHelo")
         {
             SceneManager.LoadScene("HiverHelo");

         }*/

       

    }


        /*public void Rejouer()
    {
        SceneManager.LoadScene("HiverHelo");
    }*/

    public void Jouer()
    {
        // Sc�ne al�atoire au d�but du jeu
        int sceneAleatoire = Random.Range(0,3);

         if (sceneAleatoire == 0 && sceneEnCours!="Automne")
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

         // Va falloir penser a si jamais le joueur arrive toujours aux m�mes saisons et en manque toujours
         //une, comment on va s'arranger
    }





}// FIN CLASSE GESTIONSCENES

