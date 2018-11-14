using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class portailNiveau : MonoBehaviour {

    public string sceneEnCours;

    private void OnTriggerStay(Collider infoCollision)
    {
        sceneEnCours = SceneManager.GetActiveScene().name;

        if (infoCollision.gameObject.name == "PrefabAstro")
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
