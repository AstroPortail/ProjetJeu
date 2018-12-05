using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifSon : MonoBehaviour {
    public AudioSource laMusiqua;

    // Use this for initialization
    void Start () {
        print("leSon est a mute = " + MuteMusic.sonMute);

        if (MuteMusic.sonMute == true) {
            print(laMusiqua.mute);
            laMusiqua.mute=true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
