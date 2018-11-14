﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cadeauScript : MonoBehaviour {
    public MeshRenderer[] cadeauTableauMeshObjets;

    // Use this for initialization
    void Start () {
        StartCoroutine(cadeauPositionRandomObjets());
    }

    IEnumerator cadeauPositionRandomObjets()
    {
        for (var iEnum = 0; iEnum < cadeauTableauMeshObjets.Length; iEnum++)
        {
            cadeauTableauMeshObjets[iEnum].enabled = false;
        }
        GameObject.Find("cadeauAsset").transform.position = new Vector3(Random.Range(2f, 93f), 20, Random.Range(2f, 93f));
        yield return new WaitForSeconds(4);

        for (var iEnum2 = 0; iEnum2 < cadeauTableauMeshObjets.Length; iEnum2++)
        {
            cadeauTableauMeshObjets[iEnum2].enabled = true;
        }
    }
}
