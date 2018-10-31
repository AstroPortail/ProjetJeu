using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlerPersonnage : MonoBehaviour
{

    // GESTION PERSONNAGE--------------------------------------------------------
    Rigidbody rbPerso; // va chercher le rigid du perso
    Animator animPerso; // va chercher l'anim du perso

    public float vitesseRotation; //la vitesse de rotation du perso
    public float vitesseDeplacement = 10f; // la vitesse de déplacement du perso

    public float vDeplacement; // la vitesse de déplacement du personnage
    public float vitesseSaut = 6; // hauteur de saut

    public bool auSol; //pour qu'on regarde si le perso est au sol ou non

    /* -------- Variable pour les objets dynamique ------------------- */
    public static float nombrePiece;
    public static bool cadeauRamasse = false;
    public static bool citrouilleRamasse = false;
    public static bool champiRamasse = false;
    public Text textNombrePiece;
    public GameObject imageCadeau;
    public GameObject imageCitrouille;
    public GameObject imageChampi;
    public GameObject lesItems;
    public MeshRenderer[] tableauMeshObjets;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        positionRandomObjets();

        StartCoroutine(positionRandomObjets());

        rbPerso = GetComponent<Rigidbody>();
        animPerso = GetComponent<Animator>();
       
    }

    
    void Update()
    {

           //-------------GESTION DU PERSONNAGE---------------------
        if (GestionCamera.pause == false) { 
        
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0); // la rotation sur l'axe horizontal

        vDeplacement = Input.GetAxis("Vertical") * vitesseDeplacement; // vitesse de déplacement sur l'axe verticale

        //remplace : rbPerso.AddRelativeForce(0,0, vDeplacement)
        // OU si le perso doit subir la gravité et pouvoir 

        rbPerso.velocity = (transform.forward * vDeplacement) + new Vector3(0, rbPerso.velocity.y, 0); // on fait avancer notre perso

        // si le perso est au sol, il peut sauter
        if (Input.GetKeyDown(KeyCode.Space) && auSol == true)
        {
            rbPerso.velocity += new Vector3(0, vitesseSaut, 0); // déclare la variable du saut pour l'attribuer dans l'Inspecteur

        }
        // on apelle l'animation 
        AnimerPerso();
        }
        else
        {
            animPerso.SetFloat("vitesseDep", 0);
        }

        /*on appel la gestion des objets intéractifs à toutes les updates*/
        gestionObjetsInteractifs();

    }// FIN DU UPDATE

    //-------------GESTION ANIMATION PERSONNAGE---------------------
    void AnimerPerso()
    {
        animPerso.SetFloat("vitesseDep", rbPerso.velocity.magnitude);
        RaycastHit infoCollision;
        auSol = Physics.SphereCast(transform.position + new Vector3(0, 0.5f, 0), 0.2f, -Vector3.up,
        out infoCollision, 0.8f); // on regarde si le personnage touche le sol
        //Si le personnage n'est pas au Sol alors l'animation saut doit jouer sinon elle arrête
        animPerso.SetBool("animSaut", !auSol);
    }

    //-------------Gestion de la détection de collision---------------------
    void OnCollisionEnter(Collision infoCollision)
    {

        if (infoCollision.gameObject.name == "tireBouchonAsset(Clone)" || infoCollision.gameObject.name == "mecaniqueAsset(Clone)")
        {
            nombrePiece += 1;
            Destroy(infoCollision.gameObject);
        }

        if (infoCollision.gameObject.name == "bombonneAsset(Clone)")
        {
            print("COUCOU");
            Destroy(infoCollision.gameObject);
        }

        if (infoCollision.gameObject.name == "cadeauAsset")
        {
            cadeauRamasse = true;
            Destroy(infoCollision.gameObject);
        }

        if (infoCollision.gameObject.name == "champisAsset")
        {
            champiRamasse = true;
            Destroy(infoCollision.gameObject);
        }

        if (infoCollision.gameObject.name == "citrouilleAsset")
        {
            citrouilleRamasse = true;
            Destroy(infoCollision.gameObject);
        }
    }

    void gestionObjetsInteractifs()
    {
        /*Changer le texte des pieces*/

        textNombrePiece.text = nombrePiece.ToString() + " / 12";

        /* changer le alpha des images si leur objets est rammassé*/
        if(cadeauRamasse == true)
        {
            imageCadeau.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        } else
        {
            imageCadeau.GetComponent<Image>().color = new Color32(255, 255, 255, 50);
        }

        if (champiRamasse == true)
        {
            imageChampi.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            imageChampi.GetComponent<Image>().color = new Color32(255, 255, 255, 50);
        }

        if (citrouilleRamasse == true)
        {
            imageCitrouille.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            imageCitrouille.GetComponent<Image>().color = new Color32(255, 255, 255, 50);
        }
    }

    IEnumerator positionRandomObjets()
    {
        for (var iEnum = 0; iEnum < tableauMeshObjets.Length ; iEnum++)
        {
            print(iEnum);
            tableauMeshObjets[iEnum].enabled = false;
        }
        GameObject.Find("citrouilleAsset").transform.position = new Vector3(Random.Range(48f, -48f), 20, Random.Range(48f, -48f));
        GameObject.Find("cadeauAsset").transform.position = new Vector3(Random.Range(48f, -48f), 20, Random.Range(48f, -48f));
        GameObject.Find("champisAsset").transform.position = new Vector3(Random.Range(48f, -48f), 20, Random.Range(48f, -48f));
        yield return new WaitForSeconds(4);

        for (var iEnum2 = 0; iEnum2 < tableauMeshObjets.Length ; iEnum2++)
        {
            print(iEnum2);
            tableauMeshObjets[iEnum2].enabled = true;
        }
    }


}// fin de la classe
