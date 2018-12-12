using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// https://answers.unity.com/questions/980339/count-down-timer-c-1.html

public class Countdown : MonoBehaviour
{
    public static float totalTime = 5f; //2 minutes
    public Text timer;
    public static int niveauSphere;
    public GameObject[] lesNiveau;
    public GameObject LaSphere;
    public string sceneEnCours;
    public int minutes;
    public int seconds;


    private void Start()
    {
        niveauSphere = Random.Range(0, 3);
        lesNiveau[niveauSphere].SetActive(true);
        sceneEnCours = SceneManager.GetActiveScene().name;

    }


    private void Update()
    {
        if (GestionCamera.pause == false)
        {
            totalTime -= Time.deltaTime;
            UpdateLevelTimer(totalTime);
        }

        if (minutes == 0 && seconds == 0)
        {
            niveauSphere = Random.Range(0, 3);
            totalTime = 5f;

            for (var iCompteur = 0; iCompteur < lesNiveau.Length; iCompteur++)
            {
                lesNiveau[iCompteur].SetActive(false);
            }

            lesNiveau[niveauSphere].SetActive(true);
        }

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