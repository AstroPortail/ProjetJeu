using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleMusique : MonoBehaviour {
    public GameObject Musique; //Objet musique
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(Musique);
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
