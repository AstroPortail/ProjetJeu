using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class citrouilleScript : MonoBehaviour {

    public MeshRenderer[] CitrouilleTableauMeshObjets;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(CitrouillePositionRandomObjets());
    }

    IEnumerator CitrouillePositionRandomObjets()
    {
        for (var iEnum = 0; iEnum < CitrouilleTableauMeshObjets.Length; iEnum++)
        {
            CitrouilleTableauMeshObjets[iEnum].enabled = false;
        }
        GameObject.Find("citrouilleAsset").transform.position = new Vector3(Random.Range(2f, 93f), 20, Random.Range(2f, 93f));
        yield return new WaitForSeconds(4);

        for (var iEnum2 = 0; iEnum2 < CitrouilleTableauMeshObjets.Length; iEnum2++)
        {
            print(iEnum2);
            CitrouilleTableauMeshObjets[iEnum2].enabled = true;
        }
    }
}
