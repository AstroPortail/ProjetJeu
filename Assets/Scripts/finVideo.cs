using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class finVideo : MonoBehaviour {

    public GameObject tabScore;
    public GameObject panGagne;
    public GameObject panPerdu;

    private void Start()
    {
        if(ControlerPersonnage.estMort == true)
        {
            tabScore.SetActive(true);
            panPerdu.SetActive(true);
        }
        else
        {
            GetComponent<VideoPlayer>().Play();
        }
    }

    void Update () {

        GetComponent<VideoPlayer>().loopPointReached += EndReached;

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        GetComponent<VideoPlayer>().enabled = false;
        tabScore.SetActive(true);
        panGagne.SetActive(true);

    }


}
