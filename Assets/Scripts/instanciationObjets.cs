using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciationObjets : MonoBehaviour {
    public GameObject[] arrayObjet;

    private void Update()
    {
        for (var indexObjet = 0; indexObjet < arrayObjet.Length; indexObjet++)
        {
            // on invoque un nouvel objet qui correspond avec l'index.
            var nouvelObjet = Instantiate(arrayObjet[indexObjet]);
            // on l'active.
            nouvelObjet.SetActive(true);
            // on lui donne une position
            nouvelObjet.transform.position = new Vector3(Random.Range(48f, -48f), 20, Random.Range(48f, -48f));
        }
    }
}
