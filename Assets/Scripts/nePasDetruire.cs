using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class nePasDetruire : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
    }
	
}
