using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionSceneFin : MonoBehaviour {

   
    public void Rejouer()
    {

        // oxygene, vie, temps a zéro
      /*  ControlerPersonnage.NiveauOxygene = 100f;
        ControlerPersonnage.NiveauVie = 100f;
        ControlerPersonnage.estMort = false;
        Countdown.totalTime = 120f;*/

                // Scène aléatoire au début du jeu
                int sceneAleatoire = Random.Range(0, 3);

                if (sceneAleatoire == 0)
                {

                    SceneManager.LoadScene("Automne");
                }

                if (sceneAleatoire == 1 )
                {
                    //SceneManager.LoadScene("EteLaurence");
                    SceneManager.LoadScene("HiverHelo");
                }

                if (sceneAleatoire == 2)
                {
                    //SceneManager.LoadScene("HiverHelo");
                    SceneManager.LoadScene("EteLaurence");

                }

            
    }
}
