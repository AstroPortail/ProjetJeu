using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetsDynamique : MonoBehaviour {
    public GameObject[] arrayObjet;

    // Use this for initialization
    void Start () {
        InvokeRepeating("InvoqueObjet", 0f, 3f);
    }

    public void InvoqueObjet()
    {
        // on choisit au hasard un index d'ennemi dans le tableau des ennemis.
        int indexObjet = Random.Range(0, arrayObjet.Length - 1);
        print(indexObjet);

        // on invoque un nouvel ennemi qui correspond avec l'index.
        var nouvelObjet = Instantiate(arrayObjet[indexObjet]);

        // on l'active.
        nouvelObjet.SetActive(true);
        nouvelObjet.transform.position = new Vector3(Random.Range(-8.5f,8.5f),12,Random.Range(-14.5f, 14.5f));
    }
}
