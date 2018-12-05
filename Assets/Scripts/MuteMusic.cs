using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMusic : MonoBehaviour {
    AudioSource audioSource;
    public static bool sonMute;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        sonMute = false;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void MuteMusique()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        } else
        {
            audioSource.mute = !audioSource.mute;
            sonMute = true;
            
        }
    }


    public void MuteTousLesSons()

    {
       AudioListener.pause = !AudioListener.pause;
    }
}
