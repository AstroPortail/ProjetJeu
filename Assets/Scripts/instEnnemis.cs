using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instEnnemis : MonoBehaviour
{
    // array contenant les ennemis à invoquer. (1x elephants, 3x lapins, 3x ours).
    public GameObject[] arrayEnnemis;
    float nombreEnnemis = 0;

    // Use this for initialization
    void Start()
    {
        // on invoque un nouvel ennemi toutes les 2 secondes.
        if(nombreEnnemis < 18)
        {
            InvokeRepeating("InvoqueEnnemis", 0f, 5f);
        }
        
    }


    public void InvoqueEnnemis()
    {
        // on choisit au hasard un index d'ennemi dans le tableau des ennemis.
        int indexEnnemis = Random.Range(0, arrayEnnemis.Length - 1);

        // on invoque un nouvel ennemi qui correspond avec l'index.
        var nouvelEnnemis = Instantiate(arrayEnnemis[indexEnnemis]);

        // on l'active.
        nouvelEnnemis.SetActive(true);
        nombreEnnemis++;
    }
}
