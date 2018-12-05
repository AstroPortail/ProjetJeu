using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifSon : MonoBehaviour {
    public AudioSource laMusiqua;

    // Use this for initialization
    void Start () {
        print("leSon est a mute = " + MuteMusic.sonMute);

        if (MuteMusic.sonMute == true) {
            print("QUEQUOUUU");
            laMusiqua.Pause();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
