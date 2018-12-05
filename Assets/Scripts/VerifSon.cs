using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifSon : MonoBehaviour {
    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
        print("leSon est a mute = " + MuteMusic.sonMute);
		if (MuteMusic.sonMute ==true) {

            audioSource.Pause();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
