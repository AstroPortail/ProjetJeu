using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cadeau : MonoBehaviour {
    public MeshRenderer[] tableauMeshObjets;

    // Use this for initialization
    void Start () {
        StartCoroutine(positionRandomObjets());
    }

    IEnumerator positionRandomObjets()
    {
        for (var iEnum = 0; iEnum < tableauMeshObjets.Length; iEnum++)
        {
            print(iEnum);
            tableauMeshObjets[iEnum].enabled = false;
        }
        //GameObject.Find("citrouilleAsset").transform.position = new Vector3(Random.Range(48f, -48f), 20, Random.Range(48f, -48f));
        GameObject.Find("cadeauAsset").transform.position = new Vector3(Random.Range(48f, -48f), 20, Random.Range(48f, -48f));
       // GameObject.Find("champisAsset").transform.position = new Vector3(Random.Range(48f, -48f), 20, Random.Range(48f, -48f));
        yield return new WaitForSeconds(4);

        for (var iEnum2 = 0; iEnum2 < tableauMeshObjets.Length; iEnum2++)
        {
            print(iEnum2);
            tableauMeshObjets[iEnum2].enabled = true;
        }
    }
}
