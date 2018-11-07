using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToucheEnnemi : MonoBehaviour {

    public GameObject paneau; // paneau rouge 
    public Animator animPaneau;
    

    void Desactif () {

       // animPaneau = paneau.GetComponent<Animator>(); //on assigne à la variable le composant Rigidbody d'un objet 3D
        gameObject.SetActive(false);
    }
	

	void Update () {
        //animPaneau.SetBool("EnnemieTouche", true);

    }


}
