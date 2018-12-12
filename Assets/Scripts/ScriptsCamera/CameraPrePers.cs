/* Script de camera qui affiche la camera a la premiere personne
 * 
 * @author Laurence Dodier
 * @version 2018-11-14
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPrePers : MonoBehaviour {

    public GameObject cible; // le personnage

    public float hauteurPivot; // hauteur de l'étiquette
    public float positionXPivot; // position x de l'étiquette
    public float positionZPivot; // position x de l'étiquette
    

    // Position le pivot de la caméra au même endroit que le personnage + une certaine hauteur (prêt de la tête)
    // le pivot tourne par le déplacement de la souris en X et Y
    void Update()
    {
        transform.position = cible.transform.position + new Vector3(positionXPivot, hauteurPivot, positionZPivot);
        transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        //Annuler la rotation en Z
        transform.eulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        //Caméra regarde le pivot
       // camera.transform.LookAt(transform);
        //rayCastcameraPivot.transform.LookAt(transform);
    }
}
