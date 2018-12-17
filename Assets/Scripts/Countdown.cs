using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// https://answers.unity.com/questions/980339/count-down-timer-c-1.html

public class Countdown : MonoBehaviour
{
    public static float totalTime = 90f; //2 minutes
    public Text timer;
    public static int niveauSphere;
    public GameObject[] lesNiveau;
    public GameObject LaSphere;
    public string sceneEnCours;
    public int minutes;
    public int seconds;


    private void Start()
    {
        // on choisit un niveau random pour positionner la sphere au début du jeu et on active l'image correspondant
        niveauSphere = Random.Range(0, 3);
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
            totalTime = 90f;

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