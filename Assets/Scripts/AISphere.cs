using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISphere : MonoBehaviour {
    public Vector3 cibleRandom;

    private void Start()
    {
        cibleRandom = new Vector3(Random.Range(2f, 93f), 25, Random.Range(2f, 93f));
    }
    // Update is called once per frame
    void Update () {

        GetComponent<NavMeshAgent>().SetDestination(cibleRandom);
        
        print(cibleRandom);

        if(GetComponent<NavMeshAgent>().velocity.magnitude <= 0.1f)
        {
            cibleRandom = new Vector3(Random.Range(2f, 93f), 25, Random.Range(2f, 93f));
        }
    }
}
