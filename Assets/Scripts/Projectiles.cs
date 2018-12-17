/* Script qui permet au joueur de lancer un projectile
 * 
 * @author Laurence Dodier
 * @version 2018-11-14
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectiles : MonoBehaviour {

    public bool peutTirer;
    //public GameObject particuleContact;
    public GameObject particuleTir;
    public GameObject gun;
    Animator animPersoTir; // va chercher l'animation du perso
    // Use this for initialization
    void Start() {
        animPersoTir = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //rayon à partir de la caméra vers l’avant à la position de la souris
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        // variable locale : contiendra les infos retournées par le Raycast sur l’objet touché
        RaycastHit infoCollision;

        if (Physics.Raycast(camRay.origin, camRay.direction, out infoCollision, 5000, LayerMask.GetMask("Terrain")))
        {
        
            Vector3 pointAregarder = infoCollision.point; // On copie le vecteur3 de contact pour pouvoir changer le y
            pointAregarder.y = 0; // élimine la hauteur lorsque le jeu se passe sur un plancher
            var distancePersoSouris = Vector3.Distance(transform.position, infoCollision.point);

            if (distancePersoSouris >= 1)
            {
                transform.LookAt(infoCollision.point); // L'objet regarde vers le point de contact
                transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            }
            

        }

        //si le bouton gauche est appuyé et qu'on peut tirer, alors on tire continuellement
        if (Input.GetKey(KeyCode.Mouse0) && peutTirer == true)
        {
            Invoke("TirerBalle", 0.1f);
            peutTirer = false;
            animPersoTir.SetTrigger("animTir");
            //print("Click gauche souris");

          
                 GameObject cloneParticule = Instantiate(particuleTir, transform.position, transform.rotation);
                
                //DestroyImmediate(particuleTir);
             
        }
    }

    //function qui permet d'activer des particules 
    void TirerBalle()
    {
        particuleTir.SetActive(true);
        Invoke("DesactiveBalle", 0.5f);
        //   cloneParticule.GetComponent<Rigidbody>().velocity = transform.forward * vitesseParticuleTir;
    }

    //function qui  désactive la balle
    void DesactiveBalle()
    {
        peutTirer = true;
        particuleTir.SetActive(false);
    }
}
