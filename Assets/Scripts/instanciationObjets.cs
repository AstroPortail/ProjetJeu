using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciationObjets : MonoBehaviour {
    public GameObject[] arrayObjet;

    private void Start()
    {
        StartCoroutine(positionRandomObjets());
    }


    IEnumerator positionRandomObjets()
    {

        for (var indexObjet = 0; indexObjet < arrayObjet.Length; indexObjet++)
        {
            // on invoque un nouvel objet qui correspond avec l'index.
            var nouvelObjet = Instantiate(arrayObjet[indexObjet]);
            // on l'active.
            nouvelObjet.SetActive(true);
            // on cache son mesh
            nouvelObjet.GetComponent<MeshRenderer>().enabled = false;
            // on lui donne une position
            nouvelObjet.transform.position = new Vector3(Random.Range(2f, 93f), 20, Random.Range(2f, 93f));
            yield return new WaitForSeconds(4);
            nouvelObjet.GetComponent<MeshRenderer>().enabled = true;

        }
       
        
    }


}