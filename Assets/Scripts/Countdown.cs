using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// source :  https://answers.unity.com/questions/980339/count-down-timer-c-1.html
/*
* 1. Définir aléatoirement le niveau dans laquel se trouve la sphère. ( Le premier sera toujours l'hiver ) 
* 2. Afficher l'icone correspondant
* 3. Faire aparraitre la sphère dans le niveau définit ( set active true )
* 4. Calculer et afficher le temps restant avant que la sphère change de niveau 
*/

public class Countdown : MonoBehaviour
{
    public static float totalTime = 60f; //1 minute
    public Text timer;
    public static int niveauSphere = 1;
    public GameObject[] lesNiveau;
    public GameObject LaSphere;
    public string sceneEnCours;
    public int minutes;
    public int seconds;


    private void Start()
    {
        lesNiveau[niveauSphere].SetActive(true);

        // on garde en mémoire le nom de la scene active
        sceneEnCours = SceneManager.GetActiveScene().name;

    }


    private void Update()
    {
        // on arette le temps si le jeu est en pause
        if (GestionCamera.pause == false)
        {
            totalTime -= Time.deltaTime;
            UpdateLevelTimer(totalTime);
        }

        // si le temps est écoulé
        if (minutes == 0 && seconds == 0)
        {
            // on change la sphere de niveau et on redémarre le chrono
            niveauSphere = Random.Range(0, 3);
            totalTime = 60f;

            // on désactive les images
            for (var iCompteur = 0; iCompteur < lesNiveau.Length; iCompteur++)
            {
                lesNiveau[iCompteur].SetActive(false);
            }

            // on réactive la bonne image
            lesNiveau[niveauSphere].SetActive(true);
            // on déscative la sphere
            LaSphere.SetActive(false);
        }

        // si la scene en cours est la scene comprenant la sphere, on l'active
        if (sceneEnCours == "Automne" && niveauSphere == 0)
        {
            LaSphere.SetActive(true);
        }
        else if (sceneEnCours == "HiverHelo" && niveauSphere == 1)
        {
            LaSphere.SetActive(true);
        }
        else if (sceneEnCours == "EteLaurence" && niveauSphere == 2)
        {
            LaSphere.SetActive(true);
        }
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        
             minutes = Mathf.FloorToInt(totalSeconds / 60f);
             seconds = Mathf.RoundToInt(totalSeconds % 60f);

            string formatedSeconds = seconds.ToString();

            if (seconds == 60)
            {
                seconds = 0;
                minutes += 1;
            }

            timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        
    }
}