using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// https://answers.unity.com/questions/980339/count-down-timer-c-1.html

public class Countdown : MonoBehaviour
{
    public static float totalTime = 120f; //2 minutes
    public Text timer;

    private void Update()
    {
        if (GestionCamera.pause == false)
        {
            totalTime -= Time.deltaTime;
            UpdateLevelTimer(totalTime);
        }
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        
            int minutes = Mathf.FloorToInt(totalSeconds / 60f);
            int seconds = Mathf.RoundToInt(totalSeconds % 60f);

            string formatedSeconds = seconds.ToString();

            if (seconds == 60)
            {
                seconds = 0;
                minutes += 1;
            }

            timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        
    }
}