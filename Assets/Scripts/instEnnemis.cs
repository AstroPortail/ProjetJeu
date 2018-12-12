using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instEnnemis : MonoBehaviour
{
    // array contenant les ennemis à invoquer. (1x elephants, 3x lapins, 3x ours).
    public GameObject referenceEnnemis;
    public float positionOrigineX;
    public float positionOrigineY;
    public float positionOrigineZ;
    float nombreEnnemis = 0;

    // Use this for initialization
    void Start()
    {
        // on invoque un nouvel ennemi toutes les 2 secondes.
        InvokeRepeating("InvoqueEnnemis", 0f, 10f);
        
    }


    public void InvoqueEnnemis()
    {

        // on arette d'invoquer si on est a plus que 5 
        if (nombreEnnemis >= 3f)
        {
            print("plus que 3");
            CancelInvoke();
        }
            // on invoque un nouvel ennemi qui correspond avec l'index.
            var nouvelEnnemis = Instantiate(referenceEnnemis);

            // on l'active.
            nouvelEnnemis.SetActive(true);
            nouvelEnnemis.transform.position = new Vector3(positionOrigineX, positionOrigineY, positionOrigineZ);
            nombreEnnemis++;
            print("le nombre d'ennemis : " + nombreEnnemis);
    }
}
